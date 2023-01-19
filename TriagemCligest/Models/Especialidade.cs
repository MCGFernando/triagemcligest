using System.ComponentModel.DataAnnotations.Schema;

namespace TriagemCligest.Models
{
    [Serializable]
    [Table("Especialidade")]
    public class Especialidade
    {
        [Column("ID Especialidade")]
        public int Id { get; private set; }
        [Column("Especialidade")]
        public string? Esp { get; set; }

        [Column("Autorização")]
        public bool? Autorizacao { get; private set; }
        public bool? Activada { get; private set; }
    }
}
