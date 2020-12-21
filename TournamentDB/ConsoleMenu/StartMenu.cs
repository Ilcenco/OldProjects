using System;
using System.Collections.Generic;
using System.Text;

namespace IndrivoDataBase.ConsoleMenu
{
    public class StartMenu
    {
        public void Menu()
        {
         
            RenderOption renderOption = new RenderOption();
            DeleteOption deleteOption = new DeleteOption();
            ModifyOption modifyOption = new ModifyOption();
            AddOption addOption = new AddOption();
            Constants constants = new Constants();
            
            constants.StartMenuPrints();
            
            ConsoleKeyInfo key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.D1:
                    renderOption.RenderMenu();
                    break;
                case ConsoleKey.D2:
                    addOption.AddMenu();
                    break;
                case ConsoleKey.D3:
                    modifyOption.ModifyMenu();
                    break;
                case ConsoleKey.D4:
                    deleteOption.DeleteMenu();
                    break;
                    
            }

        }
    }
}