using System;


namespace IndrivoDataBase.ConsoleMenu
{
    public class DeleteOption
    {
        StartMenu StartMenu = new StartMenu();
        Constants Constants = new Constants();
        Couch couch = new Couch();
        Title title = new Title();
        Player player = new Player();
        Team team = new  Team();

        public void DeleteMenu()
        {
            Constants.DeleteMenuPrints();
            ConsoleKeyInfo key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.D1:
                    DeleteTeam();
                    break;
                case ConsoleKey.D2:
                    DeletePlayer();
                    break;
                case ConsoleKey.D3:
                    DeleteCouch();
                    break;
                case ConsoleKey.D4:
                    DeleteTitle();
                    break;
                case ConsoleKey.B:
                    StartMenu.Menu();
                    break;
            }

        }

        public void DeleteTeam()
        {
            Constants.Welcome("Delete-Team");
            Constants.Add_Name();
            string Tname = Console.ReadLine();
            
            team.DeleteTeam(Tname);
            Constants.Return();
            
            ConsoleKeyInfo key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.B) { DeleteMenu(); }

        }

        public void DeletePlayer()
        {
            Constants.Welcome("Delete-Player");
            Constants.Add_Name();
            string Tname = Console.ReadLine();

            
            player.DeletePlayer(Tname);
            Constants.Return();
            ConsoleKeyInfo key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.B) { DeleteMenu(); }

        }

        public void DeleteCouch()
        {
            Constants.Welcome("Detele-Couch");
            Constants.Add_Name();
            string Tname = Console.ReadLine();
            
            couch.DeleteCouch(Tname);

            Constants.Return();
            ConsoleKeyInfo key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.B) { DeleteMenu(); }

        }
        public void DeleteTitle()
        {
            Constants.Welcome("Detele-Title");
            Constants.Add_Name();
            string Tname = Console.ReadLine();

            title.DeleteTitle(Tname);

            Constants.Return();
            ConsoleKeyInfo key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.B) { DeleteMenu(); }

        }
    }
}
