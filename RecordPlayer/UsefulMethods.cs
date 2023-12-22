using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Mystuff
{
    static class UsefulMethods
    {
        static StringBuilder YesOrNo(string message)
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

        public static string[] InputInLogs(string InputString, int NumInputs)
        {
            string[] outValues = new string[NumInputs];
            List<string> SubStrings = InputString.Split('~').ToList(); // Splits the inputted string at points when the '~' character appears and creates a list out of it
            for (int i = 0; i < SubStrings.Count; i++) // Loops through substring list
            {
                Console.Write($"{SubStrings[i]}: "); // Prints each substring
                string TempAnswer = Console.ReadLine();// gets answer
                outValues[i] = TempAnswer; // adds answer to a list
            }
            return outValues; 
        }

        public static Tuple<int, int, int> FileTextChunkInfo(string filename, string startText, string EndText)
        {
            Tuple<int, int, int> ReturnTuple;
            try 
            {
                using (StreamReader sr = new StreamReader(filename))
                {
                    string line;
                    int LinesInFile = 0;
                    int ChunkStart = 0;
                    int ChunkEnd = 0;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line == startText)
                        {
                            ChunkStart = LinesInFile;
                        }
                        else if (line == EndText)
                        {
                            ChunkEnd = LinesInFile;
                        }
                        LinesInFile++;
                    }
                    return ReturnTuple = Tuple.Create(LinesInFile, ChunkStart, ChunkEnd);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Sorr, couldn't access file");
                Console.WriteLine(e.Message);    
            }
            return null;
       
        }

        public static void ReplaceFileContent (string Sfilename, string Tfilename, string startText, string EndText, object[] contents )
        {
            try
            {
                using (StreamReader sr = new StreamReader(Sfilename))
                {
                    Tuple<int, int, int> FileInfo = FileTextChunkInfo(Sfilename, startText, EndText);
                    int FileLength = FileInfo.Item1;
                    int StartPoint = FileInfo.Item2;
                    int Duration = FileInfo.Item3 - FileInfo.Item2;
                    
                    string line;
                    int IntoFile = 0;
                    
                    using (StreamWriter sw = new StreamWriter(Tfilename))
                    {
                        while ((line = sr.ReadLine()) != null)
                        {
                            if (IntoFile != StartPoint)
                            {
                                sw.WriteLine(line);
                            }
                            else if (IntoFile == StartPoint)
                            {
                                foreach(var item in contents)
                                {
                                    sw.WriteLine(startText + ":");
                                    sw.WriteLine("-" + item);
                                    sw.Write(EndText + "\n-");
                                }
                            }
                            IntoFile++;
                        }
                    }
                }
               
            }
            catch (Exception ex)
            {
                Console.WriteLine("Sorry, I couldn't find the file you were looking for");
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
