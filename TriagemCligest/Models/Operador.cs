using System.ComponentModel.DataAnnotations.Schema;

namespace TriagemCligest.Models
{
    [Serializable]
    [Table("Operador")]
    public class Operador
    {
        [Column("ID_User")]
        public int ID { get; private set; }
        [Column("User_name")]
        public string? UserName { get; private set; }
        
        public int? Cargo { get; private set; }
        [Column("Escalão")]
        public string? Escalao { get; private set; }
        [Column("access_level")]
        public int? AccessLevel { get; private set; }

        public string? Login { get; set; }

        public string? Password { get; set; }

        public int? Responsabilidade { get; private set; }

        public bool? Activo { get; private set; }

        public int? Agenda { get; private set; }

        public int? Cidade { get; private set; }
        [Column("Centro de custo")]
        public int? CentroCusto { get; private set; }

        public bool? Receitar { get; private set; }
        [Column("DataAdmissão")]
        public DateTime? DataAdmissao { get; private set; }
        [Column("Data de Saída")]
        public DateTime? DatadeSaida { get; private set; }
        [Column("Data Nascimento")]
        public DateTime? DataNascimento { get; private set; }

        public int? Area { get; private set; }

        public int? Local { get; private set; }
        [Column("Observações")]
        public string? Observacoes { get; private set; }
    }
}
