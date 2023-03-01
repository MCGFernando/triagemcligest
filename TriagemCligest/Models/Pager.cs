namespace TriagemCligest.Models
{
    public class Pager
    {
        public int TotalItens { get; private set; }
        public int PaginaAtual { get; private set; }
        public int PaginaTamanho { get; private set; }
        public int PaginasTotal { get; private set; }
        public int PaginaInicio { get; private set; }
        public int PaginaFim { get; private set; }

        public Pager()
        {
        }

        public Pager(int totalItens, int pagina, int paginaTamanho = 10)
        {
            int paginasTotal = (int)Math.Ceiling((decimal)totalItens / (decimal)paginaTamanho);
            int paginaAtual = pagina;
            int inicio = paginaAtual - 5;
            int fim = paginaAtual + 4;

            if (inicio <= 0)
            {
                fim -= (inicio - 1);
                inicio= 1;  
            }

            if(fim > paginasTotal) 
            {
                fim = paginasTotal;
                if(fim > 10) { inicio = fim - 9; } 
            }

            TotalItens= totalItens;
            PaginaAtual= paginaAtual;
            PaginaTamanho= paginaTamanho;
            PaginasTotal= paginasTotal;
            PaginaInicio = inicio;
            PaginaFim = fim;
        }
    }
}
