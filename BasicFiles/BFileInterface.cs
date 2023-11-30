using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TimesTable;
using System.Text.RegularExpressions;

namespace Files
{
    public class MainProg
    {
        static string DisplayMenu()
        {
            string[] allowed = {"1","2","3","4","5"};
            string choice;
            Console.WriteLine(@"
1. Input data and save to 'StudentRecord.txt' file
2. Clear the 'StudentRecord.txt' file
3. Calculate and display average mark
4. Display the data
5. Quit
            ");
            do
            {
                Console.Write("Which option do you chose?: ");
                choice = Console.ReadLine();

            } while (!allowed.Any(choice.Equals));
            return choice;

        }

        static void saveToFile()
        {
            StreamWriter sw = new StreamWriter("StudentRecord.txt", append:true);
            string studentName;
            int studentMark;
            string Response;
            string[] Validyes = { "y", "yeah", "yes"};
            string[] Validno = { "no", "n", "nah" };
            do
            {
                Console.Write("What is the student's Name?: ");
                studentName = Console.ReadLine();
                Console.Write("What is the student's Mark?: ");
                studentMark = Convert.ToInt32(Console.ReadLine());

                sw.WriteLine(studentName + "," + studentMark.ToString());
                Response = AskandVerify.YesOrNo("Would you like to Continue").ToString();
                
            } while (Validyes.Any(Response.Equals) && !Validno.Any(Response.Equals));

            sw.Close();

        }

        static void ClearFile()
        {
            using (StreamWriter sw = new StreamWriter("StudentRecord.txt", false))
            {
                sw.WriteLine("");
            }

            
        }

        static double CalcMean()
        {
            StreamReader sr = new StreamReader("StudentRecord.txt");
            double total = 0;
            double count = 0;
            int startfromtop = 0;
            while (sr.ReadLine() != null)
            {
                if (startfromtop == 0)
                {
                    sr.DiscardBufferedData();
                    sr.BaseStream.Seek(0, SeekOrigin.Begin);
                }
                else 
                {
                    string student = sr.ReadLine(); 
                    double score = Convert.ToDouble(Regex.Match(student , @"\d+"));
                    total += score;
                    count++;
                }
            }
            sr.Close();
            return total / count;
        }

        static void DisplayData()
        {
            StreamReader sr = new StreamReader("StudentRecord.txt");
            int count = 0;

            Console.WriteLine("Here is the list of students: ");

            while (sr.ReadLine() != null)
            {
                if (count == 0)
                {
                    sr.DiscardBufferedData();
                    sr.BaseStream.Seek(0, SeekOrigin.Begin);
                }
                else 
                {
                    Console.WriteLine(sr.ReadLine());
                }
                count++;
            }

            sr.Close() ;
        }

        
        static void Main(string[] args)
        {
            string choice = DisplayMenu();

            while (choice != "5") 
            {
                if (choice == "1")
                {
                    saveToFile();
                }
                else if (choice == "2")
                {
                    ClearFile();
                }
                else if (choice == "3")
                {
                    Console.WriteLine(CalcMean());
                }
                else if (choice == "4")
                {
                    DisplayData();
                }

                choice = DisplayMenu();
            }
            Console.WriteLine("You Have chosen to quit, Goodbye");
            Console.ReadKey();
          
            
        }
    }
}
