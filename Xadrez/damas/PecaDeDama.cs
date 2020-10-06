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
                
        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];

            Posicao pos = new Posicao(0, 0);

            if (cor == Cor.Branca)
            {
                pos.definirValores(posicao.linha - 1, posicao.coluna + 1);
                if (tab.posicaoValida(pos) && podeMover(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                pos.definirValores(posicao.linha - 1, posicao.coluna - 1);
                if (tab.posicaoValida(pos) && podeMover(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
            }
            else
            {
                // se
                pos.definirValores(posicao.linha + 1, posicao.coluna + 1);
                if (tab.posicaoValida(pos) && podeMover(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                // no
                pos.definirValores(posicao.linha + 1, posicao.coluna - 1);
                if (tab.posicaoValida(pos) && podeMover(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
            }
            return mat;
        }
    }
}
