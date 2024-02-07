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
                PartidaDeXadrez partida = new PartidaDeXadrez();
                
                while(!partida.terminada)
                {
                    Console.Clear();
                    Tela.imprimirTabuleiro(partida.tab);
                    Console.Write("Origem: ");
                    Posicao origem = Tela.lerPosicaoXadrez().ToPosicao();
                    Console.Write("Destino: ");
                    Posicao destino = Tela.lerPosicaoXadrez().ToPosicao();
                    partida.executaMovimento(origem,destino);
                }
            }
            catch (tabuleiroException e)
            { 
                System.Console.WriteLine(e.Message); 
            }
            Console.ReadLine();
        }
            
    }

}