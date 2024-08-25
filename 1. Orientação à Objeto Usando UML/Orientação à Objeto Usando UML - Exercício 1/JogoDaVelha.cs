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
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("---JOGO DA VELHA---");

                try
                {
                    Console.WriteLine("\nJogador 1, insira seu nome!");
                    string nome1 = Console.ReadLine().Trim(); // Nome do jogador 1
                    if (string.IsNullOrWhiteSpace(nome1)) // Caso o nome não esteja correto
                    {
                        throw new ArgumentException("O nome não pode ser vazio. Por favor, insira um nome.");
                    }
                    Console.WriteLine("Escolha seu símbolo! (X ou O)");
                    char simbolo1 = char.Parse(Console.ReadLine().ToUpper().Trim()); // Símbolo do jogador 1
                    if (simbolo1 != 'X' && simbolo1 != 'O') // Caso o símbolo não esteja correto
                    {
                        throw new ArgumentException("O símbolo inserido não é válido. Por favor, insira um dos símbolos adequados.");
                    }
                    Console.WriteLine("\nJogador 2, insira seu nome!");
                    string nome2 = Console.ReadLine().Trim(); // Nome do jogador 2
                    if (string.IsNullOrWhiteSpace(nome2)) // Caso o nome não esteja correto
                    {
                        throw new ArgumentException("O nome não pode ser vazio. Por favor, insira um nome.");
                    }
                    char simbolo2 = ' ';
                    if (simbolo1 == 'X') // Se esse símbolo for escolhido, o outro jogador tem o contrário
                    {
                        simbolo2 = 'O';
                    }
                    else if (simbolo1 == 'O') // Se esse símbolo for escolhido, o outro jogador tem o contrário
                    {
                        simbolo2 = 'X';
                    }

                    // Inicialização do Jogo
                    bool jogoFinalizado = false;
                    int pontuacao1 = 0;
                    int pontuacao2 = 0;
                    while (!jogoFinalizado) // Início do loop de rodadas do jogo
                    {
                        Tabuleiro tabuleiro = new Tabuleiro();
                        int linha;
                        int coluna;

                        // Início do Loop do Jogo
                        while (true)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.White;
                            tabuleiro.ExibirTabuleiro(); // Mostrar tabuleiro pela primeira vez

                            // Caso o Jogador 1 tenha escolhido o X
                            if (simbolo1 == 'X')
                            {
                                // Jogador 1 irá jogar
                                do
                                {
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    Console.WriteLine($"{nome1}, insira as coordenadas da sua jogada!");
                                    Console.Write("Linha: ");
                                    linha = int.Parse(Console.ReadLine().Trim());
                                    Console.Write("Coluna: ");
                                    coluna = int.Parse(Console.ReadLine().Trim());
                                    if (tabuleiro.QuadradoPreenchido(linha, coluna)) // Verificar se a casa está vazia
                                    {
                                        Console.WriteLine("\nEsta casa já foi preenchida. Insira uma coordenada para uma casa vazia!\n");
                                        continue;
                                    }
                                }
                                while (tabuleiro.QuadradoPreenchido(linha, coluna));
                                tabuleiro.FazerJogada(linha, coluna, simbolo1); // Fazer a jogada se for válida

                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.White;
                                tabuleiro.ExibirTabuleiro(); // Mostrar tabuleiro na situação atual

                                if (tabuleiro.VerificarVitoria(simbolo1)) // Verificar se uma condição de vitória foi atingida
                                {
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    Console.WriteLine($"{nome1} venceu o Jogo da Velha!");
                                    pontuacao1++;
                                    break;
                                }
                                if (tabuleiro.VerificarVelha()) // Verificar se não é mais possível vencer
                                {
                                    Console.WriteLine("Deu velha!\nNinguém venceu!");
                                    break;
                                }

                                // Jogador 2 irá jogar
                                do
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine($"{nome2}, insira as coordenadas da sua jogada!");
                                    Console.Write("Linha: ");
                                    linha = int.Parse(Console.ReadLine().Trim());
                                    Console.Write("Coluna: ");
                                    coluna = int.Parse(Console.ReadLine().Trim());
                                    if (tabuleiro.QuadradoPreenchido(linha, coluna)) // Verificar se a casa está vazia
                                    {
                                        Console.WriteLine("\nEsta casa já foi preenchida. Insira uma coordenada para uma casa vazia!\n");
                                        continue;
                                    }
                                }
                                while (tabuleiro.QuadradoPreenchido(linha, coluna));
                                tabuleiro.FazerJogada(linha, coluna, simbolo2); // Fazer a jogada se for válida

                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.White;
                                tabuleiro.ExibirTabuleiro(); // Mostrar tabuleiro na situação atual

                                if (tabuleiro.VerificarVitoria(simbolo2)) // Verificar se uma condição de vitória foi atingida
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine($"{nome2} venceu o Jogo da Velha!");
                                    pontuacao2++;
                                    break;
                                }
                                if (tabuleiro.VerificarVelha()) // Verificar se não é mais possível vencer
                                {
                                    Console.WriteLine("Deu velha!\nNinguém venceu!");
                                    break;
                                }
                            }

                            // Caso o Jogador 2 tenha escolhido o X
                            if (simbolo2 == 'X')
                            {
                                // Jogador 2 irá jogar
                                do
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine($"{nome2}, insira as coordenadas da sua jogada!");
                                    Console.Write("Linha: ");
                                    linha = int.Parse(Console.ReadLine().Trim());
                                    Console.Write("Coluna: ");
                                    coluna = int.Parse(Console.ReadLine().Trim());
                                    if (tabuleiro.QuadradoPreenchido(linha, coluna)) // Verificar se a casa está vazia
                                    {
                                        Console.WriteLine("\nEsta casa já foi preenchida. Insira uma coordenada para uma casa vazia!\n");
                                        continue;
                                    }
                                }
                                while (tabuleiro.QuadradoPreenchido(linha, coluna));
                                tabuleiro.FazerJogada(linha, coluna, simbolo2); // Fazer a jogada se for válida

                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.White;
                                tabuleiro.ExibirTabuleiro(); // Mostrar tabuleiro na situação atual

                                if (tabuleiro.VerificarVitoria(simbolo2)) // Verificar se uma condição de vitória foi atingida
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine($"{nome2} venceu o Jogo da Velha!");
                                    pontuacao2++;
                                    break;
                                }
                                if (tabuleiro.VerificarVelha()) // Verificar se não é mais possível vencer
                                {
                                    Console.WriteLine("Deu velha!\nNinguém venceu!");
                                    break;
                                }

                                // Jogador 1 irá jogar
                                do
                                {
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    Console.WriteLine($"{nome1}, insira as coordenadas da sua jogada!");
                                    Console.Write("Linha: ");
                                    linha = int.Parse(Console.ReadLine().Trim());
                                    Console.Write("Coluna: ");
                                    coluna = int.Parse(Console.ReadLine().Trim());
                                    if (tabuleiro.QuadradoPreenchido(linha, coluna)) // Verificar se a casa está vazia
                                    {
                                        Console.WriteLine("\nEsta casa já foi preenchida. Insira uma coordenada para uma casa vazia!\n");
                                        continue;
                                    }
                                }
                                while (tabuleiro.QuadradoPreenchido(linha, coluna));
                                tabuleiro.FazerJogada(linha, coluna, simbolo1); // Fazer a jogada se for válida

                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.White;
                                tabuleiro.ExibirTabuleiro(); // Mostrar tabuleiro na situação atual

                                if (tabuleiro.VerificarVitoria(simbolo1)) // Verificar se uma condição de vitória foi atingida
                                {
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    Console.WriteLine($"{nome1} venceu o Jogo da Velha!");
                                    pontuacao1++;
                                    break;
                                }
                                if (tabuleiro.VerificarVelha()) // Verificar se não é mais possível vencer
                                {
                                    Console.WriteLine("Deu velha!\nNinguém venceu!");
                                    break;
                                }
                            }
                        }
                        Console.WriteLine($"\n\t{pontuacao1} - {pontuacao2}");
                        char Opcao = ' ';
                        while (Opcao != 'S' && Opcao != 'N')
                        {
                            Console.Write("\nDeseja jogar mais uma partida? (S/N): ");
                            Opcao = char.Parse(Console.ReadLine().ToUpper().Trim());
                            switch (Opcao)
                            {
                                case 'S':
                                    break;
                                case 'N':
                                    jogoFinalizado = true;
                                    break;
                                default:
                                    Console.WriteLine("Opção inválida!");
                                    break;
                            }
                        }
                    }
                    // Final do Loop do Jogo
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\nObrigado por jogar o Jogo da Velha!");
                    entradasValidas = true;
                }
                catch (ArgumentException Erro)
                {
                    Console.ResetColor();
                    Console.WriteLine($"\n{Erro.Message}");
                    Console.WriteLine("Pressione qualquer tecla para reiniciar o programa.");
                    Console.ReadKey();
                    Console.Clear();
                    GC.Collect();
                    continue;
                }
                catch (FormatException)
                {
                    Console.ResetColor();
                    Console.WriteLine("\nO valor inserido não é apropriado. Por favor, insira valores apropriados.");
                    Console.WriteLine("Pressione qualquer tecla para reiniciar o programa.");
                    Console.ReadKey();
                    Console.Clear();
                    GC.Collect();
                    continue;
                }
                catch (IndexOutOfRangeException)
                {
                    Console.ResetColor();
                    Console.WriteLine("\nEste valor para a coordenada não existe. Por favor, insira valores apropriados.");
                    Console.WriteLine("Pressione qualquer tecla para reiniciar o programa.");
                    Console.ReadKey();
                    Console.Clear();
                    GC.Collect();
                    continue;
                }
            }

            // Encerramento do Código
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("Este programa chegou ao final. Para fechá-lo, pressione qualquer tecla.");
            Console.ReadKey();
        }
    }
}