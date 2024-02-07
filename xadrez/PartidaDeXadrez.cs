namespace xadrez;

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

    public PartidaDeXadrez()
    {
        tab = new Tabuleiro(8,8);
        turno = 1;
        jogadorAtual = Cor.Branca;
        terminada = false;
        colocarPecas();
    }
    public void executaMovimento(Posicao origem, Posicao destino)
    {
        Peca p =tab.retirarPeca(origem);
        p.incrementarMovimento();
        tab.retirarPeca(destino);
        Peca pecaCapturada = tab.retirarPeca(destino);
        tab.colocarPeca(p,destino);
    }
    public void realizaJogada(Posicao origem, Posicao destino)
    {
        executaMovimento(origem, destino);
        turno++;
        mudaJogador();
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

    private void colocarPecas()
    {
        tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('c',1).ToPosicao());
        tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('c',2).ToPosicao());
        tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('d',2).ToPosicao());
        tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('e',2).ToPosicao());
        tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('e',1).ToPosicao());
        tab.colocarPeca(new Rei(tab, Cor.Branca), new PosicaoXadrez('d',1).ToPosicao());

        tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('c',7).ToPosicao());
        tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('c',8).ToPosicao());
        tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('d',7).ToPosicao());
        tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('e',7).ToPosicao());
        tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('e',8).ToPosicao());
        tab.colocarPeca(new Rei(tab, Cor.Preta), new PosicaoXadrez('d',8).ToPosicao());
    }
}

