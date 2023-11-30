using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Checker
{
    public class CheckPassword
    {
        public CheckPassword() 
        {
            
        }

        public string GetPword(int attempt)
        {
            switch (attempt)
            {
                case 1:
                    string Pass1 = "";
                    do
                    {
                        Console.Write("Enter your password: ");
                        Pass1 = Console.ReadLine();
               

                    } while (!(Pass1.Length > 6 && Pass1.Length <= 8));
                    return Pass1;
                    
                case 2:
                    Console.Write("Renter your password: ");
                    string Pass2 = Console.ReadLine();
                    return Pass2;

                default:
                    return "";
            }
           
        }
    }
}
