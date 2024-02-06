using tabuleiro;

namespace xadrez_console;

    class Tabuleiro
    {
        public int linhas {get;set;}
        public int colunas { get; set; }
        private Peca[,] pecas;

        public Tabuleiro(int linha, int coluna)
        {
            this.linhas = linha;
            this.colunas = coluna;
            pecas = new Peca[linhas,colunas];
        }
    }
