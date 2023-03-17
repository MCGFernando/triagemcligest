using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TriagemCligest.Models
{
    [Serializable]
    [Table("FE")]
    public class FE
    {
        [Key]
        [Column("ID Ficha de Episódio")]
        public int Id { get;  set; }
        [Column("N Documento")]
        public string? NDocumento { get;  set; }
        [Column("Data de emissão")]
        public DateTime? DataDeEmissao { get;  set; }
        [Column("Data do documento")]
        public DateTime? DatadoDocumento { get;  set; }
        [Column("Destinatário")]
        public string? Destinatario { get;  set; }
        [Column("Destinatário2")]
        public string? Destinatario2 { get;  set; }
        [Column("Default EXT")]
        public int? DefaultEXT { get;  set; }
        [Column("Default Utente")]
        public string? DefaultUtente { get;  set; }
        [Column("Default Coef")]
        public double? DefaultCoef { get;  set; }
        [Column("Default Data")]
        public DateTime? DefaultData { get;  set; }
        [Column("Default Area")]
        public int? DefaultArea { get;  set; }
        [Column("Default Item")]
        public int? DefaultItem { get;  set; }
        [Column("ID Footer")]
        public int? IdFooter { get;  set; }

        public double? Total { get;  set; }

        public double? Desconto { get;  set; }
        [Column("Autorização")]
        public string? Autorizacao { get;  set; }
        [Column("ID funcionário")]
        public int? Idfuncionario { get;  set; }

        public int? Estado { get;  set; }
        [Column("ID Tipo de Documento")]
        public int? IdTipodeDocumento { get;  set; }
        [Column("ID entidade")]
        public int? IdEntidade { get;  set; }
        [Column("ID Tipo de entidade")]
        public int? IdTipoDeEntidade { get;  set; }

        public string? Entidade { get;  set; }

        public bool Kwanzas { get;  set; }
        [Column("Pro forma")]
        public bool Proforma { get;  set; }
        [Column("Data de Entrada")]
        public DateTime? DataDeEntrada { get;  set; }
        [Column("Data de Saída")]
        public DateTime? DataDeSaida { get;  set; }
        [Column("Nº de Processo")]
        public string? NdeProcesso { get;  set; }
        [Column("pago")]
        public bool Pago { get;  set; }
        [Column("Câmbio")]
        public double? Cambio { get;  set; }
        [Column("Total Kwanzas")]
        public double TotalKwanzas { get;  set; }
        [Column("ID Funcionário Last")]
        public int? IdFuncionarioLast { get;  set; }

        public DateTime? Hora { get;  set; }

        public DateTime? Data { get;  set; }
        [Column("Preçário")]
        public double? Precario { get;  set; }

        public bool? Integrado { get;  set; }
        [Column("Lançamento")]
        public string? Lancamento { get;  set; }
        [Column("Localização")]
        public string? Localizacao { get;  set; }
        [Column("Código Conta Corrente")]
        public string? CodigoContaCorrente { get;  set; }
        [Column("Funcionário que admitiu")]
        public string? FuncionarioQueAdmitiu { get;  set; }

        public string? Operador { get;  set; }
        [Column("Tipo de episódio")]
        public string? TipoDeEpisodio { get;  set; }

        public string? Notas { get;  set; }
        [Column("Marcação")]
        public int? Marcacao { get;  set; }
        [Column("Centro de responsabilidade")]
        public string? CentroDeResponsabilidade { get;  set; }

        public int? ICD10 { get;  set; }
        [Column("IVA Total")]
        public double? IvaTotal { get;  set; }

    }
}
