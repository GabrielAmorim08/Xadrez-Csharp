using tabuleiro;
using System.Collections.Generic;
using xadrez;
namespace xadrez_console{
    class Tela{
        public static void imprimirPartida(PartidaDeXadrez partida)
        {
            imprimirTabuleiro(partida.tab);
            Console.WriteLine();
            imprimirPecasCapturadas(partida);
            System.Console.WriteLine();
            Console.WriteLine("Turno: " +partida.turno);
            Console.WriteLine("Jogador da vez: peça " + partida.jogadorAtual);
            if(partida.xeque)
            {
            System.Console.WriteLine("Você está em xeque");
            }
        }

        public static void imprimirPecasCapturadas(PartidaDeXadrez partida)
        {
            System.Console.WriteLine("Peças capturadas: ");
            Console.WriteLine("Brancas: ");
            imprimirConjunto(partida.pecasCapturadas(Cor.Branca));
            System.Console.WriteLine();
            Console.WriteLine("Pretas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            imprimirConjunto(partida.pecasCapturadas(Cor.Preta));
            Console.ForegroundColor = aux;
            System.Console.WriteLine();
        }
        public static void imprimirConjunto(HashSet<Peca> conjunto)
        {
            System.Console.Write("[");
            foreach (Peca x in conjunto)
            {
                System.Console.Write(x + " ");
            }
            Console.Write("]");
        }
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
