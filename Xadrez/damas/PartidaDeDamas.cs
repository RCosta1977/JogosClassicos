using System.Collections.Generic;
using tabuleiro;
using JogosClassicos;

namespace damas
{
    class PartidaDeDamas
    {
        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; }
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;

        public PartidaDeDamas()
        {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            terminada = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();

            colocarPecas();
        }

        public void validarPosicaoDeOrigem(Posicao pos)
        {
            if (tab.peca(pos) == null)
            {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
            }
            if (jogadorAtual != tab.peca(pos).cor)
            {
                throw new TabuleiroException("A peça de origem escolhida não é sua!");
            }
            if (!tab.peca(pos).existeMovimentosPossiveis())

            {
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida!");
            }

        }
        public void validarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if (!tab.peca(origem).movimentoPossivel(destino))
            {
                throw new TabuleiroException("Posição de destino inválida!");
            }
        }
        
        public Peca executaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.retirarPeca(origem);
            p.incrementarQteMovimentos();
            Peca pecaCapturada = tab.retirarPeca(destino);
            tab.colocarPeca(p, destino);
            if (pecaCapturada != null)
            {
                capturadas.Add(pecaCapturada);
            }

            return pecaCapturada;
        }
        public void mudaJogador()
        {
            if (jogadorAtual == Cor.Branca)
            {
                jogadorAtual = Cor.Preta;
            }
            else
            {
                jogadorAtual = Cor.Branca;
            }
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
            Peca pecaCapturada = executaMovimento(origem, destino);

            Peca p = tab.peca(destino);

            //#jogadaespecial promocao
            if ((p.cor == Cor.Branca && destino.linha == 0) || (p.cor == Cor.Preta && destino.linha == 7))
            {
                p = tab.retirarPeca(destino);
                pecas.Remove(p);
                char escolha = TelaDamas.escolherPeca();
                Peca novaPeca = new Dama(tab, p.cor, this);
                tab.colocarPeca(novaPeca, destino);
                pecas.Add(novaPeca);


            }

            turno++;
            mudaJogador();

        }




        public HashSet<Peca> pecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in capturadas)
            {
                if (x.cor == cor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }
        public HashSet<Peca> pecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in pecas)
            {
                if (x.cor == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(pecasCapturadas(cor));
            return aux;
        }
        private Cor adversaria(Cor cor)
        {
            if (cor == Cor.Branca)
            {
                return Cor.Preta;
            }
            else
            {
                return Cor.Branca;
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
