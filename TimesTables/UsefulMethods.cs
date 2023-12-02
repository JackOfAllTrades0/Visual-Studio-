using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimesTable
{
    public static class UsefulMethods
    {
        public static StringBuilder YesOrNo(string message)
        {
            string[] ValidAns = { "y", "n", "yes", "no", "yeah", "nah" }; // Array of allowed responses
            StringBuilder answer = new StringBuilder("",20); // Creates a editable string of 20 characters (more memory efficient)
            int count = 0; // sets the count to 0
            do 
            {
                switch (count)
                {
                    case 0: // if the count is o the user gets normal message
                        Console.Write($"{message}?: "); // prints the question
                        string Stranswer = Console.ReadLine().ToLower(); // recievce user input and converts it to lower
                        answer.Insert(0, Stranswer); // adds their answer to the string builder
                        count = 1; // sets count to one forever
                        break;
                    case 1: // if the count is 1 the get the corrective message
                        answer.Clear(); // clears the stringbuilder of text
                        Console.Write($"Try again, {message}: "); // prints message
                        Stranswer =  Console.ReadLine().ToLower(); // reads input and converts it to lower case
                        answer.Insert(0, Stranswer);// adds their answer to the string builder
                        break;

                }
                

            }while(!ValidAns.Any(s=>s.Equals(answer.ToString()))); // while the answer isn't in the valid list the loop loops
            return answer;

        }
    }
}
