using System.ComponentModel.DataAnnotations.Schema;

namespace TriagemCligest.Models
{
    [Serializable]
    [Table("Contador")]
    public class Contador
    {
        [Column("ID Ficha de Episódio")]
        public int Id { get; set; }
        [Column("Contador")]
        public string _Contador { get; set; }
        public int Valor { get; set; }
        [Column("ID Company")]
        public int? IdCompany { get; set; }
        [Column("ano")]
        public int? Ano { get; set; }
        [Column("ID Centro Custo")]
        public int? IDCentroCusto { get; set; }

        
    }
}
