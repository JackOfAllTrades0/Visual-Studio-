using Opponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Game
    {
        static void Main(string[] args)
        {
            const string X = "X";
            const string O = "O";
            string CurrentTurn;
            string player = "";
            string AI = "";
            string[] board = new string[9] {  "1", "2", "3" ,  "4", "5", "6" ,  "7", "8", "9"  };

            string[] acceptable = { "y", "n" , "yes" , "no"};
            bool decided = XO_AI.Challenge(acceptable);

            while (decided)
            {
                XO_AI opponent = new XO_AI(board);
                var recieved = opponent.Choose(X, O);
                player = recieved.Item1;
                AI = recieved.Item2;
                CurrentTurn = player;
                Console.WriteLine("Player : {0}, AI : {1}",player,AI + "\n");
                
                opponent.DisplayBoard();
                while (XO_AI.GameFinished == false)
                {
                    int count = 0;
                    if (CurrentTurn == player)
                    {

                        if (count > 0)
                        {
                            Console.Clear();
                        }
                        else count++;
                        Console.WriteLine("It is your turn");
                        opponent.PlMove(player);
                        CurrentTurn = AI;
                    }
                    else if (CurrentTurn == AI)
                    {
                        Console.Clear();
                        opponent.AiMove(player,AI);
                        CurrentTurn = player;
                    }
                    XO_AI.GameFinished = opponent.CheckVictory(player, AI);
                }
                break;
            }
            Console.WriteLine("See ya later !!!");
            Console.ReadKey();
        }
    }
}

