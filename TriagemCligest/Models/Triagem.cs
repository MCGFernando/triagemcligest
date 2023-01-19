using System;
using System.ComponentModel.DataAnnotations.Schema;
using TriagemCligest.Models.Enum;

namespace TriagemCligest.Models
{
    public class Triagem
    {
        public int Id { get; set; }
        public int UtenteID { get; set; }
        public Utente? Utente { get; set;}
        public int MarcacaoID { get; set; }
        public Marcacao? Marcacao { get; set; }
        public TipoTriagem TipoTriagem { get; set; }


        public string? SituacaoQueixa { get; set; }
        public DadosVitais DadosVitais { get; set; }

        public Boolean Patologia { get; set; }
        public String DescricaoPatologia { get; set; }
        public Boolean Alergia { get; set; }
        public String DescricaoAlergia { get; set; }
        public Boolean Medicamento { get; set; }
        public String DescricaoMedicamento { get; set; }


        [Column("dataregisto")]
        public DateTime? DatarRgisto { get; set; } = DateTime.Now;
        [Column("hora_chegada")]
        public TimeSpan? HoraChegada { get; set; }
        [Column("hora_atendimento_medico")]
        public TimeSpan? HoraAtendimentoMedico { get; set; }
        [Column("hora_acolhimento")]
        public TimeSpan? HoraAcolhimento { get; set; }
        public ClassificacaoTriagem ClassificacaoTriagem { get; set; }
        public EstadoTriagem EstadoTriagem { get; set; }


        public string EnumToColor(ClassificacaoTriagem classificacaoTriagem)
        {
            switch (classificacaoTriagem)
            {
                case Enum.ClassificacaoTriagem.AMARELO: return "#F8E82F";
                case Enum.ClassificacaoTriagem.LARANJA: return "#F8B32F";
                case Enum.ClassificacaoTriagem.VERMELHO: return "#CC3E20";
                case Enum.ClassificacaoTriagem.VERDE: return "#58CC20";
                case Enum.ClassificacaoTriagem.AZUL: return "#209BCC";
                default:
                    throw new ArgumentException("Invalid color value", nameof(classificacaoTriagem));
            }
        }
    }
}
