using tabuleiro;
using System;

namespace damas
{
    class PartidaDeDamas : Partida
    {
        bool continuaJogada = false;

        public PartidaDeDamas() : base()
        {
            colocarPecas();
        }

        public Peca executaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.retirarPeca(origem);
            p.incrementarQteMovimentos();
            Peca pecaCapturada = tab.retirarPeca(destino);
            tab.colocarPeca(p, destino);
            if (pecaCapturada != null)
            {
                /*Posicao origem2 = destino;
                this.validarPosicaoDeOrigem(origem2);
                if (origem2.coluna == origem.coluna - 1)
                {
                    bool[,] posicoesPossiveis = this.tab.peca(origem2).movimentosPossiveisNaCaptura('e');
                    Console.Clear();
                    TelaDamas.imprimirTabuleiro(this.tab, posicoesPossiveis);
                }
                else if (origem2.coluna == origem.coluna + 1)
                {
                    bool[,] posicoesPossiveis = this.tab.peca(origem2).movimentosPossiveisNaCaptura('d');
                    Console.Clear();
                    TelaDamas.imprimirTabuleiro(this.tab, posicoesPossiveis);
                }
                else
                {
                    throw new TabuleiroException("Movimento não permitido!");
                }
                */
                capturadas.Add(pecaCapturada);
                continuaJogada = true;

                /*
                Console.WriteLine();
                Console.Write("Destino: ");
                Posicao novoDestino = TelaDamas.lerPosicaoDamas().toPosicao();
                this.validarPosicaoDeDestino(origem2, novoDestino);

                this.realizaJogada(origem2, destino);
                */
            }

            return pecaCapturada;
        }

        public void desfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca p = tab.retirarPeca(destino);
            p.decrementarQteMovimentos();
            if (pecaCapturada != null)
            {
                tab.colocarPeca(pecaCapturada, destino);
                capturadas.Remove(pecaCapturada);
            }
            tab.colocarPeca(p, origem);

        }
        public void realizaJogada(Posicao origem, Posicao destino)
        {
            Peca p = tab.peca(destino);

            Peca pecaCapturada = executaMovimento(origem, destino);
            //executaMovimento(origem, destino);
            //#jogadaespecial promocao
            if (p is PecaDeDama)
            {
                if ((p.cor == Cor.Branca && destino.linha == 0) || (p.cor == Cor.Preta && destino.linha == 7))
                {
                    p = tab.retirarPeca(destino);
                    pecas.Remove(p);
                    Peca novaPeca = new Dama(tab, p.cor, this);
                    tab.colocarPeca(novaPeca, destino);
                    pecas.Add(novaPeca);
                }
            }

            if (capturadas.Count == 8)
            {
                terminada = true;
            }
            if (!continuaJogada)
            {
                continuaJogada = false;
                turno++;
                mudaJogador();
            }
            

        }
        public void colocarNovaPeca(char coluna, int linha, Peca peca)
        {
            tab.colocarPeca(peca, new PosicaoDamas(coluna, linha).toPosicao());
            pecas.Add(peca);
        }
        private void colocarPecas()
        {
            colocarNovaPeca('a', 1, new PecaDeDama(tab, Cor.Branca, this));
            colocarNovaPeca('c', 1, new PecaDeDama(tab, Cor.Branca, this));
            colocarNovaPeca('e', 1, new PecaDeDama(tab, Cor.Branca, this));
            colocarNovaPeca('g', 1, new PecaDeDama(tab, Cor.Branca, this));
            colocarNovaPeca('b', 2, new PecaDeDama(tab, Cor.Branca, this));
            colocarNovaPeca('d', 2, new PecaDeDama(tab, Cor.Branca, this));
            colocarNovaPeca('f', 2, new PecaDeDama(tab, Cor.Branca, this));
            colocarNovaPeca('h', 2, new PecaDeDama(tab, Cor.Branca, this));

            colocarNovaPeca('b', 8, new PecaDeDama(tab, Cor.Preta, this));
            colocarNovaPeca('d', 8, new PecaDeDama(tab, Cor.Preta, this));
            colocarNovaPeca('f', 8, new PecaDeDama(tab, Cor.Preta, this));
            colocarNovaPeca('h', 8, new PecaDeDama(tab, Cor.Preta, this));
            colocarNovaPeca('a', 7, new PecaDeDama(tab, Cor.Preta, this));
            colocarNovaPeca('c', 7, new PecaDeDama(tab, Cor.Preta, this));
            colocarNovaPeca('e', 7, new PecaDeDama(tab, Cor.Preta, this));
            colocarNovaPeca('g', 7, new PecaDeDama(tab, Cor.Preta, this));


        }
    }
}
