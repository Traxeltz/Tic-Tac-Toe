using System;

namespace TicTacToe
{
    public class Player1 : Player
    {
        public Player1(string name, char symbol) : base(name, symbol) { }

        public override void MakeMove(int row, int column)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            base.MakeMove(row, column);
        }

        public override bool CheckVictory()
        {
            if (base.CheckVictory())
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{Name} won Tic Tac Toe!");
                Score++;
                return true;
            }

            return false;
        }
    }
}