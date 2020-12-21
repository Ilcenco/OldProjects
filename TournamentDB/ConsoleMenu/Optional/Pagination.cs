using System;
using System.Collections.Generic;
using IndrivoDataBase;
using IndrivoDataBase.ConsoleMenu;

namespace TournamentDB.ConsoleMenu
{
    public class Pagination
    {
        private Constants _constants = new Constants();
        private RenderOption _renderOption = new RenderOption();


        private int Check_Players_Per_Page(List<Player> players, int players_per_page)
        {
            if (players_per_page >= players.Count)
            {
                players_per_page = players.Count;
            }

            return players_per_page;
        }

        private int Check_Players_pIndex(List<Player> players, int p_index)
        {
            if (p_index < 0)
            {
                p_index = players.Count + p_index;
            }

            if (p_index > players.Count - 1)
            {
                p_index = 0;
            }

            return p_index;
        }
        public void PlayersToPage(List<Player> players, int p_index)
        {
            int a = 0;
            int players_per_page = 3;
            
            _constants.PagePrint();
            for (int i = 0; i < players.Count; i++)
            {
                // verify if the index does not exceed the permisions
                players_per_page = Check_Players_Per_Page(players, players_per_page);
                p_index = Check_Players_pIndex(players, p_index);
                
                // print player name and increase index and count variable 'a'
                Console.WriteLine(p_index+1 + ": " + players[p_index].Name + " " + players[p_index].BirthDate.Year + 
                                  " " + players[p_index].Position + " " + players[p_index].Sallary + "\n");
                p_index++;
                a++;
                
                if(a == players_per_page) {break;}
            }
            _constants.Return();
            ConsoleKeyInfo key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.N:
                    PlayersToPage(players, p_index);
                    break;
                case ConsoleKey.P:
                    PlayersToPage(players, p_index - 2 * players_per_page);
                    break;
                case ConsoleKey.B:
                    _renderOption.RenderPlayers();
                    break;
            }
        }
        
        
        

        private int Check_Teams_tIndex(List<Team> teams,  int t_index)
        {
            if (t_index < 0)
            {
                t_index = teams.Count + t_index;
            }

            if (t_index > teams.Count - 1)
            {
                t_index = 0;
            }

            return t_index;
        }

        private int Check_Teams_Per_Page(List<Team> teams, int teams_per_page)
        {
            if (teams_per_page >= teams.Count)
            {
                teams_per_page = teams.Count;
            }

            return teams_per_page;
        }

        public void TeamsToPage(List<Team> teams, int t_index)
        {
            int a = 0;
            int teams_per_page = 2;
            _constants.PagePrint();

            for (int i = 0; i < teams.Count; i++)
            {
                // verify if the index does not exceed the permisions
                teams_per_page = Check_Teams_Per_Page(teams, teams_per_page);
                t_index = Check_Teams_tIndex(teams, t_index);
                
                // print team name and increase index and count variable 'a'
                Console.WriteLine(t_index+1 + " " + teams[t_index].Name + " " + teams[t_index].FoundationYear.Year + "\n");
                t_index++;
                a++;
                if(a == teams_per_page) {break;}
                
            }
            _constants.Return();
            ConsoleKeyInfo key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.N:
                    TeamsToPage(teams, t_index);
                    break;
                case ConsoleKey.P:
                    TeamsToPage(teams, t_index - 2 * teams_per_page);
                    break;
                case ConsoleKey.B:
                    _renderOption.RenderTeams();
                    break;
            }
        }




        private int Check_Couch_cIndex(List<Couch> couches, int c_index)
        {
            if (c_index < 0)
            {
                c_index = couches.Count + c_index;
            }

            if (c_index > couches.Count - 1)
            {
                c_index = 0;
            }

            return c_index;
        }

        private int Check_Couches_Per_Page(List<Couch> couches, int couch_per_page)
        {
            if (couch_per_page >= couches.Count)
            {
                couch_per_page = couches.Count;
            }

            return couch_per_page;
        }

        public void CouchToPage(List<Couch> couches, int c_index)
        {
            int a = 0;
            int couch_per_page = 2;
            _constants.PagePrint();

            for (int i = 0; i < couches.Count; i++)
            {
                // verify if the index does not exceed the permisions
                couch_per_page = Check_Couches_Per_Page(couches, couch_per_page);
                c_index = Check_Couch_cIndex(couches, c_index);
                
                // print team name and increase index and count variable 'a'
                Console.WriteLine(c_index+1 + " " + couches[c_index].Name + " " + couches[c_index].BirthDate.Year);
                Console.WriteLine("  " + couches[c_index].Sallary + "\n");
                c_index++;
                a++;
                if(a == couch_per_page) {break;}
                
            }
            _constants.Return();
            ConsoleKeyInfo key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.N:
                    CouchToPage(couches, c_index);
                    break;
                case ConsoleKey.P:
                    CouchToPage(couches, c_index - 2 * couch_per_page);
                    break;
                case ConsoleKey.B:
                    _renderOption.RenderCoaches();
                    break;
            }
            
        }
        
    }
}