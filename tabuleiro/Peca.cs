using xadrez_console;

namespace tabuleiro
{
    abstract class Peca
    {
        public Posicao posicao {get;set;}
        public Cor cor {get;set;}
        public int qteMovimentos {get; protected set;}
        public Tabuleiro tab {get;protected set;}

        public  Peca(Tabuleiro tab, Cor cor)
        {
            this.posicao = null;
            this.tab = tab;
            this.cor = cor;
            this.qteMovimentos = 0;
        }
        public void incrementarMovimento()
        {
            qteMovimentos++;
        }

        public bool existeMovimentosPossiveis()
        {
            bool [,] mat = movPosiveis();
            for(int i=0; i< tab.linhas; i++)
            {
                for(int j = 0; j<tab.colunas; j++)
                {
                    if(mat[i,j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool podeMoverPara(Posicao pos)
        {
            return movPosiveis()[pos.Linha,pos.Coluna];
        }
        public abstract bool[,] movPosiveis();
    }   
}
