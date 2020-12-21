using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndrivoDataBase
{
    public class TournamentDBContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=TeamDB;Trusted_Connection = True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public DbSet<Couch> Couch { get; set; }

        public DbSet<Player> Player { get; set; }
        public DbSet<PlayerTitle> PlayerTitle { get; set; }
        public DbSet<Team>Team { get; set; }
        public DbSet<Title> Title { get; set; }
     
    }
}
