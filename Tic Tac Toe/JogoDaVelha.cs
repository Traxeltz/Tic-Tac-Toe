using System;

namespace JogoDaVelha
{
    // Programa Principal
    public class Jogo
    {
        public static void Main()
        {
            // Inserção de dados para o jogo
            bool entradasValidas = false;
            while (!entradasValidas) // Loop para reiniciar o programa em caso de erro
            {
                Console.Clear();
                Console.WriteLine("---JOGO DA VELHA---");

                try
                {
                    Console.WriteLine("\nJogador 1, insira seu nome!");
                    string nome1 = Console.ReadLine().Trim(); // Nome do jogador 1
                    if (string.IsNullOrWhiteSpace(nome1)) // Caso o nome não esteja correto
                        throw new ArgumentException("O nome não pode ser vazio. Por favor, insira um nome.");

                    Console.WriteLine("Escolha seu símbolo! (X ou O)");
                    char simbolo1 = char.Parse(Console.ReadLine().ToUpper().Trim()); // Símbolo do jogador 1
                    if (simbolo1 != 'X' && simbolo1 != 'O') // Caso o símbolo não esteja correto
                        throw new ArgumentException("O símbolo inserido não é válido. Por favor, insira um dos símbolos adequados.");

                    Console.WriteLine("\nJogador 2, insira seu nome!");
                    string nome2 = Console.ReadLine().Trim(); // Nome do jogador 2
                    if (string.IsNullOrWhiteSpace(nome2)) // Caso o nome não esteja correto
                        throw new ArgumentException("O nome não pode ser vazio. Por favor, insira um nome.");

                    char simbolo2;
                    if (simbolo1 == 'X') // Se esse símbolo for escolhido, o outro jogador tem o contrário
                        simbolo2 = 'O';
                    else // Se não é 'X', só pode ser 'O'
                        simbolo2 = 'X';

                    // Inicialização do Jogo
                    Player player1 = new Player1(nome1, simbolo1);
                    Player player2 = new Player2(nome2, simbolo2);
                    bool jogoFinalizado = false;

                    while (!jogoFinalizado) // Início do loop de rodadas do jogo
                    {
                        Player.InicializarTabuleiro(); // Inicializa o tabuleiro para uma nova partida

                        // Início do Loop do Jogo
                        while (true)
                        {
                            // Caso o Jogador 1 tenha escolhido o X
                            if (simbolo1 == 'X')
                            {
                                Player.ExibirTabuleiro();

                                // Jogador 1 irá jogar
                                player1.FazerJogada(); // Fazer a jogada se for válida

                                // Mostrar tabuleiro na situação atual
                                Player.ExibirTabuleiro();

                                if (player1.VerificarVitoria()) // Verificar se uma condição de vitória foi atingida
                                    break;
                                if (Player.VerificarVelha()) // Verificar se não é mais possível vencer
                                    break;

                                // Jogador 2 irá jogar
                                player2.FazerJogada(); // Fazer a jogada se for válida

                                // Mostrar tabuleiro na situação atual
                                Player.ExibirTabuleiro();

                                if (player2.VerificarVitoria()) // Verificar se uma condição de vitória foi atingida
                                    break;
                                if (Player.VerificarVelha()) // Verificar se não é mais possível vencer
                                    break;
                            }

                            // Caso o Jogador 2 tenha escolhido o X
                            if (simbolo2 == 'X')
                            {
                                Player.ExibirTabuleiro();

                                // Jogador 2 irá jogar
                                player2.FazerJogada(); // Fazer a jogada se for válida

                                // Mostrar tabuleiro na situação atual
                                Player.ExibirTabuleiro();

                                if (player2.VerificarVitoria()) // Verificar se uma condição de vitória foi atingida
                                    break;
                                if (Player.VerificarVelha()) // Verificar se não é mais possível vencer
                                    break;

                                // Jogador 1 irá jogar
                                player1.FazerJogada(); // Fazer a jogada se for válida

                                // Mostrar tabuleiro na situação atual
                                Player.ExibirTabuleiro();

                                if (player1.VerificarVitoria()) // Verificar se uma condição de vitória foi atingida
                                    break;
                                if (Player.VerificarVelha()) // Verificar se não é mais possível vencer
                                    break;
                            }
                        }

                        Console.WriteLine($"\n\t{player1.Pontuacao} - {player2.Pontuacao}");

                        char Opcao = ' ';
                        while (Opcao != 'S' && Opcao != 'N')
                        {
                            Console.Write("\nDeseja jogar mais uma partida? (S/N): ");
                            Opcao = char.Parse(Console.ReadLine().ToUpper().Trim());

                            if (Opcao == 'N')
                            {
                                jogoFinalizado = true;
                                entradasValidas = true;
                            }
                            else if (Opcao != 'S')
                                Console.WriteLine("Opção inválida!");
                        }
                    }
                }
                catch (ArgumentException Erro)
                {
                    Console.ResetColor();
                    Console.WriteLine($"\n{Erro.Message}");
                }
                catch (FormatException)
                {
                    Console.ResetColor();
                    Console.WriteLine("\nO valor inserido não é apropriado. Por favor, insira valores apropriados.");
                }
                catch (IndexOutOfRangeException)
                {
                    Console.ResetColor();
                    Console.WriteLine("\nEste valor para a coordenada não existe. Por favor, insira valores apropriados.");
                }
                catch (OverflowException)
                {
                    Console.ResetColor();
                    Console.WriteLine("\nO valor inserido está fora de contexto. Por favor, insira valores apropriados.");
                }
                catch (Exception Erro)
                {
                    Console.ResetColor();
                    Console.WriteLine($"\nOcorreu um erro inesperado: {Erro.Message}");
                }
                if (!entradasValidas)
                {
                    Console.WriteLine("Pressione qualquer tecla para reiniciar o programa.");
                    Console.ReadKey();
                }
            }

            // Encerramento do Código
            Console.Clear();
            Console.ResetColor();
            Console.WriteLine("Obrigado por jogar o Jogo da Velha!");
            Console.WriteLine("\nPressione qualquer tecla para sair do programa.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}