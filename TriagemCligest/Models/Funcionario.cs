using System.ComponentModel.DataAnnotations.Schema;

namespace TriagemCligest.Models
{
    [Serializable]
    [Table("Funcionário")]
    public class Funcionario
    {
        [Column("ID Funcionário")]
        public int ID { get; private set; }
        [Column("ID Utente")]
        public int? IDUtente { get; private set; }
        [Column("Nº de Funcionário")]
        public string? NdeFuncionario { get; private set; }
        [Column("Tipo de trabalhador")]
        public string? TipoTrabalhador { get; private set; }
        [Column("Estatuto de trabalhador")]
        public int? EstatutoTrabalhador { get; private set; }

        public string? Nome { get; private set; }
        [Column("Nome Abreviado")]
        public string? NomeAbreviado { get; private set; }
        [Column("Contrato Nº")]
        public string? ContratoN { get; private set; }
        [Column("Conta Bancária")]
        public string? ContaBancaria { get; private set; }
        [Column("cargo")]
        public int? Cargo { get; private set; }

        public int? Especialidade { get; private set; }
        [Column("escalão")]
        public int? Escalao { get; private set; }
        [Column("login")]
        public string? Login { get; private set; }
        [Column("password")]
        public string? Password { get; private set; }
        [Column("telefone")]
        public string? Telefone { get; private set; }
        [Column("morada")]
        public string? Morada { get; private set; }
        [Column("responsabilidade")]
        public int? Responsabilidade { get; private set; }

        public bool? Activo { get; private set; }

        public int? Cidade { get; private set; }
        [Column("Centro de custo")]
        public int? CentroCusto { get; private set; }

        public bool? Receitar { get; private set; }
        [Column("DataAdmissão")]
        public DateTime? DataAdmissao { get; private set; }
        [Column("Data de Saída")]
        public DateTime? DataSaida { get; private set; }
        [Column("Data Nascimento")]
        public DateTime? DataNascimento { get; private set; }
        [Column("Estado Civil")]
        public string? EstadoCivil { get; private set; }

        public int? Area { get; private set; }

        public int? Local { get; private set; }
        [Column("Nº de Beneficiário Fiscal")]
        public string? NdeBeneficiarioFiscal { get; private set; }
        [Column("Nº de Segurança Social")]
        public string? NdeSegurancaSocial { get; private set; }
        [Column("Boletim de sanidade")]
        public DateTime? BoletimSanidade { get; private set; }
        [Column("Observações")]
        public string? Observacoes { get; private set; }

        public double? Adenda { get; private set; }
        [Column("Vencimento Real")]
        public double? VencimentoReal { get; private set; }
        [Column("Vencimento Base KZR")]
        public double? VencimentoBaseKZR { get; private set; }
        [Column("Dias Uteis")]
        public int? DiasUteis { get; private set; }
        [Column("Nº de CC")]
        public int? NdeCC { get; private set; }
        [Column("Mapa Interno")]
        public bool? MapaInterno { get; private set; }

        public int? Agenda { get; private set; }
        [Column("e-mail")]
        public string? Email { get; private set; }
    }
}
