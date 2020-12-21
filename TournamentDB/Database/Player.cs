using System;
using System.Collections.Generic;
using System.Linq;
using TournamentDB.ConsoleMenu;

namespace IndrivoDataBase
{
    public class Player : BaseEntity
    {
        public String Name { get; set; }
        public DateTime BirthDate { get; set; }
        public int Sallary { get; set; }
        public String Position { get; set; }
        
        public ICollection<PlayerTitle> PlayerTitles { get; set; }
        public Guid TeamId { get; set; }
        public Team Team { get; set; }

        private bool CheckPlayerTeam(String teamName)
        {
            using (var context = new TournamentDBContext())
            {
                return context.Team.Any(Team => Team.Name == teamName);
            }
        }
        private bool CreateValidation(String Name)
        {
            using (var context = new TournamentDBContext())
            {
                return context.Player.Any(Player => Player.Name == Name);
            }
        }

        public void CreatePlayer(String Name, DateTime birthDate, int sallary, String position, string teamName)
        {
            if (!CreateValidation(Name) && CheckPlayerTeam(teamName))
            {
                using (var context = new TournamentDBContext()) 
                {

                    var team = context.Team.First(Team => Team.Name == teamName);
                    var player = new Player
                    {
                        Id = Guid.NewGuid(),
                        CreatedTime = DateTime.Now,
                        Name = Name,
                        BirthDate = birthDate,
                        Sallary = sallary,
                        Position = position,
                        Team = team,
                        TeamId = team.Id,
                    };
                
                    context.Player.Add(player);
                    context.SaveChanges();
                
                }
                
            }
            else
            {
                Constants constants = new Constants();
                constants.NameExists();
            }
        }
        
        private bool CheckOldName(string oldname)
        {
            using (var context = new TournamentDBContext())
            {
                return context.Player.Any(Player => Player.Name == oldname);
            }
        }

        private bool CheckNewName(String newname)
        {
            using (var context = new TournamentDBContext())
            {
                return context.Player.Any(Player => Player.Name == newname);
            }
        }

        public void ModifyPlayer(String oldName, String newName)
        {
            Constants constants = new Constants();
            if (CheckOldName(oldName))
            {
                if (!CheckNewName(newName))
                {
                    using (var context = new TournamentDBContext())
                    {
                        var player = context.Player.First(Player => Player.Name == oldName);
                        player.Name = newName;
                        player.ModifiedTime = DateTime.Now;
                        constants.FinishModification(newName,oldName);
                        context.SaveChanges();

                    }
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

        private List<Player> OrderBy(List<Player> players,int choice)
        {
            using (var context = new TournamentDBContext())
            {
                
                switch (choice)
                {
                    case 1: 
                        players = context.Player.OrderBy(Player => Player.Name).ToList(); 
                        break;
                    case 2:
                        players = context.Player.OrderBy(Player => Player.BirthDate).ToList();
                        break;
                    case 3:
                        players = context.Player.OrderBy(player => player.Sallary).ToList();
                        break;
                    case 4:
                        players = context.Player.OrderBy(player => player.Position).ToList();
                        break;
                }
            }

            return players;
        }

        public void renderAllPlayers(int choice)
        {
            Console.Clear();
            Constants constants = new Constants();
            constants.HereAreAll();
            using (var context = new TournamentDBContext())
            {
                int count = 1;
                var players = context.Player.ToList();
                players = OrderBy(players,choice);
                Pagination pagination = new Pagination();
                pagination.PlayersToPage(players,0);
            }
        }

        public void renderPlayerByLetter(string letter)
        {
            Constants constants = new Constants();
            constants.HereAreAll();
            using (var context = new TournamentDBContext())
            {
                int count = 1;
                var players = context.Player.Where(Player => Player.Name.Contains(letter) && Player.DeletedTime == null).ToList();
                foreach (var player in players)
                {
                    Console.WriteLine(count + ": " + player.Name);
                    count++;
                }
            }
            
        }

        public void DeletePlayer(string name)
        {
            using (var context = new TournamentDBContext())
            {
                var player = context.Player.First(Player => Player.Name == name);
                player.DeletedTime = DateTime.Now;
                Constants constants = new Constants();
                constants.Deleted();
                context.SaveChanges();
            }
        }
    }
}