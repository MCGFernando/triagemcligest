namespace TriagemCligest.Models
{
    public class TriagemPesquisa
    {
        public string? Pesquisar { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public string? ClassificacaoTriagem { get; set; }
        public string? EstadoTriagem { get; set; }
    }
}
