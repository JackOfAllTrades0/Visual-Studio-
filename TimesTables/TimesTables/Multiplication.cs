using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimesTable
{
    public class Multiplication
    {
        private static bool AllorElse; // True = All ; False = Else (User defines which times tables)
        public int[] Numbers = { }; // holds which numbers the user would like to practice
        private static int NumRounds; // holds the number of rounds the user would like to play for
        private int[,] DiffHeirarchy = { { 2, 5, 10 }, { 3, 9, 11 }, { 4, 6, 8 }, { 7, 12 ,13} }; // left to right, easiest to hardest

        public Multiplication(bool AallorElse , int AnumRounds)
        {
            AllorElse = AallorElse;
            NumRounds = AnumRounds;
            int[] tempnums = { }; // temporary array that holds the times tables
            
            if (AllorElse = false) // Runs if the user wishes to define which times tables they would like to practice
            {
                StringBuilder Remove; // StringBuilder which hold the users input (yes or no)
                Console.WriteLine("Which Times Tables would you like to practice?: ");
                for (int i = 2; i < 14; i++)
                {
                    Remove =  AskandVerify.YesOrNo(i.ToString());
                    if (Remove.ToString() == "y" || Remove.ToString() == "yes" || Remove.ToString() == "yeah") 
                    {
                        tempnums[i - 2] = i; // if the user wants to practice the times table it is added to an array 
                    }
                    else { continue; }

                }
                Numbers = tempnums; // assigns the temporary local array to the global array
            }
        }

        public void RoundGenerationAll()
        {
            int Num;
            int Multiplier;
            int answer;
            Random RnNum = new Random();
            Random RnMultiplier = new Random();
            Random RnDifficulty = new Random(); 

            for (int i = 0; i <= NumRounds; i++)
            {

                if (i <= 0 && i < (NumRounds / 4))
                {
                    Console.WriteLine($"Round {i + 1}: ");
                    for (int j = 0; j < 6; j++)
                    {
                        Num = DiffHeirarchy[RnDifficulty.Next(0,2), RnNum.Next(0,3) ];
                        Multiplier = RnMultiplier.Next(0,14);
                        Console.Write("{0} x {1} = ", Num, Multiplier );
                        answer = Convert.ToInt32(Console.ReadLine());
                        if (answer == Num * Multiplier)
                        {
                            Console.WriteLine("Correct", "\n");
                        }
                        else { Console.WriteLine("Incorrect!");}

                    }
                } // Easy rounds (sub arrays 1 and 2)

                if (i <= (NumRounds/4) && i < (NumRounds / 2))
                {
                    Console.WriteLine($"Round {i + 1}: ");
                    for (int j = 0; j < 6; j++)
                    {
                        Num = DiffHeirarchy[RnDifficulty.Next(1, 3), RnNum.Next(0, 3)];
                        Multiplier = RnMultiplier.Next(0, 14);
                        Console.Write("{0} x {1} = ", Num, Multiplier);
                        answer = Convert.ToInt32(Console.ReadLine());
                        if (answer == Num * Multiplier)
                        {
                            Console.WriteLine("Correct", "\n");
                        }
                        else { Console.WriteLine("Incorrect!"); }

                    }
                } // Medium rounds (sub arrays 2 and 3)

                if (i <= (NumRounds/2) && i < (3*(NumRounds) / 4))
                {
                    Console.WriteLine($"Round {i + 1}: ");
                    for (int j = 0; j < 6; j++)
                    {
                        Num = DiffHeirarchy[RnDifficulty.Next(2, 4), RnNum.Next(0, 3)];
                        Multiplier = RnMultiplier.Next(0, 14);
                        Console.Write("{0} x {1} = ", Num, Multiplier);
                        answer = Convert.ToInt32(Console.ReadLine());
                        if (answer == Num * Multiplier)
                        {
                            Console.WriteLine("Correct", "\n");
                        }
                        else { Console.WriteLine("Incorrect!"); }

                    }
                } // Hard rounds (Sub arrays 3 and 4)

                if (i <= (3 * (NumRounds) / 4) && i <= NumRounds )
                {
                    Console.WriteLine($"Round {i + 1}: ");
                    for (int j = 0; j < 6; j++)
                    {
                        Num = DiffHeirarchy[RnDifficulty.Next(3, 4), RnNum.Next(0, 3)];
                        Multiplier = RnMultiplier.Next(0, 14);
                        Console.Write("{0} x {1} = ", Num, Multiplier);
                        answer = Convert.ToInt32(Console.ReadLine());
                        if (answer == Num * Multiplier)
                        {
                            Console.WriteLine("Correct", "\n");
                        }
                        else { Console.WriteLine("Incorrect!"); }

                    }
                } // Super Hard rounds (Sub array 4)

            }
        }

    }


}
