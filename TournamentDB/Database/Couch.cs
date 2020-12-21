using System;
using System.Collections.Generic;
using System.Linq;
using TournamentDB.ConsoleMenu;

namespace IndrivoDataBase
{
    public class Couch : BaseEntity
    {
        public String Name { get; set; }
        public DateTime BirthDate { get; set; }
        public int Sallary { get; set; }
        public Guid TeamId { get; set; }
        public Team Team { get; set; }

        private bool CheckTeamName(string teamName)
        {
            using (var context = new TournamentDBContext())
            {
                return context.Team.Any(Team => Team.Name == teamName);
            }
        }

        private bool CreateValidation(String name)
        {
            using (var context = new TournamentDBContext())
            {
                return context.Couch.Any(Couch => Couch.Name == name);
            }
        }

        public void CreateCouch(String Name, DateTime BirthDate, int Sallary, string teamName)
        {
            if (!CreateValidation(Name) && CheckTeamName(teamName))
            {
                using (var context = new TournamentDBContext())
                {
                    var team = context.Team.First(Team => Team.Name == teamName);

                    var couch = new Couch
                    {
                        Id = Guid.NewGuid(),
                        CreatedTime = DateTime.Now,

                        Name = Name,
                        BirthDate = BirthDate,
                        Sallary = Sallary,
                        Team = team,
                        TeamId = team.Id,
                    };

                    context.Couch.Add(couch);
                    context.SaveChanges();

                }
            }
            else
            {
                Constants constants = new Constants();
                constants.NameExists();
            }
        }

        private bool CheckNewName(String newname)
        {
            using (var context = new TournamentDBContext())
            {
                return context.Couch.Any(Couch => Couch.Name == newname);
            }
        }

        private bool CheckOldName(String oldname)
        {
            using (var context = new TournamentDBContext())
            {
                return context.Couch.Any(Couch => Couch.Name == oldname);
            }
        }

        public void ModifyCouch(string oldName, string newName)
        {
            using (var context = new TournamentDBContext())
            {
                Constants constants = new Constants();
                if (CheckOldName(oldName))
                {
                    if (!CheckNewName(newName))
                    {
                        Couch couch = context.Couch.First(Couch => Couch.Name == oldName);
                        couch.Name = newName;
                        couch.ModifiedTime = DateTime.Now;
                        context.SaveChanges();
                        constants.FinishModification(newName,oldName);
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

        private List<Couch> OrderBy(List<Couch> couches,int choice)
        {
            using (var context = new TournamentDBContext())
            {
                
                switch (choice)
                {
                    case 1: 
                        couches = context.Couch.OrderBy(Couch => Couch.Name).ToList(); 
                        break;
                    case 2:
                        couches = context.Couch.OrderBy(Couch => Couch.BirthDate).ToList(); 
                        break;
                    case 3:
                        couches = context.Couch.OrderBy(Couch => Couch.Sallary).ToList(); 
                        break;
                }
            }

            return couches;
        }
        public void RenderAllCouches(int choice)
        {
            Console.Clear();
            Constants constants = new Constants();
            constants.HereAreAll();
            using (var context = new TournamentDBContext())
            {
                int count = 1;
                var coaches = context.Couch.ToList();
                coaches = OrderBy(coaches, choice);
                
                Pagination pagination = new Pagination();
                pagination.CouchToPage(coaches, 0);
            }
        }

        public void RenderCouchesByLetter(string letter)
        {
            Console.Clear();
            Constants constants = new Constants();
            constants.HereAreAll();
            using (var context = new TournamentDBContext())
            {
                int count = 1;
                var coaches = context.Couch.Where(Couch => Couch.Name.Contains(letter) && Couch.DeletedTime == null)
                    .ToList();
                foreach (var coach in coaches)
                {
                    Console.WriteLine(count + ": " + coach.Name);
                    count++;
                }
            }
        }

        public void DeleteCouch(string name)
        {
            using (var context = new TournamentDBContext())
            {
                var couch = context.Couch.First(Couch => Couch.Name == name);
                couch.DeletedTime = DateTime.Now;
                Constants constants = new Constants();
                constants.Deleted();
                context.SaveChanges();
            }
        }
    }
}