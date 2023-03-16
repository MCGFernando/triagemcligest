using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TriagemCligest.Models
{
    [Serializable]
    [Table("Marcação")]
    public class Marcacao
    {
        [Column("ID Marcação")]
        public int ID { get; private set; }
        public int? Especialidade { get; private set; }
        [Column("ID Centro")]
        public int? FuncionarioID { get; private set; }
        public Funcionario Funcionario { get; set; }
        [Column("ID utente")]
        public int? IDutente { get; private set; }
        public string? Utente { get; private set; }
        public DateTime? Hora { get; private set; }
        public DateTime? Data { get; private set; }
        public bool? Realizado { get; private set; }
        [Column("ID funcionário")]
        public int? IDfuncionario { get; private set; }
        [Column("COD Entidade")]
        public string? CODEntidade { get; private set; }
        [Column("ID entidade")]
        public int? IDEntidade { get; private set; }
        public string? Entidade { get; private set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime? Horam { get; private set; }
        public DateTime? Datam { get; private set; }
        public bool? Encerrada { get; private set; }
        public int? Tipo { get; private set; }
        [Column("Telefone de contacto")]
        public string? TelefoneContacto { get; private set; }
        public string? Estado { get; private set; }
        public string? Notas { get; private set; }
        [Column("Ficha Episódio")]
        public string? FichaEpisodio { get; private set; }
        [Column("ID FE")]
        public int? IDFE { get; private set; }
        [Column("preço")]
        public double? Preco { get; private set; }
        public string? Posto { get; private set; }
    }
}