namespace xadrez;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using tabuleiro;
using xadrez_console;

class PartidaDeXadrez
{
    public Tabuleiro tab {get; private set;}
    public int turno {get; private set;}
    public Cor jogadorAtual {get; private set;}
    public bool terminada {get; private set;}
    private HashSet<Peca> pecas;
    private HashSet<Peca> capturadas;
    public bool xeque {get;private set;}
    public PartidaDeXadrez()    
    {
        tab = new Tabuleiro(8,8);
        turno = 1;
        jogadorAtual = Cor.Branca;
        terminada = false;
        pecas = new HashSet<Peca>();
        capturadas = new HashSet<Peca>();
        xeque = false;
        colocarPecas();
    }
    public Peca executaMovimento(Posicao origem, Posicao destino)
    {
        Peca p =tab.retirarPeca(origem);
        p.incrementarMovimento();
        tab.retirarPeca(destino);
        Peca pecaCapturada = tab.retirarPeca(destino);
        tab.colocarPeca(p,destino);
        if(pecaCapturada != null)
        {
            capturadas.Add(pecaCapturada);
        }
        return pecaCapturada;
    }
    public void realizaJogada(Posicao origem, Posicao destino)
    {
        Peca pecaCapturada = executaMovimento(origem,destino);
        if(estaEmXeque(jogadorAtual))
        {
            desfazMovimento(origem,destino,pecaCapturada);
            throw new tabuleiroException("Você não pode se colocar em xeque!");
        }
        if(estaEmXeque(adversaria(jogadorAtual)))
        {
            xeque = true;
        }
        else{
            xeque = false;
        }
        turno++;
        mudaJogador();
    }
    public void desfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
    {
        Peca p = tab.retirarPeca(destino);
        p.DecrementarMovimento();
        if(pecaCapturada != null)
        {
            tab.colocarPeca(pecaCapturada, destino);
            capturadas.Remove(pecaCapturada);
        }
        tab.colocarPeca(p,origem);
    }
    public void validarPosicaoOrigem(Posicao pos)
    {
        if(tab.peca(pos) == null)
        {
            throw new tabuleiroException ("Não existe peça na posição de origem escolhida!");
        }
        if(jogadorAtual != tab.peca(pos).cor)
        {
            throw new tabuleiroException("A peça escolhida não é sua");
        }
        if(!tab.peca(pos).existeMovimentosPossiveis())
        {
            throw new tabuleiroException("Não existe movimentos possiveis para essa peça");
        }
    }
    public void validarPosicaoDestino(Posicao origem, Posicao destino)
    {
        if(!tab.peca(origem).podeMoverPara(destino))
        {
            throw new tabuleiroException("Posição de destino invalida");
        }
    }
    private void mudaJogador()
    {
        if(jogadorAtual == Cor.Branca)
        {
            jogadorAtual = Cor.Preta;
        }
        else{
            jogadorAtual = Cor.Preta;
        }
    }
    public HashSet<Peca> pecasCapturadas(Cor cor)
    {
        HashSet<Peca> aux =  new HashSet<Peca>();
        foreach (Peca x in capturadas)
        {
            if(x.cor == cor)
            {
                aux.Add(x);
            }
        }
        return aux;
    }
    public HashSet<Peca> pecasEmJogo(Cor cor)
    {
        HashSet<Peca> aux =  new HashSet<Peca>();
        foreach (Peca x in pecas)
        {
            if(x.cor == cor)
            {
                aux.Add(x);
            }
        }
        aux.ExceptWith(pecasCapturadas(cor));
        return aux;
    }
    private Cor adversaria(Cor cor)
    {
        if(cor == Cor.Branca)
        {
            return Cor.Preta;
        }
        else{
            return Cor.Branca;
        }
    }
    private Peca rei(Cor cor)
    {
        foreach (Peca x  in pecasEmJogo(cor))
        {
            if(x is Rei)
            {
                return x;
            }
        }
        return null;
    }


    public bool estaEmXeque(Cor cor)
    {
        Peca R = rei(cor);
        if(R == null)
        {
            throw new tabuleiroException("Não tem rei na cor "+cor+" no tabuleiro!");
        }
        foreach (Peca x in pecasEmJogo(adversaria(cor)))
        {
            bool[,] mat = x.movPosiveis();
            if(mat[R.posicao.Linha, R.posicao.Coluna]){
                return true;
            }
        }
        return false;
    }
    public void colocarNovaPeca(char coluna, int linha, Peca peca)
    {
        tab.colocarPeca(peca, new PosicaoXadrez(coluna,linha).ToPosicao());
        pecas.Add(peca);
    }
    private void colocarPecas()
    {
        colocarNovaPeca('c',1, new Torre(tab, Cor.Branca));
        colocarNovaPeca('c',2, new Torre(tab, Cor.Branca));
        colocarNovaPeca('c',1, new Torre(tab, Cor.Branca));
        colocarNovaPeca('c',2, new Torre(tab, Cor.Branca));
        colocarNovaPeca('e',2, new Torre(tab, Cor.Branca));
        colocarNovaPeca('e',1, new Torre(tab, Cor.Branca));
        colocarNovaPeca('d',1, new Rei(tab, Cor.Branca));
        colocarNovaPeca('c',7, new Torre(tab, Cor.Preta));
        colocarNovaPeca('c',8, new Torre(tab, Cor.Preta));
        colocarNovaPeca('d',7, new Torre(tab, Cor.Preta));
        colocarNovaPeca('e',7, new Torre(tab, Cor.Preta));
        colocarNovaPeca('e',8, new Torre(tab, Cor.Preta));
        colocarNovaPeca('d',8, new Rei(tab, Cor.Preta));
    }
}