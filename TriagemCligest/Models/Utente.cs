using System.ComponentModel.DataAnnotations.Schema;

namespace TriagemCligest.Models
{
    [Serializable]
    [Table("Utente")]
    public class Utente
    {
        [Column("ID Utente")]
        public int ID { get; private set; }
        [Column("ID Utente externo")]
        public string? IDUtenteExterno { get; private set; }
        [Column("ID Entidade")]
        public int? IDEntidade { get; private set; }
        [Column("Profissão")]
        public string? Profissao { get; private set; }
        [Column("ID Estatuto")]
        public int? IDEstatuto { get; private set; }
        [Column("ID Titular")]
        public int? IDTitular { get; private set; }
        public string? Nome { get; private set; }
        [Column("Data Nascimento")]
        public DateTime? DataNascimento { get; private set; }
        public string? Sexo { get; private set; }
        public string? Naturalidade { get; private set; }
        public string? BI { get; private set; }
        public string? Morada { get; private set; }
        public string? Cidade { get; private set; }
        public string? Telefone { get; private set; }
        [Column("Telefone 2")]
        public string? Telefone2 { get; private set; }
        [Column("Local de Trabalho")]
        public int? LocalTrabalho { get; private set; }
        [Column("Data Actualização")]
        public DateTime? DataActualização { get; private set; }
        [Column("Data Fim de contrato")]
        public DateTime? DataFimContrato { get; private set; }
        [Column("Data de Abertura da ficha")]
        public DateTime? DataAberturaFicha { get; private set; }
        [Column("Última consulta de ficha")]
        public DateTime? UltimaConsultaFicha { get; private set; }
        [Column("Nome do Titular")]
        public string? NomeTitular { get; private set; }
        [Column("Observações")]
        public string? Observacoes { get; private set; }
        public bool? Activo { get; private set; }
        public int? Estado { get; private set; }
        [Column("ID Razão")]
        public int? IDRazao { get; private set; }
        [Column("ID Funcionário")]
        public int? IDFuncionario { get; private set; }
        [Column("Ficha Clínica")]
        public bool? FichaClinica { get; private set; }
        public bool? Confirmado { get; private set; }
        [Column("Grupo Sanguineo")]
        public string? GrupoSanguineo { get; private set; }
        public string? Alergias { get; private set; }
        [Column("Raça")]
        public string? Raca { get; private set; }
        public string? Peso { get; private set; }
        public string? Altura { get; private set; }
        public string? Bairro { get; private set; }
        [Column("E-mail")]
        public string? Email { get; private set; }
        public string? Nacionalidade { get; private set; }
        public string? Localizacao { get; private set; }
        public string? BIPath { get; private set; }
        public string? CartaoPath { get; private set; }
        public string? BIUpload { get; private set; }
        public string? CartaoUpload { get; private set; }
        public DateTime? BIDataUploadFirst { get; private set; }
        public DateTime? BIDataUploadLast { get; private set; }
        public DateTime? CartaoDataUploadFirst { get; private set; }
        public DateTime? CartaoDataUploadLast { get; private set; }
        public int? BIIDUploadFirst { get; private set; }
        public int? BIIDUploadLast { get; private set; }
        public int? CartaoIDUploadFirst { get; private set; }
        public int? CartaoIDUploadLast { get; private set; }


        public int GetIdade()
        {
            if (DataNascimento == null) return 0;
            DateTime today = DateTime.Today;
            TimeSpan age = (TimeSpan)(today - DataNascimento);
            return (int)(age.TotalDays / 365.25);
        }
    }
}