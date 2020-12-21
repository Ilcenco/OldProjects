using System;


namespace IndrivoDataBase.ConsoleMenu
{
    public class AddOption
    {
        Constants Constants = new Constants();
        StartMenu startMenu = new StartMenu();
        Team team = new Team();
        Couch couch = new Couch();
        Player player = new Player();
        Title title = new Title();
        public void AddMenu()
        {
            Constants.AddMenuPrints();
            ConsoleKeyInfo key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.D1:
                    AddTeam();
                    break;
                case ConsoleKey.D2:
                    AddPlayer();
                    break;
                case ConsoleKey.D3:
                    AddCouch();
                    break;
                case ConsoleKey.D4:
                    AddTitle();
                    break;
                case ConsoleKey.B:
                    startMenu.Menu();
                    break;
            }

        }
        public void AddTeam()
        {
            Constants.Welcome("Add-Team");
            Constants.ChosseOption();
            Constants.AddWith();
            ConsoleKeyInfo key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.D1:
                    Constants.Add_Name();
                    string name = Console.ReadLine();
                    
                    
                    team.CreateTeam(name, DateTime.Now);
                    Constants.Return();
                    ConsoleKeyInfo key1 = Console.ReadKey(true);
                    if (key1.Key == ConsoleKey.B){AddTeam();}
                        break;
                
                case ConsoleKey.B:
                    AddMenu();
                    break;
            }

        }
        public void AddPlayer()
        {
            Constants.Welcome("Add-Player");
            Constants.ChosseOption();
            Constants.AddWith();

            ConsoleKeyInfo key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.D1:
                    Constants.Add_Name();
                    string name = Console.ReadLine();
                    Constants.Add_Position();
                    string position = Console.ReadLine();
                    Constants.Add_Sallary();
                    int sallary = Convert.ToInt32(Console.ReadLine());
                    Constants.Add_Team();
                    string teamName = Console.ReadLine();
                    
                    player.CreatePlayer(name, DateTime.Now, sallary, position, teamName);
                    Constants.Return();
                    
                    ConsoleKeyInfo key1 = Console.ReadKey(true);
                    if(key1.Key == ConsoleKey.B) {AddPlayer();}
                    break;
                
                
                case ConsoleKey.B:
                    AddMenu();
                    break;
            }



        }
        public void AddCouch()
        {
            Constants.Welcome("Add-Couch");
            Constants.ChosseOption();
            Constants.AddWith();

            ConsoleKeyInfo key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.D1:
                    Constants.Add_Name();
                    string name = Console.ReadLine();
                    Constants.Add_Sallary();
                    int sallary = Convert.ToInt32(Console.ReadLine());
                    Constants.Add_Team();
                    string teamname = Console.ReadLine();
                    
                    couch.CreateCouch(name, DateTime.Now, sallary, teamname);
                    
                    Constants.Return();
                    ConsoleKeyInfo key1 = Console.ReadKey(true);
                    if(key1.Key == ConsoleKey.B) {AddCouch();}
                    break;
                
                case ConsoleKey.B:
                    AddMenu();
                    break;
            }
        }
        public void AddTitle()
        {
            Constants.Welcome("Add-Title");
            Constants.ChosseOption();
            Constants.AddWith();

            ConsoleKeyInfo key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.D1:
                    Constants.Add_Name();
                    string name = Console.ReadLine();
                    
                    title.CreateTitle(name, DateTime.Now);
                    Constants.Return();
                    
                    ConsoleKeyInfo key1 = Console.ReadKey(true);
                    if(key1.Key == ConsoleKey.B) {AddTitle();}
                    break;
                case ConsoleKey.B:
                    AddMenu();
                    break;
            }
        }

    }
}
