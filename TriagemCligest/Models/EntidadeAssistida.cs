using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TriagemCligest.Models
{
    [Serializable]
    [Table("Entidade Assistida")]
    public class EntidadeAssistida
    {
        [Key]
        [Column("ID Entidade")]
        public int Id { get; set; }
        public string Entidade { get; set; }
        [Column("Tipo de contracto")]
        public int TipoDeContracto { get; set; }
        public bool Activa { get; set; }
        public string? Sigla { get; set; }
        [Column("Nº de conta corrente")]
        public string? NDeContaCorrente { get; set; }
        [Column("Cliente Externo")]
        public bool ClienteExterno { get; set; }
        public bool Actualizada { get; set; }
        public int? Protocolo { get; set; }
        [Column("Tipo de atendimento")]
        public int? TipoDeAtendimento { get; set; }
        [Column("Data de actualização")]
        public DateTime? DataDeActualizacao { get; set; }
        [Column("Preçário")]
        public double? Precario { get; set; }
        [Column("Localização")]
        public string? Localizacao { get; set; }
        [Column("Destinatário1")]
        public string? Destinatario1 { get; set; }
        [Column("Destinatário2")]
        public string? Destinatario2 { get; set; }
        [Column("ID Footer")]
        public int? IdFooter { get; set; }
        [Column("Gestor de Conta")]
        public int? GestorDeConta { get; set; }
        [Column("Protocolo Facturação")]
        public string? ProtocoloFacturacao { get; set; }
        [Column("Nº de Contribuinte")]
        public string? NDeContribuinte { get; set; }
        public string? Morada { get; set; }
        [Column("ID Preçário")]
        public int? IdPrecario { get; set; }
        [Column("Force Code")]
        public bool ForceCode { get; set; }
        [Column("Mask Code")]
        public int? MaskCode { get; set; }
        [Column("Code Example")]
        public string? CodeExample { get; set; }
        [Column("ID Série")]
        public int? IdSerie { get; set; }
        [Column("Gera Factura")]
        public bool GeraFactura { get; set; }
        public bool BI { get; set; }
        public bool Cartao { get; set; }
        public bool Guia { get; set; }
        public bool? Checkup { get; set; }
        public bool? USD { get; set; }
        public bool? IVA { get; set; }
        public bool? Flag1 { get; set; }
        public bool? Flag2 { get; set; }

    }
}
