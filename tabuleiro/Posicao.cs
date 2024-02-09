
namespace tabuleiro{   
    //classe posição das peças dentro do tabuleiro
    class Posicao
    {
        //atributos da classe
        public int Linha {get; set;}
        public int Coluna{get; set;}

        //Construtor
        public Posicao(int linha, int coluna)
        {
            this.Linha = linha;
            this.Coluna = coluna;
        }
        //Metodo para conseguir visualizar as posições 
        public override string ToString()
        {
            return Linha + ", " + Coluna;
        }
        public void definirValores(int linha, int coluna)
        {
            this.Linha = linha;
            this.Coluna = coluna;
            
        }
    }
}
