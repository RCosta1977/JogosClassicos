using tabuleiro;

namespace damas
{
    class PecaDeDama : Peca
    {
        private PartidaDeDamas partida;
        public PecaDeDama(Tabuleiro tab, Cor cor, PartidaDeDamas partida) : base(tab, cor)
        {
            this.partida = partida;
        }
        public override string ToString()
        {
            return "O";
        }
        private bool podeMover(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p == null || p.cor != cor;
        }
        private bool existeInimigo(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p != null && p.cor != cor;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];

            Posicao pos = new Posicao(0, 0);

            if (cor == Cor.Branca)
            {

                pos.definirValores(posicao.linha - 1, posicao.coluna + 1);
                if (tab.posicaoValida(pos) && podeMover(pos) && existeInimigo(pos))
                {
                    mat[pos.linha - 1, pos.coluna + 1] = true;
                    pos.definirValores(posicao.linha - 1, posicao.coluna - 1);
                    if (tab.posicaoValida(pos) && podeMover(pos) && existeInimigo(pos))
                    {
                        mat[pos.linha - 1, pos.coluna - 1] = true;
                    }
                    return mat;
                }
                else if (tab.posicaoValida(pos) && podeMover(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }



                pos.definirValores(posicao.linha - 1, posicao.coluna - 1);
                if (tab.posicaoValida(pos) && podeMover(pos) && existeInimigo(pos))
                {
                    mat[pos.linha - 1, pos.coluna - 1] = true;
                    pos.definirValores(posicao.linha - 1, posicao.coluna + 1);
                    if (tab.posicaoValida(pos) && podeMover(pos) && existeInimigo(pos))
                    {
                        mat[pos.linha - 1, pos.coluna + 1] = true;
                        pos.definirValores(posicao.linha - 1, posicao.coluna - 1);
                    }
                    return mat;
                }
                else if (tab.posicaoValida(pos) && podeMover(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

            }
            else
            {

                pos.definirValores(posicao.linha + 1, posicao.coluna + 1);
                if (tab.posicaoValida(pos) && podeMover(pos) && existeInimigo(pos))
                {
                    mat[pos.linha + 1, pos.coluna + 1] = true;
                }
                if (tab.posicaoValida(pos) && podeMover(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }



                pos.definirValores(posicao.linha + 1, posicao.coluna - 1);
                if (tab.posicaoValida(pos) && podeMover(pos) && existeInimigo(pos))
                {
                    mat[pos.linha + 1, pos.coluna - 1] = true;
                }
                if (tab.posicaoValida(pos) && podeMover(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

            }
            return mat;
        }
        public override bool[,] movimentosPossiveisNaCaptura(char tipo)
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];

            Posicao pos = new Posicao(0, 0);

            if (cor == Cor.Branca)
            {
                if (tipo == 'd')
                {
                    pos.definirValores(posicao.linha - 1, posicao.coluna + 1);
                    if (tab.posicaoValida(pos) && podeMover(pos))
                    {
                        mat[pos.linha, pos.coluna] = true;
                    }
                }

                if (tipo == 'e')
                {
                    pos.definirValores(posicao.linha - 1, posicao.coluna - 1);
                    if (tab.posicaoValida(pos) && podeMover(pos))
                    {
                        mat[pos.linha, pos.coluna] = true;
                    }
                }
            }
            else
            {
                if (tipo == 'd')
                {
                    pos.definirValores(posicao.linha + 1, posicao.coluna + 1);
                    if (tab.posicaoValida(pos) && podeMover(pos))
                    {
                        mat[pos.linha, pos.coluna] = true;
                    }
                }

                if (tipo == 'e')
                {
                    pos.definirValores(posicao.linha + 1, posicao.coluna - 1);
                    if (tab.posicaoValida(pos) && podeMover(pos))
                    {
                        mat[pos.linha, pos.coluna] = true;
                    }
                }
            }
            return mat;
        }
    }
}
