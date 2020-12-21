using System;
using System.Collections.Generic;
using System.Linq;
using TournamentDB.ConsoleMenu;

namespace IndrivoDataBase
{
    public class Team : BaseEntity
    {
        public String Name { get; set; }
        public DateTime FoundationYear { get; set; }
        public ICollection<Player> Players { get; set; }
        public Couch Couch { get; set; }

        private bool CreateValidation(String name)
        {
            using (var context = new TournamentDBContext())
            {
                return context.Team.Any(Team => Team.Name == name);
            }
            
        }

        public void CreateTeam(String Name, DateTime FoundationYear)
        {
            using (var context = new TournamentDBContext())
            {
                if (!CreateValidation(Name))
                {
                    var team = new Team
                    {
                        Id = new Guid(),
                        CreatedTime = DateTime.Now,
                        
                        Name = Name,
                        FoundationYear = FoundationYear,
                    };
                    context.Team.Add(team);
                    context.SaveChanges();
                }
                else
                {
                    Constants constants = new Constants();
                    constants.NameExists();
                }
            }
        }

        private bool CheckOldNAme(String oldname)
        {
            using (var context = new TournamentDBContext())
            {
                return context.Team.Any(Team => Team.Name == oldname);
            }
            
        }

        private bool CheckNewName(String newName)
        {
            using (var context = new TournamentDBContext())
            {
                return context.Team.Any(Team => Team.Name == newName);
            }
            
        }
        
        public void ModifyTeam(String oldName, String newName)
        {
            using (var context = new TournamentDBContext())
            {
                Constants constants = new Constants();
                if (CheckOldNAme(oldName))
                {
                    if (!CheckNewName(newName))
                    {
                        var team = context.Team.First(Team => Team.Name == oldName);
                        team.Name = newName;
                        team.ModifiedTime = DateTime.Now;
                        context.SaveChanges();
                    }
                    else
                    {
                        constants.NameExists();
                    }
                }
                else
                {
                    constants.NameDoNotExists();
                }
            }
        }

        private List<Team> OrderBy(List<Team> teams,int choice)
        {
            using (var context = new TournamentDBContext())
            {
                
                switch (choice)
                {
                    case 1: 
                        teams = context.Team.OrderBy(Team => Team.Name).ToList(); 
                        break;
                    case 2:
                        teams = context.Team.OrderBy(Team => Team.FoundationYear).ToList();
                        break;
                }
            }

            return teams;
        }
        public void RenderAllTeams(int choice)
        {
            Constants constants = new Constants();
            Console.Clear();
            constants.HereAreAll();
            using (var context = new TournamentDBContext())
            {
                int count = 1;
                var teams = context.Team.ToList();
                teams = OrderBy(teams, choice);
                Pagination pagination = new Pagination();
                pagination.TeamsToPage(teams, 0);
            }
        }

        public void RenderTeamsByLetter(string letter)
        {
            Constants constants = new Constants();
            Console.Clear();
            constants.HereAreAll();
            using (var context = new TournamentDBContext())
            {
                int count = 1;
                var teams = context.Team.Where(Team => Team.Name.Contains(letter) && Team.DeletedTime == null).ToList();
                foreach(var team in teams)
                {
                    Console.WriteLine(count + ": " + team.Name);
                    count++;
                }
            }
        }

        public void DeleteTeam(string name)
        {
            using (var context = new TournamentDBContext())
            {
                var team = context.Team.First(Team => Team.Name == name);
                team.DeletedTime = DateTime.Now;
                Constants constants = new Constants();
                constants.Deleted();
                context.SaveChanges();
            }
        }
        
        
    }
    
}