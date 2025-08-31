using System;

namespace JogoDaVelha
{
    public class Player1 : Player
    {
        public Player1(string nome, char simbolo) : base(nome, simbolo) { }

        public override void FazerJogada(int linha, int coluna)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            base.FazerJogada(linha, coluna);
        }

        public override bool VerificarVitoria()
        {
            if (base.VerificarVitoria())
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{Nome} venceu o Jogo da Velha!");
                Pontuacao++;
                return true;
            }

            return false;
        }
    }
}