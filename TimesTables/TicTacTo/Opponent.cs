using System;
using System.Collections;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Opponent
{
    class XO_AI
    {
        private string[] aiBoard;
        private string[] Pieces = { "X", "O", "x", "o" };
        private int[,] WinCombos = { { 7, 8, 9 }, { 4, 5, 6 }, { 1, 2, 3 }, { 7, 4, 1 }, { 8, 5, 2 }, { 9, 6, 3 }, { 7 ,5, 3 }, { 9, 5, 1 } };
        public static bool GameFinished = false;

        


        public XO_AI(string[] Argboard)
        {
            aiBoard = Argboard;

        }

        public void DisplayBoard() 
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", aiBoard[6], aiBoard[7], aiBoard[8]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", aiBoard[3], aiBoard[4], aiBoard[5]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", aiBoard[0], aiBoard[1], aiBoard[2]);
            Console.WriteLine("     |     |      ");

        }

        public static bool Challenge(string[] Acceptable)
        {
            string Play = "";
            int repeat = 0;


            while (!Acceptable.Any(s => Play.Equals(s)))
            {

                if (repeat <= 0)
                {
                    Console.Write("Welcome, would you like to play noughts and crosses?: ");
                    Play = Console.ReadLine();
                }
                else if (repeat > 0)
                {
                    Console.Write("No, try again. Would you like to play?: ");
                    Play = Console.ReadLine();
                }
                repeat++;
            }
            if (Play.ToLower() == "n" || Play.ToLower() == "no")
            {
                Console.WriteLine("You're no fun" + "\n");
                return false;
            }
            if (Play.ToLower() == "y" || Play.ToLower() == "yes")
            {
                Console.WriteLine("Yes!!, you shall meet your doom" + "\n");
                return true;
            }
            return false;
        }

        public Tuple<string, string> Choose(string Cross, string Nought) // Creates a method with a Tuple [(string,string)] return type
        {
            var pieceTup = Tuple.Create(Cross, Nought);// creates a Tuple with two string values
            string choice = "";
            while (!Pieces.Any(s => choice.Equals(s)))
            {
                Console.Write("Which would you like to be ? (X or O): ");
                choice = Console.ReadLine();
            }
            if (choice == "X" || choice == "x")
            {
                Console.WriteLine("\n" + "Very well then: ");
                return pieceTup; // returns the tuple

            }
            if (choice == "O" || choice == "o")
            {
                Console.WriteLine("\n" + "Not what I would've chosen: ");
                pieceTup = Tuple.Create(Nought, Cross);
            }
            return pieceTup;
        }

        private bool ThrowErrorPlMove(int choice)
        {
            if (Enumerable.Range(0, 10).Contains(choice))
                if (aiBoard[choice - 1] == "X" || aiBoard[choice - 1] == "O")
                    return false;
                else return true;
            else return false;
       
        }
        public void PlMove(string symbol)
        {
            
            int chosensquare;
            int count = 0;
            do
            {
                if (count > 0)
                {
                    Console.Write("Nope, try again. ");
                    count = 1;
                }
                Console.Write("Where would you like to move? : ");
                string chosesquare = Console.ReadLine();
                while (!(int.TryParse(chosesquare, out chosensquare)))
                { 
                    Console.Write("Error, erroneous input, try again: "); 
                    chosesquare = Console.ReadLine();
                }
                chosensquare = int.Parse(chosesquare);
                count = 1;
            }
            while (ThrowErrorPlMove(chosensquare) == false);

            aiBoard[chosensquare - 1] = symbol;
            DisplayBoard();
           
          
            
        }

        //public ArrayList PosMoves()
        //{
         //   int Move;
         //   ArrayList PossibleMoves = new ArrayList();
          //  foreach (string item in aiBoard)
          //  {
          //      if (item.ToLower() != "x" || item.ToLower() != "o")
           //     {
           //         PossibleMoves.Add(Convert.ToInt32(item));
           //     }
           //     else continue;
                
          //  }
           // return PossibleMoves;
       // }

        public void AiMove(string PLsymbol, string Aisymbol )
        {
            bool MoveChosen = false;
          
            do
            {
                Random r = new Random();
                int move = r.Next(0, 9);
                if (aiBoard[move] == PLsymbol || aiBoard[move] == Aisymbol)
                {
                    continue;
                }
                else 
                {
                    aiBoard[move] = Aisymbol;
                    MoveChosen = true;
                }


            } while (MoveChosen == false);
            DisplayBoard(); 
       
        }

        public bool CheckVictory(string Pltype,string Aitype )
        {

            for (int i = 0; i < WinCombos.GetLength(0); i++)
            {
                //Checks if the player has won
                if ((aiBoard[WinCombos[i, 0] - 1] == aiBoard[WinCombos[i, 1] - 1]) && (aiBoard[WinCombos[i, 2] - 1] == aiBoard[WinCombos[i,1]]) && (aiBoard[WinCombos[i,1]] == Pltype))
                {

                    Console.WriteLine("You Have beaten me, Well done");
                    return true;
                }
                //checks if the Ai has won
                else if ((aiBoard[WinCombos[i, 0] - 1] == aiBoard[WinCombos[i, 1] - 1]) && (aiBoard[WinCombos[i, 2] - 1] == aiBoard[WinCombos[i, 1]]) && (aiBoard[WinCombos[i, 1]] == Aitype))
                {

                    Console.WriteLine("Good try, but it is I who have triumphed");
                    return true;

                }
                
            }
            // Checks for a draw
            if ((aiBoard.All(s => s.Equals(Pltype) || s.Equals(Aitype))) && GameFinished == false)
            {
                Console.WriteLine("The Match has ended in a draw, fair play");
                return true;
            }
            return false;

        }

    }
}
