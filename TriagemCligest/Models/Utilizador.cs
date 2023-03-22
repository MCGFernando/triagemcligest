using TriagemCligest.Models.Enum;

namespace TriagemCligest.Models
{
    [Serializable]
    public class Utilizador
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public int? IdEspecializade { get; set; }
        public string? Especializade { get; set; }
        public Funcao Funcao { get; set; }
    }
}
