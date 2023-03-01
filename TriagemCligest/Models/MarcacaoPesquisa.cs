namespace TriagemCligest.Models
{
    public class MarcacaoPesquisa
    {
        public int IdMarcacao { get; set; }
        public string? Pesquisar { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public string? Estado { get; set; }
    }
}
