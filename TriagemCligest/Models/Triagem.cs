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
        /*************************DADOS VITAIS*****************************/
        public int TensaoArterialSitolica { get; set; }
        public int TensaoArterialDiastolica { get; set; }
        public Double Temperatura { get; set; }
        public ClassificacaoTemperatura ClassificacaoTemperatura { get; set; }
        public Double Peso { get; set; }
        public int FrequeciaCardiaca { get; set; }
        public ClassificacaoFrequenciaCardiaca ClassificacaoFrequenciaCardiaca { get; set; }
        public int FrequeciaRespiratoria { get; set; }
        public ClassificacaoFrequenciaRespiratoria ClassificacaoFrequenciaRespiratoria { get; set; }
        /*************************FIM DADOS VITAIS*****************************/
        public bool? Patologia { get; set; } = false;
        public String? DescricaoPatologia { get; set; }
        public bool? Alergia { get; set; } = false;
        public String? DescricaoAlergia { get; set; }
        public bool? Medicamento { get; set; } = false;
        public String? DescricaoMedicamento { get; set; }

        /*************************PELE E MUCOSA*****************************/
        public ClassificacaoPeleMucosa? ClassificacaoPeleMucosa { get; set; }

        public bool? Ictericia { get; set; } = false;
        public String? LesaoCutanea { get; set; }
        public ClassificacaoQueimadura? ClassificacaoQueimadura { get; set; }
        public String? LocalQueimadura { get; set; }
        /*************************FIM PELE E MUCOSA*****************************/

        /*************************RESPIRATORIO*****************************/
        public bool? Epistaxe { get; set; } = false;
        public bool? Cianose { get; set; } = false;
        public bool? Tosse { get; set; } = false;
        public bool? Expectoracao { get; set; } = false;
        public ClassificacaoExpectoracao? ClassificacaoExpectoracao { get; set; }
        public double? SaturacaoOxigenio { get; set; }
        public string? LocalCianose { get; set; }
        /*************************FIM RESPIRATORIO*****************************/

        /*************************GENITOURINARIO*****************************/
        public ClassificacaoGenitoUrinario? ClassificacaoGenitoUrinario { get; set; }
        public bool Metrorragia { get; set; } = false;
        public bool Dismenorreia { get; set; } = false;
        public bool SecrecaoUretralVaginal { get; set; } = false;
        /*************************FIM GENITOURINARIO*****************************/

        /*************************GASTROINTESTINAL*****************************/
        public bool Hematemese { get; set; } = false;
        public bool Vomito { get; set; } = false;
        public bool Melena { get; set; } = false;
        public bool Enterorragia { get; set; } = false;
        public bool Obstipacao { get; set; } = false;
        public bool Diarreia { get; set; } = false;
        /*************************FIM GASTROINTESTINAL*****************************/

        /*************************TRIAGEM GINECOLOGIA*****************************/
        public bool? AtrasoMenstrual { get; set; } = false;
        public bool? Mioma { get; set; } = false;
        public bool? QuistosOvarios { get; set; } = false;
        public bool? CorrimentoVaginal { get; set; } = false;
        public string? CaracteristicaCorrimentoVaginal { get; set; }
        public bool? PruridoVaginal { get; set; } = false;
        public bool? Gravidez { get; set; } = false;
        public string? MedicoAssistente { get; set; }
        /*************************FIM TRIAGEM GINECOLOGIA*****************************/

        /*************************TRIAGEM OBSTERICIA*****************************/
        public double? SemanaGravidez { get; set; }
        public bool? ContracaoUterina { get; set; } = false;
        public bool? Hiperemese { get; set; } = false;
        public bool? Desidratacao { get; set; } = false;
        public bool? AbcessoMamario { get; set; } = false;
        public bool? IngurgitamentoMamario { get; set; } = false;
        /*************************FIM TRIAGEM OBSTERICIA*****************************/

        /*************************TRIAGEM PEDIATRIA*****************************/
        public bool? DispneiaMusculaturaAcessoria { get; set; } = false;
        public bool? SangramentoNasal { get; set; } = false;
        public bool? FezesSangue { get; set; } = false;
        public bool? UrinaComSangue { get; set; } = false;
        public bool? DorMiccao { get; set; } = false;
        public ClassificacaoColoracaoPele? ClassificacaoColoracaoPele { get; set; }
        public ClassificacaoDiurese? ClassificacaoDiurese { get; set; }
        /*************************FIM TRIAGEM PEDIATRIA*****************************/

        [Column("dataregisto")]
        public DateTime? DatarRgisto { get; set; }
        public DateTime DatarActualizacao { get; set; } = DateTime.Now;
        [Column("hora_chegada")]
        public TimeSpan? HoraChegada { get; set; }
        [Column("hora_atendimento_medico")]
        public TimeSpan? HoraAtendimentoMedico { get; set; }
        [Column("hora_acolhimento")]
        public TimeSpan? HoraAcolhimento { get; set; }
        public ClassificacaoTriagem ClassificacaoTriagem { get; set; }
        public EstadoTriagem EstadoTriagem { get; set; }
        public ClassificacaoUnidade ClassificacaoUnidade { get; set; }

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

        public string GetTensaoArterial() { return TensaoArterialSitolica + " : " + TensaoArterialDiastolica; }

        public ClassificacaoTemperatura GetClassificacaoTemperatua(Double temperatura)
        {
            if (temperatura < 35.5) return ClassificacaoTemperatura.HIPOTERMIA;
            if (temperatura >= 35.5 && temperatura <= 37.5) return ClassificacaoTemperatura.NORMAL;
            if (temperatura > 37.5) return ClassificacaoTemperatura.HIPERTERMIA;
            return ClassificacaoTemperatura.NORMAL;
        }

        public ClassificacaoFrequenciaRespiratoria GetClassificacaoRespiratoria(Double frequenciaRespiratoria)
        {
            if (frequenciaRespiratoria < 16) return ClassificacaoFrequenciaRespiratoria.DISPNEICO;
            if (frequenciaRespiratoria >= 16 && frequenciaRespiratoria <= 30) return ClassificacaoFrequenciaRespiratoria.NORMAL;
            if (frequenciaRespiratoria > 30) return ClassificacaoFrequenciaRespiratoria.EUPNEICO;
            return ClassificacaoFrequenciaRespiratoria.NORMAL;
        }
        public ClassificacaoFrequenciaCardiaca GetClassificacaoCardiaca(Double frequenciaCardiaca)
        {
            if (frequenciaCardiaca < 60) return ClassificacaoFrequenciaCardiaca.BRADICARDICO;
            if (frequenciaCardiaca >= 60 && frequenciaCardiaca <= 90) return ClassificacaoFrequenciaCardiaca.NORMOCARDICO;
            if (frequenciaCardiaca > 90) return ClassificacaoFrequenciaCardiaca.TAQUICARDICO;
            return ClassificacaoFrequenciaCardiaca.NORMOCARDICO;
        }
    }
}
