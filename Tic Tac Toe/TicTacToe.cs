using System;

namespace TicTacToe
{
    // Main Program
    public class Game
    {
        public static void RunGame(Player playerX, Player playerO)
        {
            // Start Game Loop
            while (true)
            {
                // Player 'X' will play
                playerX.MakeMove(); // Make the move if valid

                // Show board in current state
                Player.DisplayBoard();

                // Check if a stop condition has been reached
                if (playerX.CheckVictory() || Player.CheckDraw())
                    break;

                // Player 'O' will play
                playerO.MakeMove(); // Make the move if valid

                // Show board in current state
                Player.DisplayBoard();

                // Check if a stop condition has been reached
                if (playerO.CheckVictory() || Player.CheckDraw())
                    break;
            }
        }

        public static void Main()
        {
            // Data input for the game
            bool validInputs = false;
            while (!validInputs) // Loop to restart the program in case of error
            {
                Console.Clear();
                Console.WriteLine("---TIC TAC TOE---");

                try
                {
                    Console.WriteLine("\nPlayer 1, enter your name!");
                    string name1 = Console.ReadLine().Trim(); // Player 1 name
                    if (string.IsNullOrWhiteSpace(name1)) // If the name is not correct
                        throw new ArgumentException("Name cannot be empty. Please enter a name.");

                    Console.WriteLine("Choose your symbol! (X or O)");
                    char symbol1 = char.Parse(Console.ReadLine().ToUpper().Trim()); // Player 1 symbol
                    if (symbol1 != 'X' && symbol1 != 'O') // If the symbol is not correct
                        throw new ArgumentException("The entered symbol is not valid. Please enter one of the appropriate symbols.");

                    Console.WriteLine("\nPlayer 2, enter your name!");
                    string name2 = Console.ReadLine().Trim(); // Player 2 name
                    if (string.IsNullOrWhiteSpace(name2)) // If the name is not correct
                        throw new ArgumentException("Name cannot be empty. Please enter a name.");

                    char symbol2;
                    if (symbol1 == 'X') // If this symbol is chosen, the other player gets the opposite
                        symbol2 = 'O';
                    else // If not 'X', it can only be 'O'
                        symbol2 = 'X';

                    // Game Initialization
                    Player player1 = new Player1(name1, symbol1);
                    Player player2 = new Player2(name2, symbol2);
                    bool gameFinished = false;

                    while (!gameFinished) // Start of game rounds loop
                    {
                        Player.InitializeBoard(); // Initializes the board for a new match
                        Player.DisplayBoard(); // Displays the board on the screen

                        if (player1.Symbol == 'X') // If Player 1 chose X
                            RunGame(player1, player2);
                        else // Otherwise, Player 2 has X
                            RunGame(player2, player1);

                        // Display current score
                        Console.WriteLine($"\n\t{player1.Score} - {player2.Score}");

                        char Option = ' ';
                        while (Option != 'Y' && Option != 'N')
                        {
                            Console.Write("\nDo you want to play another match? (Y/N): ");
                            Option = char.Parse(Console.ReadLine().ToUpper().Trim());

                            if (Option == 'N')
                            {
                                gameFinished = true;
                                validInputs = true;
                            }
                            else if (Option != 'Y')
                                Console.WriteLine("Invalid option!");
                        }
                    }
                }
                catch (ArgumentException Error)
                {
                    Console.ResetColor();
                    Console.WriteLine($"\n{Error.Message}");
                }
                catch (FormatException)
                {
                    Console.ResetColor();
                    Console.WriteLine("\nThe entered value is not appropriate. Please enter appropriate values.");
                }
                catch (IndexOutOfRangeException)
                {
                    Console.ResetColor();
                    Console.WriteLine("\nThis value for the coordinate does not exist. Please enter appropriate values.");
                }
                catch (OverflowException)
                {
                    Console.ResetColor();
                    Console.WriteLine("\nThe entered value is out of context. Please enter appropriate values.");
                }
                catch (Exception Error)
                {
                    Console.ResetColor();
                    Console.WriteLine($"\nAn unexpected error occurred: {Error.Message}");
                }
                if (!validInputs)
                {
                    Console.WriteLine("Press any key to restart the program.");
                    Console.ReadKey();
                }
            }

            // End of Code
            Console.Clear();
            Console.ResetColor();
            Console.WriteLine("Thank you for playing Tic Tac Toe!");
            Console.WriteLine("\nPress any key to exit the program.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}