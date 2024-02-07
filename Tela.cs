using tabuleiro;
using xadrez;
namespace xadrez_console{
    class Tela{
        public static void imprimirTabuleiro(Tabuleiro tab){
            for (int i = 0; i<tab.linhas; i++){
                Console.Write(8-i + " ");
                for(int j = 0; j < tab.colunas; j++){
                   imprimirPeca(tab.peca(i,j)); 
                }
                System.Console.WriteLine();
            }
            System.Console.WriteLine(" a b c d e f g h");
            
        }
        public static void imprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis){
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoPosicoes = ConsoleColor.DarkGray;
            for (int i = 0; i<tab.linhas; i++){
                Console.Write(8-i + " ");
                for(int j = 0; j < tab.colunas; j++){
                    if(posicoesPossiveis[i,j])
                    {
                        Console.BackgroundColor = fundoPosicoes;

                    }
                    else
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }
                   imprimirPeca(tab.peca(i,j));
                   Console.BackgroundColor = fundoOriginal;
                }
                System.Console.WriteLine();
            }
            System.Console.WriteLine(" a b c d e f g h");
            Console.BackgroundColor = fundoOriginal;
            
        }
        public static void imprimirPeca(Peca peca)
        {
            if(peca == null)
            {
                System.Console.Write("- ");
            }
            else{
                if(peca.cor == Cor.Branca)
                {
                    System.Console.Write(peca);
                }
                else{
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    System.Console.Write(peca);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }
        public static PosicaoXadrez lerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char Coluna = s[0];
            int Linha = int.Parse(s[1] + " ");
            return new PosicaoXadrez(Coluna,Linha);
        }
    }
    
}
