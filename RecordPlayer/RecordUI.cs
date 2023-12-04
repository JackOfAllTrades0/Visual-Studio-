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
            string[] options = { "Cr","Lg","Sv","Ld"};
            do
            {
                Console.Write(@"Cr - Create new entry in the record
Lg - Log the contents of the record to the console (print it)
Sv - Save the Contents of the record under a name to a file
Ld - Load the data of a Record from the file");
                choice = Console.ReadLine();

            } while (!options.Any(choice.Equals));
            return choice;

        }
        static void Main(string[] args)
        {
            StudentRecords RecordIt = new StudentRecords();
            

            Console.ReadKey();
        }

    }
}
