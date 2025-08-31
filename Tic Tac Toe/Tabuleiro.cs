using System;

namespace JogoDaVelha
{
    // Programa de Operações do Tabuleiro
    public abstract class Player
    {
        // Leitura Interna do Tabuleiro
        protected static char[,] quadrados = new char[3, 3];
        protected string Nome { get; }
        protected char Simbolo { get; }
        public int Pontuacao = 0;

        // Construção do Tabuleiro
        public Player(string nome, char simbolo)
        {
            Nome = nome;
            Simbolo = simbolo;
        }
        
        // Inicialização do Tabuleiro com Caracteres Vazios
        public void InicializarTabuleiro()
        {
            for (int i = 0; i < quadrados.GetLength(0); i++)
            {
                for (int j = 0; j < quadrados.GetLength(1); j++)
                    quadrados[i, j] = ' ';
            }
        }

        // Exibição do Tabuleiro na Tela
        public void ExibirTabuleiro()
        {
            Console.Clear();
            Console.ResetColor();
            for (int i = 0; i < quadrados.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < quadrados.GetLength(1); j++)
                {
                    Console.Write(" " + quadrados[i, j] + " ");
                    if (j < quadrados.GetLength(1) - 1)
                        Console.Write('|');
                }
                Console.WriteLine();
                if (i < quadrados.GetLength(0) - 1)
                    Console.Write("-----------");
            }
            Console.WriteLine();
        }

        // Realização de uma jogada por um jogador
        public virtual void FazerJogada(int linha = 0, int coluna = 0)
        {
            Console.WriteLine($"{Nome}, insira as coordenadas da sua jogada!");
            do
            {
                Console.Write("Linha: ");
                linha = int.Parse(Console.ReadLine().Trim());
                Console.Write("Coluna: ");
                coluna = int.Parse(Console.ReadLine().Trim());
                if (quadrados[linha - 1, coluna - 1] != ' ') // Verificar se a casa está vazia
                    Console.WriteLine("\nEsta casa já foi preenchida. Insira uma coordenada para uma casa vazia!\n");
            }
            while (quadrados[linha - 1, coluna - 1] != ' ');
            quadrados[linha - 1, coluna - 1] = Simbolo; // Preenche o tabuleiro com o símbolo do jogador
        }

        // Verifica se algum jogador venceu o jogo
        public virtual bool VerificarVitoria()
        {
            // Verificação de Linhas e Colunas
            for (int i = 0; i < quadrados.GetLength(0); i++)
            {
                if (quadrados[i, 0] == Simbolo && quadrados[i, 1] == Simbolo && quadrados[i, 2] == Simbolo)
                    return true; // Linha completa
                if (quadrados[0, i] == Simbolo && quadrados[1, i] == Simbolo && quadrados[2, i] == Simbolo)
                    return true; // Coluna completa
            }

            // Verificação das Diagonais
            if (quadrados[0, 0] == Simbolo && quadrados[1, 1] == Simbolo && quadrados[2, 2] == Simbolo)
                return true; // Diagonal principal completa
            if (quadrados[0, 2] == Simbolo && quadrados[1, 1] == Simbolo && quadrados[2, 0] == Simbolo)
                return true; // Diagonal secundária completa

            return false; // Ninguém venceu ainda
        }

        // Verifica se não há mais possibilidade de vencer
        public bool VerificarVelha()
        {
            foreach (char quadrado in quadrados) // Verificar cada casa do tabuleiro
            {
                if (quadrado == ' ') // Se for vazio
                    return false; // Ainda há como jogar
            }

            Console.WriteLine("Deu velha!");
            Console.WriteLine("Ninguém venceu!");
            return true; // Deu velha
        }

        // Destruição do Tabuleiro ao Final
        ~Player() { }
    }
}