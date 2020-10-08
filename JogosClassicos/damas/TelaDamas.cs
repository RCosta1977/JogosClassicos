using JogosClassicos;
using System;

namespace damas
{
    class TelaDamas : Tela
    {
        public static void imprimirPartida(PartidaDeDamas partida)
        {
            imprimirTabuleiro(partida.tab);
            Console.WriteLine();
            imprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine("Turno: " + partida.turno);
            if (!partida.terminada)
            {
                Console.WriteLine("Aguardando jogada: " + partida.jogadorAtual);
                
            }
            else
            {
                Console.WriteLine($"O jogador(a) com a {partida.jogadorAtual} venceu!");
                Console.WriteLine("Vencedor: " + partida.jogadorAtual);
            }
        }
        
        
        public static PosicaoDamas lerPosicaoDamas()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoDamas(coluna, linha);
        }
        
        
    }
}
