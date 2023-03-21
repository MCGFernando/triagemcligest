using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TriagemCligest.Models
{
    [Serializable]
    [Table("Marcação")]
    public class Marcacao
    {
        [Column("ID Marcação")]
        public int ID { get;  set; }
        public int? Especialidade { get;  set; }
        [Column("ID Centro")]
        public int? FuncionarioID { get;  set; }
        public Funcionario Funcionario { get; set; }
        [Column("ID utente")]
        public int? IDutente { get;  set; }
        public string? Utente { get;  set; }
        public DateTime? Hora { get;  set; }
        public DateTime? Data { get;  set; }
        public bool? Realizado { get;  set; }
        [Column("ID funcionário")]
        public int? IdOperador { get;  set; }
        [Column("COD Entidade")]
        public string? CODEntidade { get;  set; }
        [Column("ID entidade")]
        public int? IDEntidade { get;  set; }
        public string? Entidade { get;  set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime? Horam { get;  set; }
        public DateTime? Datam { get;  set; }
        public bool? Encerrada { get;  set; }
        public int? Tipo { get;  set; }
        [Column("Telefone de contacto")]
        public string? TelefoneContacto { get;  set; }
        public string? Estado { get;  set; }
        public string? Notas { get;  set; }
        [Column("Ficha Episódio")]
        public string? FichaEpisodio { get;  set; }
        [Column("ID FE")]
        public int? IDFE { get;  set; }
        [Column("preço")]
        public double? Preco { get;  set; }
        public string? Posto { get;  set; }
    }
}