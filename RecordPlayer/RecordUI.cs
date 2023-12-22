using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace RecordPlayer
{
    class RecordUI
    {
        static string UserInteract()
        {
            string choice = "";
            string[] options = { "cr","lg","sv","rp","ld","cl","ex"};
            do
            {
                Console.Write(@"cr - Create new entry in the record
lg - Log the contents of the record to the console (print it)
sv - Save the Contents of the record 
rp - Replace the class in the file with the current class of the same name
ld - Load the data of a Record from the file
cl - Clear the current record of all current data
ex - exit the program");
                choice = Console.ReadLine();

            } while (!options.Any(choice.Equals));
            return choice;

        }

        static string ReturnClass()
        {
            string ClassName = "";
            do
            {
                Console.Write("What is the name of the class?: ");
                ClassName = Console.ReadLine(); 

            } while (Regex.Replace(ClassName, @"\s+", String.Empty) != "" );
            return ClassName;
        }
        static void Main(string[] args)
        {
            string menu = "";
            StudentRecords Str = new StudentRecords();
            do
            {
                menu = UserInteract();
                switch (menu)
                {
                    case "cr":
                        Str.CreateRecords();
                        break;
                    case "lg":
                        StudentRecords.ClassName = ReturnClass();
                        Str.LogRecords();
                        break;
                    case "sv":
                        StudentRecords.ClassName = ReturnClass();
                        Str.SaveCurrentRecord("save");
                        break;
                    case "rp":
                        StudentRecords.ClassName = ReturnClass();
                        Str.SaveCurrentRecord("replace");
                        break;
                    case "ld":
                        StudentRecords.ClassName = ReturnClass();
                        Str.LoadRecord();
                        break;
                    case "cl":
                        Str.ClearRecords();
                        break;
                    default:
                        break;
                }

            } while (menu != "ex");

            Console.WriteLine("You have chosen to exit the program");
            Console.ReadKey();
        }

    }
}
