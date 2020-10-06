using System;
using tabuleiro;
using xadrez;
using damas;

namespace JogosClassicos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Qual jogo gostaria de jogar? (x = Xadrez / d = Damas)");
            char c = char.Parse(Console.ReadLine().ToLower());
            if (c == 'x')
            {

                try
                {
                    PartidaDeXadrez partida = new PartidaDeXadrez();

                    while (!partida.terminada)
                    {
                        try
                        {
                            Console.Clear();
                            TelaXadrez.imprimirPartida(partida);

                            Console.WriteLine();
                            Console.Write("Origem: ");
                            Posicao origem = TelaXadrez.lerPosicaoXadrez().toPosicao();
                            partida.validarPosicaoDeOrigem(origem);

                            bool[,] posicoesPossiveis = partida.tab.peca(origem).movimentosPossiveis();

                            Console.Clear();
                            TelaXadrez.imprimirTabuleiro(partida.tab, posicoesPossiveis);

                            Console.WriteLine();
                            Console.Write("Destino: ");
                            Posicao destino = TelaXadrez.lerPosicaoXadrez().toPosicao();
                            partida.validarPosicaoDeDestino(origem, destino);

                            partida.realizaJogada(origem, destino);
                        }
                        catch (TabuleiroException e)
                        {
                            Console.WriteLine(e.Message);
                            Console.ReadLine();
                        }
                    }
                    Console.Clear();
                    TelaXadrez.imprimirPartida(partida);
                }
                catch (TabuleiroException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            if (c=='d')
            {
                try
                {
                    PartidaDeDamas partida = new PartidaDeDamas();

                    while (!partida.terminada)
                    {
                        try
                        {
                            Console.Clear();
                            TelaDamas.imprimirPartida(partida);

                            Console.WriteLine();
                            Console.Write("Origem: ");
                            Posicao origem = TelaDamas.lerPosicaoDamas().toPosicao();
                            partida.validarPosicaoDeOrigem(origem);

                            bool[,] posicoesPossiveis = partida.tab.peca(origem).movimentosPossiveis();

                            Console.Clear();
                            TelaDamas.imprimirTabuleiro(partida.tab, posicoesPossiveis);

                            Console.WriteLine();
                            Console.Write("Destino: ");
                            Posicao destino = TelaDamas.lerPosicaoDamas().toPosicao();
                            partida.validarPosicaoDeDestino(origem, destino);

                            partida.realizaJogada(origem, destino);
                        }
                        catch (TabuleiroException e)
                        {
                            Console.WriteLine(e.Message);
                            Console.ReadLine();
                        }
                    }
                    Console.Clear();
                    TelaDamas.imprimirPartida(partida);
                }
                catch (TabuleiroException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
