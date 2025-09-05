using System;

namespace TicTacToe
{
    public class Player2 : Player
    {
        public Player2(string name, char symbol) : base(name, symbol) { }

        public override void MakeMove(int row, int column)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            base.MakeMove(row, column);
        }

        public override bool CheckVictory()
        {
            if (base.CheckVictory())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{Name} won Tic Tac Toe!");
                Score++;
                return true;
            }

            return false;
        }
    }
}