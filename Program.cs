using System.Runtime.ConstrainedExecution;
using tabuleiro;
using xadrez;
namespace xadrez_console
{
    class Program
    {
        static void Main(String[] args)
        {
            try
            {
                Tabuleiro tab = new Tabuleiro(8,8);
                tab.colocarPeca(new Torre(tab, Cor.Preta), new Posicao(0,0));
                tab.colocarPeca(new Torre(tab,Cor.Preta), new Posicao(1,3));
                tab.colocarPeca(new Rei(tab,Cor.Preta), new Posicao(2,4));
                Tela.imprimirTabuleiro(tab);
            }
            catch (tabuleiroException e)
            { 
                System.Console.WriteLine(e.Message); 
            }
            
        }
            
    }

}