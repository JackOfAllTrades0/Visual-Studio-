using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time
{
    public class TimeInterface
    {
        static int DisplayOptions()
        {
            string Stranswer = "";
            int answer = 0;
            do
            {
                Console.WriteLine(@"What Would You Like to do?:
1) Write an entry to the file
2) Read an entry from the file");
                Stranswer = Console.ReadLine();
                if (int.TryParse(Stranswer, out int n))
                {
                    answer = n;
                }
                else { continue; }

            } while (!Enumerable.Range(1, 3).Contains(answer));

            return answer;
        }

        static string AskName()
        {
            Console.Write("What is your name?: ");
            return Console.ReadLine();
        }

        static void Main(string[] args)
        {

            DateTime Clock = new DateTime.Now.ToString("dddd:MMMM:yyyy - HH:mm:ss tt");
            int choice = 0;
            TimeFilingSystem Files = new TimeFilingSystem(Clock, AskName());
            do
            {
                choice = DisplayOptions();
                if (choice == 1)
                {
                    Console.WriteLine("Writting Name To File... ");
                    Files.WriteTimeFile();
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Printing Contents of File... ");
                    Files.ReadTimeFile();  
                }
            }
        }
    }
}
