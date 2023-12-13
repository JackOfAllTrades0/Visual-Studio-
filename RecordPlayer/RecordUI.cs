using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RecordPlayer
{
    class RecordUI
    {
        static string UserInteract()
        {
            string choice = "";
            string[] options = { "Cr","Lg","Sv","Ld","Cl"};
            do
            {
                Console.Write(@"Cr - Create new entry in the record
Lg - Log the contents of the record to the console (print it)
Sv - Save the Contents of the record under a name to a file or relpace an old name
Ld - Load the data of a Record from the file
Cl - Clear the current record of all current data");
                choice = Console.ReadLine();

            } while (!options.Any(choice.Equals));
            return choice;

        }
        static void Main(string[] args)
        {
            
            

            Console.ReadKey();
        }

    }
}
