using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;

namespace TimesTable
{
    static class ReadScore
    {
        static void Read()
        {
            try
            {
                using (StreamReader sr = new StreamReader("HighScores.txt"))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }catch (Exception ex)
            {
                Console.WriteLine("Sorry, this file could not be read: ");
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }

    }

    static class StoreScore
    {
        static void Store(int[] HighScores)
        {

            using (StreamWriter sw = new StreamWriter("HighScores.txt"))
            {
                sw.WriteLine();
            }
            
        }
        

        
    }
    
}
