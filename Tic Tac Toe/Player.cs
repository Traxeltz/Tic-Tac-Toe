using System;

namespace TicTacToe
{
    // Board Operations Program
    public abstract class Player
    {
        // Internal Board Reading
        private static readonly char[,] Board = new char[3, 3];
        protected string Name { get; }
        public char Symbol { get; }
        public int Score { get; set; }

        // Board Construction
        public Player(string name, char symbol)
        {
            Name = name;
            Symbol = symbol;
            Score = 0;
        }
        
        // Initialize Board with Empty Characters
        public static void InitializeBoard()
        {
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                    Board[i, j] = ' ';
            }
        }

        // Display Board on Screen
        public static void DisplayBoard()
        {
            Console.Clear();
            Console.ResetColor();
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    Console.Write(" " + Board[i, j] + " ");
                    if (j < Board.GetLength(1) - 1)
                        Console.Write('|');
                }
                Console.WriteLine();
                if (i < Board.GetLength(0) - 1)
                    Console.Write("-----------");
            }
            Console.WriteLine();
        }

        // Make a move by a player
        public virtual void MakeMove(int row = 0, int column = 0)
        {
            Console.WriteLine($"{Name}, enter the coordinates of your move!");
            do
            {
                Console.Write("Row: ");
                row = int.Parse(Console.ReadLine().Trim());
                Console.Write("Column: ");
                column = int.Parse(Console.ReadLine().Trim());
                if (Board[row - 1, column - 1] != ' ') // Check if the cell is empty
                    Console.WriteLine("\nThis cell is already filled. Enter coordinates for an empty cell!\n");
            }
            while (Board[row - 1, column - 1] != ' ');
            Board[row - 1, column - 1] = Symbol; // Fill the board with the player's symbol
        }

        // Check if any player has won the game
        public virtual bool CheckVictory()
        {
            // Check Rows and Columns
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                if (Board[i, 0] == Symbol && Board[i, 1] == Symbol && Board[i, 2] == Symbol)
                    return true; // Complete row
                if (Board[0, i] == Symbol && Board[1, i] == Symbol && Board[2, i] == Symbol)
                    return true; // Complete column
            }

            // Check Diagonals
            if (Board[0, 0] == Symbol && Board[1, 1] == Symbol && Board[2, 2] == Symbol)
                return true; // Main diagonal complete
            if (Board[0, 2] == Symbol && Board[1, 1] == Symbol && Board[2, 0] == Symbol)
                return true; // Secondary diagonal complete

            return false; // No one has won yet
        }

        // Check if there is no more possibility to win
        public static bool CheckDraw()
        {
            foreach (char square in Board) // Check each cell of the board
            {
                if (square == ' ') // If empty
                    return false; // Still possible to play
            }

            Console.WriteLine("It's a draw!");
            Console.WriteLine("No one won!");
            return true; // Draw
        }

        #if DEBUG
        ~Player()
        {
            Console.WriteLine($"\nPlayer {Name} destroyed.");
        }
        #endif
    }
}