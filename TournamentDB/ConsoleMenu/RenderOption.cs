using System;

namespace IndrivoDataBase.ConsoleMenu
{
    public class RenderOption
    {
        StartMenu StartMenu = new StartMenu();
        Constants Constants = new Constants();
        Team team = new Team();
        Player player = new Player();
        Couch couch = new Couch();
        Title title = new Title();

        public void RenderMenu()
        {
            Constants.RenderMenuPrints();
            ConsoleKeyInfo key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.D1:
                    RenderTeams();
                    break;
                case ConsoleKey.D2:
                    RenderPlayers();
                    break;
                case ConsoleKey.D3:
                    RenderCoaches();
                    break;
                case ConsoleKey.D4:
                    RenderTitles();
                    break;
                case ConsoleKey.B:
                    StartMenu.Menu();
                    break;
            }
        }

        public void RenderTeams()
        {
            Constants.Welcome("Render-Team");
            Constants.ChosseOption();
            Constants.AllorByName();
            Constants.Return();
            ConsoleKeyInfo key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.D1:
                    Constants.TeamRenderBy();
                    ConsoleKeyInfo key1 = Console.ReadKey(true);
                    switch (key1.Key)
                    {
                        case ConsoleKey.D1:
                            team.RenderAllTeams(1);
                            break;
                        case ConsoleKey.D2:
                            team.RenderAllTeams(2);
                            break;
                        
                    }
                    Constants.Return();
                    if (key1.Key == ConsoleKey.B) { RenderTeams(); }
                    break;
                
                case ConsoleKey.D2: 
                    Constants.Add_Seq();
                    String input = Console.ReadLine();

                    team.RenderTeamsByLetter(input);
                    Constants.Return();
                    ConsoleKeyInfo key2 = Console.ReadKey(true);
                    if (key2.Key == ConsoleKey.B){ RenderTeams(); }
                    break;
                
                case ConsoleKey.B:
                    RenderMenu();
                    break;
            }
            
        }

        public void RenderPlayers()
        {
            Constants.Welcome("Render-Players");
            Constants.ChosseOption();
            Constants.AllorByName();
            Constants.Return();
            
            ConsoleKeyInfo key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.D1:
                    Constants.PlayerRenderBy();
                    ConsoleKeyInfo key1 = Console.ReadKey(true);
                    switch (key1.Key)
                    {
                        case ConsoleKey.D1:
                            player.renderAllPlayers(1);
                            break;
                        case ConsoleKey.D2:
                            player.renderAllPlayers(2);
                            break;
                        case ConsoleKey.D3:
                            player.renderAllPlayers(3);
                            break;
                        case ConsoleKey.D4:
                            player.renderAllPlayers(4);
                            break;
                        
                    }
                    Constants.Return();
                    if (key1.Key == ConsoleKey.B) { RenderPlayers(); }
                    break;

                case ConsoleKey.D2:
                    Constants.Add_Seq();
                    string letter = Console.ReadLine();
                    player.renderPlayerByLetter(letter);
                    Constants.Return();
                    ConsoleKeyInfo key2 = Console.ReadKey(true);
                    if (key2.Key == ConsoleKey.B) { RenderPlayers(); }
                    break;

                case ConsoleKey.B:
                    RenderMenu();
                    break;
            }
        }

        public void RenderCoaches()
        {
            Constants.Welcome("Render-Coaches");
            Constants.ChosseOption();
            Constants.AllorByName();
            Constants.Return();
            ConsoleKeyInfo key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.D1:
                    Constants.CouchRenderBy();
                    ConsoleKeyInfo key1 = Console.ReadKey(true);
                    switch (key1.Key)
                    {
                        case ConsoleKey.D1:
                            couch.RenderAllCouches(1);
                            break;
                        case ConsoleKey.D2:
                            couch.RenderAllCouches(2);
                            break;
                        case ConsoleKey.D3:
                            couch.RenderAllCouches(3);
                            break;
                    }

                    Constants.Return();
                    
                    if (key1.Key == ConsoleKey.B) { RenderCoaches(); }
                    break;

                case ConsoleKey.D2:
                    Constants.Add_Seq();
                    String letter = Console.ReadLine();
                    couch.RenderCouchesByLetter(letter);
                    Constants.Return();
                    ConsoleKeyInfo key11 = Console.ReadKey(true);
                    if (key11.Key == ConsoleKey.B) { RenderCoaches(); }
                    break;
                
                case ConsoleKey.B:
                    RenderMenu();
                    break;
            }


        }

        public void RenderTitles()
        {
            Constants.Welcome("Render-Titles");
            Constants.ChosseOption();
            Constants.AllorByName();
            Constants.Return();
            ConsoleKeyInfo key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.D1:
                    title.RenderAllTitle();
                    Constants.Return();
                    ConsoleKeyInfo key1 = Console.ReadKey(true);
                    if (key1.Key == ConsoleKey.B) { RenderTitles(); }
                    break;
                
                case ConsoleKey.D2:
                    Constants.Add_Seq();
                    string letter = Console.ReadLine();
                    title.RenderTitlesByLetter(letter);
                    Constants.Return();
                    ConsoleKeyInfo key2 = Console.ReadKey(true);
                    if (key2.Key == ConsoleKey.B) { RenderTitles(); }
                    break;
                
                case ConsoleKey.B:
                    RenderMenu();
                    break;
            }
        }
    }
}