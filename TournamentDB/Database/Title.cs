using System;
using System.Collections.Generic;
using System.Linq;

namespace IndrivoDataBase
{
    public class Title : BaseEntity
    {
        public String Name { get; set; }
        public DateTime Year { get; set; }
        public ICollection<PlayerTitle> TitlePlayers { get; set; }

        private bool ValidateTitle(string name, DateTime year)
        {
            using (var context = new TournamentDBContext())
            {
                return context.Title.Any(Title => Title.Name == name && Title.Year == year);
            }
        }
        public void CreateTitle(String name, DateTime year)
        {
            Constants constants = new Constants();
            if (!ValidateTitle(name, year))
            {
                using (var context = new TournamentDBContext())
                {
                    var title = new Title
                    {
                        Id = Guid.NewGuid(),
                        CreatedTime = DateTime.Now,
                        
                        Name = name,
                        Year = year,
                    };
                    context.Title.Add(title);
                    context.SaveChanges();
                }
            }
            else
            {
                constants.NameExists();
            }
        }

        public void RenderAllTitle()
        {
            Console.Clear();
            Constants constants = new Constants();
            constants.HereAreAll();
            using (var context = new TournamentDBContext())
            {
                int count = 1;
                var titles = context.Title;
                foreach (var title in titles)
                {
                    if(title.DeletedTime == null)
                    {
                        Console.WriteLine(count + ": " + title.Name);
                        count++;
                    }
                }
            }
        }

        public void RenderTitlesByLetter(string letter)
        {
            Console.Clear();
            Constants constants = new Constants();
            constants.HereAreAll();
            using (var context = new TournamentDBContext())
            {
                int count = 1;
                var titles = context.Title.Where(title => title.Name.Contains(letter) && title.DeletedTime == null).ToList();
                foreach (var title in titles)
                {
                    if(title.DeletedTime == null)
                    {
                        Console.WriteLine(count + ": " + title.Name);
                        count++;
                    }
                    
                }
            }
        }

        public void DeleteTitle(string name)
        {
            using (var context = new TournamentDBContext())
            {
                var title = context.Title.First(Title => Title.Name == name);
                title.DeletedTime = DateTime.Now;
                Constants constants = new Constants();
                constants.Deleted();
                context.SaveChanges();
            }
        }
    }
}