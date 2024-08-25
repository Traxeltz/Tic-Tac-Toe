using System;

namespace JogoDaVelha
{
    // Programa de Operações do Tabuleiro
    public class Tabuleiro
    {
        // Leitura Interna do Tabuleiro
        private readonly char[,] quadrados;

        // Construção do Tabuleiro
        public Tabuleiro()
        {
            quadrados = new char[3, 3];
            InicializarTabuleiro();
        }
        
        // Inicialização do Tabuleiro com Caracteres Vazios
        public void InicializarTabuleiro()
        {
            for (int i = 0; i < quadrados.GetLength(0); i++)
            {
                for (int j = 0; j < quadrados.GetLength(1); j++)
                {
                    quadrados[i, j] = ' ';
                }
            }
        }

        // Exibição do Tabuleiro na Tela
        public void ExibirTabuleiro()
        {
            for (int i = 0; i < quadrados.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < quadrados.GetLength(1); j++)
                {
                    Console.Write(" " + quadrados[i, j] + " ");
                    if (j < quadrados.GetLength(1) - 1)
                    {
                        Console.Write('|');
                    }
                }
                Console.WriteLine();
                if (i < quadrados.GetLength(0) - 1)
                {
                    Console.Write("-----------");
                }
            }
            Console.WriteLine();
        }
        
        // Verifica se uma casa do tabuleiro está preenchida
        public bool QuadradoPreenchido(int linha, int coluna)
        {
            return quadrados[linha - 1, coluna - 1] != ' ';
        }

        // Realização de uma jogada por um jogador
        public void FazerJogada(int linha, int coluna, char simbolo)
        {
            quadrados[linha - 1, coluna - 1] = simbolo;
        }

        // Verifica se algum jogador venceu o jogo
        public bool VerificarVitoria(char simbolo)
        {
            // Verificação de Linhas
            for (int i = 0; i < quadrados.GetLength(0); i++)
            {
                if (quadrados[i, 0] == simbolo && quadrados[i, 1] == simbolo && quadrados[i, 2] == simbolo)
                {
                    return true; // Linha completa
                }
            }

            // Verificação de Colunas
            for (int i = 0; i < quadrados.GetLength(1); i++)
            {
                if (quadrados[0, i] == simbolo && quadrados[1, i] == simbolo && quadrados[2, i] == simbolo)
                {
                    return true; // Coluna completa
                }
            }

            // Verificação da Diagonal Principal
            if (quadrados[0, 0] == simbolo && quadrados[1, 1] == simbolo && quadrados[2, 2] == simbolo)
            {
                return true; // Diagonal principal completa
            }

            // Verificação da Diagonal Secundária
            if (quadrados[0, 2] == simbolo && quadrados[1, 1] == simbolo && quadrados[2, 0] == simbolo)
            {
                return true; // Diagonal secundária completa
            }

            return false; // Ninguém venceu ainda
        }

        // Verifica se não há mais possibilidade de vencer
        public bool VerificarVelha()
        {
            int quadradosVazios = 0;
            foreach (char quadrado in quadrados) // Verificar cada casa do tabuleiro
            {
                if (quadrado == ' ') // Se for vazio
                {
                    quadradosVazios++;
                }
            }
            if (quadradosVazios == 0) // Caso todas as casas estejam preenchidas
            {
                return true; // Deu velha
            }
            return false; // Ainda há como jogar
        }

        // Destruição do Tabuleiro ao Final
        ~Tabuleiro() { }
    }
}