using System;


namespace IndrivoDataBase.ConsoleMenu
{
    public class ModifyOption
    {
        StartMenu startMenu = new StartMenu();
        Constants Constants = new Constants();
        Player player = new Player();
        Team team = new Team();
        Couch couch = new Couch();


        public void ModifyMenu()
        {
            Constants.ModifyMenuPrints();
            ConsoleKeyInfo key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.D1:
                    ModifyTeam();
                    break;
                case ConsoleKey.D2:
                    ModifyPlayer();
                    break;
                case ConsoleKey.D3:
                    ModifyCouch();
                    break;
                case ConsoleKey.B:
                    startMenu.Menu();
                    break;
            }

        }

        public void ModifyTeam()
        {
            Constants.Welcome("Modify-Team");
            Constants.Add_Name();
            string Mname = Console.ReadLine();
            Constants.Add_NewName();
            string Nname = Console.ReadLine();
            
            team.ModifyTeam(Mname, Nname);
            
            Constants.Return();
            ConsoleKeyInfo key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.B) { ModifyMenu(); }

        }
        public void ModifyPlayer()
        {
            Constants.Welcome("Modify-Player");
            Constants.Add_Name();
            string Mname = Console.ReadLine(); 
            Constants.Add_NewName();
            string Nname = Console.ReadLine();
            
            player.ModifyPlayer(Mname, Nname);
            Constants.Return();
            ConsoleKeyInfo key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.B) { ModifyMenu(); }
        }
        public void ModifyCouch()
        {
            Constants.Welcome("Modify-Couch");
            Constants.Add_Name();
            string Mname = Console.ReadLine();
            Constants.Add_NewName();
            string Nname = Console.ReadLine();
            
            couch.ModifyCouch(Mname, Nname);
            Constants.Return();

            ConsoleKeyInfo key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.B) { ModifyMenu(); }
        }
        
    }
}
