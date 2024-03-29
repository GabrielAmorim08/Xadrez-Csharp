﻿
using tabuleiro;
namespace xadrez
{
    class Rei : Peca
    {
        private PartidaDeXadrez partida;
        public Rei(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) :base(tab,cor){
            this.partida = partida;
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
        private bool testeTorreParaRoque(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p != null && p is Torre && p.cor == cor && qteMovimentos == 0;
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
            //# jogadaespecial roque

            if(qteMovimentos == 0 && !partida.xeque)
            {
                //roque pequeno
                Posicao posRP = new Posicao(posicao.Linha, posicao.Coluna +3);
                if(testeTorreParaRoque(posRP))
                {
                    Posicao p1 = new Posicao(posicao.Linha, posicao.Coluna+1);
                    Posicao p2 = new Posicao(posicao.Linha,posicao.Coluna+2);
                    if(tab.peca(p1) == null && tab.peca(p2) == null)
                    {
                        mat[posicao.Linha,posicao.Coluna+2] = true;
                    }
                }
                //roque grande
                Posicao posPQ = new Posicao(posicao.Linha, posicao.Coluna -4);
                if(testeTorreParaRoque(posRP))
                {
                    Posicao p1 = new Posicao(posicao.Linha, posicao.Coluna-1);
                    Posicao p2 = new Posicao(posicao.Linha,posicao.Coluna-2);
                    Posicao p3 = new Posicao(posicao.Linha,posicao.Coluna-3);
                    if(tab.peca(p1) == null && tab.peca(p2) == null && tab.peca(p3) == null)
                    {
                        mat[posicao.Linha,posicao.Coluna-2] = true;
                    }
                }
            }
            return mat;
        }


    }
}

