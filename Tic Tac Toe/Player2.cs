using System;

namespace JogoDaVelha
{
    public class Player2 : Player
    {
        public Player2(string nome, char simbolo) : base(nome, simbolo) { }

        public override void FazerJogada(int linha, int coluna)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            base.FazerJogada(linha, coluna);
        }

        public override bool VerificarVitoria()
        {
            if (base.VerificarVitoria())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{Nome} venceu o Jogo da Velha!");
                Pontuacao++;
                return true;
            }

            return false;
        }
    }
}