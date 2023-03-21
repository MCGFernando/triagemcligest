using TriagemCligest.Models.Enum;

namespace TriagemCligest.Models
{
    public class TriagemPesquisa
    {
        public string? Pesquisar { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public ClassificacaoTriagem? ClassificacaoTriagem { get; set; }
        public EstadoTriagem? EstadoTriagem { get; set; }
        public TipoTriagem? TipoTriagem { get; set; }
        public TipoFichaAtendimento? TipoFichaAtendimento { get; set; }
    }
}
