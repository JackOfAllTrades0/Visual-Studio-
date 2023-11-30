using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checker;

namespace ConApp
{
    public class MainProg
    {
        static void Main(string[] args)
        {
            CheckPassword check = new CheckPassword();
            string attempt1 = "";
            string attempt2 = "";
            do
            {
                attempt1 = check.GetPword(1);
                attempt2 = check.GetPword(2);


            } while (attempt1 != attempt2);

            Console.WriteLine("Access Granted");

            Console.ReadKey();
        }
    }
}
