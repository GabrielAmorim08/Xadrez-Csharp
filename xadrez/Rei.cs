
using tabuleiro;
namespace xadrez
{
    class Rei : Peca
    {
        public Rei(Tabuleiro tab, Cor cor) :base(tab,cor){

        }
        public override string ToString()
        {
            return "R";
        }
        
        private bool podeMover(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p == null || p.cor != cor;
        }
        public override bool[,] movPosiveis()
        {
            bool[,] mat = new bool[tab.linhas,tab.colunas];
            Posicao pos = new Posicao(0,0);

            //acima
            pos.definirValores(posicao.Linha -1, posicao.Coluna);
            if(tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha,pos.Coluna] = true;
            }
            
            //NE
            pos.definirValores(posicao.Linha -1, posicao.Coluna+1);
            if(tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha,pos.Coluna] = true;
            }
            
            //direita
            pos.definirValores(posicao.Linha, posicao.Coluna+1);
            if(tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha,pos.Coluna] = true;
            }
            
            //SE
            pos.definirValores(posicao.Linha +1, posicao.Coluna+1);
            if(tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha,pos.Coluna] = true;
            }
            //ABAIXO
            pos.definirValores(posicao.Linha +1, posicao.Coluna);
            if(tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha,pos.Coluna] = true;
            }
            //SO
            pos.definirValores(posicao.Linha +1, posicao.Coluna-1);
            if(tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha,pos.Coluna] = true;
            }
            //ESQUERDA
            pos.definirValores(posicao.Linha, posicao.Coluna-1);
            if(tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha,pos.Coluna] = true;
            }
            //NO
            pos.definirValores(posicao.Linha -1, posicao.Coluna-1);
            if(tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linha,pos.Coluna] = true;
            }
            return mat;
        }


    }
}

