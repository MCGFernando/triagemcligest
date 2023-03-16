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
        public int Id { get; private set; }
        [Column("N Documento")]
        public string? NDocumento { get; private set; }
        [Column("Data de emissão")]
        public DateTime? DataDeEmissao { get; private set; }
        [Column("Data do documento")]
        public DateTime? DatadoDocumento { get; private set; }
        [Column("Destinatário")]
        public string? Destinatario { get; private set; }
        [Column("Destinatário2")]
        public string? Destinatario2 { get; private set; }
        [Column("Default EXT")]
        public int? DefaultEXT { get; private set; }
        [Column("Default Utente")]
        public string? DefaultUtente { get; private set; }
        [Column("Default Coef")]
        public double? DefaultCoef { get; private set; }
        [Column("Default Data")]
        public DateTime? DefaultData { get; private set; }
        [Column("Default Area")]
        public int? DefaultArea { get; private set; }
        [Column("Default Item")]
        public int? DefaultItem { get; private set; }
        [Column("ID Footer")]
        public int? IdFooter { get; private set; }

        public double? Total { get; private set; }

        public double? Desconto { get; private set; }
        [Column("Autorização")]
        public string? Autorizacao { get; private set; }
        [Column("ID funcionário")]
        public int? Idfuncionario { get; private set; }

        public int? Estado { get; private set; }
        [Column("ID Tipo de Documento")]
        public int? IdTipodeDocumento { get; private set; }
        [Column("ID entidade")]
        public int? IdEntidade { get; private set; }
        [Column("ID Tipo de entidade")]
        public int? IdTipoDeEntidade { get; private set; }

        public string? Entidade { get; private set; }

        public bool Kwanzas { get; private set; }
        [Column("Pro forma")]
        public bool Proforma { get; private set; }
        [Column("Data de Entrada")]
        public DateTime? DataDeEntrada { get; private set; }
        [Column("Data de Saída")]
        public DateTime? DataDeSaida { get; private set; }
        [Column("Nº de Processo")]
        public string? NdeProcesso { get; private set; }
        [Column("pago")]
        public bool Pago { get; private set; }
        [Column("Câmbio")]
        public double? Cambio { get; private set; }
        [Column("Total Kwanzas")]
        public double TotalKwanzas { get; private set; }
        [Column("ID Funcionário Last")]
        public int? IdFuncionarioLast { get; private set; }

        public DateTime? Hora { get; private set; }

        public DateTime? Data { get; private set; }
        [Column("Preçário")]
        public double? Precario { get; private set; }

        public bool? Integrado { get; private set; }
        [Column("Lançamento")]
        public string? Lancamento { get; private set; }
        [Column("Localização")]
        public string? Localizacao { get; private set; }
        [Column("Código Conta Corrente")]
        public string? CodigoContaCorrente { get; private set; }
        [Column("Funcionário que admitiu")]
        public string? FuncionarioQueAdmitiu { get; private set; }

        public string? Operador { get; private set; }
        [Column("Tipo de episódio")]
        public string? TipoDeEpisodio { get; private set; }

        public string? Notas { get; private set; }
        [Column("Marcação")]
        public int? Marcacao { get; private set; }
        [Column("Centro de responsabilidade")]
        public string? CentroDeResponsabilidade { get; private set; }

        public int? ICD10 { get; private set; }
        [Column("IVA Total")]
        public double? IvaTotal { get; private set; }

    }
}
