using System;

namespace IndrivoDataBase
{
    public class Constants
    {
        public void PagePrint()
        {
            Welcome("Pagination v1.0");
            Console.WriteLine("P <- Previous Page | Next Page -> N");
            Console.WriteLine();
        }
        public void StartMenuPrints()
        {
            Welcome("Main2.0");
            ChosseOption();
            Console.WriteLine("1 -> Render an instance");
            Console.WriteLine("2 -> Add an instance");
            Console.WriteLine("3 -> Modify an instance");
            Console.WriteLine("4 -> Delete an instance");
        }
        public void RenderMenuPrints()
        {
            Welcome("Render");
            ChosseOption();
            Console.WriteLine("1 -> Team");
            Console.WriteLine("2 -> Player");
            Console.WriteLine("3 -> Couch");
            Console.WriteLine("4 -> Title");
            Return();
            
        }
        public void ModifyMenuPrints()
        {
            Welcome("Modify");
            ChosseOption();
            Console.WriteLine("1 -> Team");
            Console.WriteLine("2 -> Player");
            Console.WriteLine("3 -> Couch");
            Return();
        }
        public void DeleteMenuPrints()
        {
            Welcome("Delete");
            ChosseOption();
            Console.WriteLine("1 -> Team");
            Console.WriteLine("2 -> Player");
            Console.WriteLine("3 -> Couch");
            Console.WriteLine("4 -> Title"); 
            Return();
        }
        public void AddMenuPrints()
        {
            Console.Clear();
            Welcome("Add");            
            ChosseOption();
            Console.WriteLine("1 -> Team");
            Console.WriteLine("2 -> Player");
            Console.WriteLine("3 -> Couch");
            Console.WriteLine("4 -> Title");
            Return();
        }

        public void AddWith()
        {
            Console.WriteLine("1 -> Add with personal data");
            Return();
        }
        public void Return()
        {
            Console.WriteLine("B -> Return");
        }

        public void Welcome(string MenuType)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the " + MenuType + " menu");
        }

        public void ChosseOption()
        {
            Console.WriteLine("Choose an option from:");
        }

        public void PlayerRenderBy()
        {
            Console.Clear();
            Console.WriteLine("Order instances by...");
            ChosseOption();
            Console.WriteLine("1 -> Name");
            Console.WriteLine("2 -> BirthDate");
            Console.WriteLine("3 -> Salary");
            Console.WriteLine("4 -> Position");
        }

        public void TeamRenderBy()
        {
            Console.Clear();
            Console.WriteLine("Order instances by...");
            ChosseOption();
            Console.WriteLine("1 -> Name");
            Console.WriteLine("2 -> FoundationYear");
        }

        public void CouchRenderBy()
        {
            Console.Clear();
            Console.WriteLine("Order instances by...");
            ChosseOption();
            Console.WriteLine("1 -> Name");
            Console.WriteLine("2 -> BirthDate");
            Console.WriteLine("3 -> Salary");
        }

        public void AllorByName()
        {
            Console.WriteLine("1 -> Render all");
            Console.WriteLine("2 -> Search");
        }

        // Add an istance texts
        public void Add_Name()
        {
            Console.WriteLine("Give a name");
        }

        public void Add_Sallary()
        {
            Console.WriteLine("Give a salary");
        }

        public void Add_Team()
        {
            Console.WriteLine("Give a Team");
        }

        public void Add_Position()
        {
            Console.WriteLine("Give a position");
        }

        public void Add_NewName()
        {
            Console.WriteLine("Give a new name");
        }

        public void Add_Seq()
        {
            Console.WriteLine("Give letter or sequence");
        }
        
        //Modify istance
        public void FinishModification(string newname, string oldname)
        {
            Console.WriteLine("Done, you just renamed the instance from " + oldname + " to " + newname);
        }

        public void NameExists()
        {
            Console.WriteLine("Unable to execute, this name is already used in the database");
        }

        public void NameDoNotExists()
        {
            Console.WriteLine("Unable to execute, this name is not used in the database");
        }
        //Render istance
        public void HereAreAll()
        {
            Console.WriteLine("Here are all instances of this type in database");
        }
        //Delete istance
        public void Deleted()
        {
            Console.WriteLine("The instance has just been set as deleted");
        }
    }
}