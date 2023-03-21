using System.ComponentModel.DataAnnotations.Schema;

namespace TriagemCligest.Models
{
    [Serializable]
    [Table("Global Var")]
    public class GlobalVar
    {
        [Column("ID Global Var")]
        public int Id { get; set; }
        [Column("FE Code")]
        public string? FeCode { get; set; }
    }
}
