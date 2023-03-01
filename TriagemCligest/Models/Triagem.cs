using System;
using System.ComponentModel.DataAnnotations;
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
        [Display(Name = "Tipo de Ficha de Triagem")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório")]
        public TipoTriagem TipoTriagem { get; set; }

        [Display(Name ="Situação de Queixa")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório")]
        public string? SituacaoQueixa { get; set; }
        /*************************DADOS VITAIS*****************************/
        [Display(Name = "Sístole")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório")]
        [Range(50, 250, ErrorMessage = "O Campo {0} deve estar entre {1} e {2}")]
        public int TensaoArterialSitolica { get; set; }
        [Display(Name = "Diástole")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório")]
        [Range(50, 250, ErrorMessage = "O Campo {0} deve estar entre {1} e {2}")]
        public int TensaoArterialDiastolica { get; set; }
        
        public ClassificacaoTensaoArterial ClassificacaoTensaoArterial { get; set; }
        [Required(ErrorMessage = "O Campo {0} é Obrigatório")]
        [Range(10, 50, ErrorMessage = "O Campo {0} deve estar entre {1} e {2}")]
        public Double Temperatura { get; set; }
        [Required(ErrorMessage = "O Campo {0} é Obrigatório")]
        public ClassificacaoTemperatura ClassificacaoTemperatura { get; set; }
        [Required(ErrorMessage = "O Campo {0} é Obrigatório")]
        [Range(0.1, 500, ErrorMessage = "O Campo {0} deve estar entre {1} e {2}")]
        public Double Peso { get; set; }
        [Display(Name = "Frequência Cardíaca")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório")]
        public int FrequeciaCardiaca { get; set; }
        [Display(Name = "Classificação Cardíaca")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório")]
        public ClassificacaoFrequenciaCardiaca ClassificacaoFrequenciaCardiaca { get; set; }
        [Display(Name = "Frequência Respiratória")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório")]
        [Range(20, 200, ErrorMessage = "O Campo {0} deve estar entre {1} e {2}")]
        public int FrequeciaRespiratoria { get; set; }
        [Display(Name = "Classificação Respiratória")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório")]
        public ClassificacaoFrequenciaRespiratoria ClassificacaoFrequenciaRespiratoria { get; set; }
        /*************************FIM DADOS VITAIS*****************************/
        public bool Patologia { get; set; } = false;
        [Display(Name = "Descrição da Patologia")]
        public String? DescricaoPatologia { get; set; }
        public bool Alergia { get; set; } = false;
        [Display(Name = "Descrição da Alergia")]
        public String? DescricaoAlergia { get; set; }
        public bool Medicamento { get; set; } = false;
        [Display(Name = "Descrição do Medicamento")]
        public String? DescricaoMedicamento { get; set; }

        /*************************PELE E MUCOSA*****************************/
        [Display(Name = "Hidratação da Pele")]
        public ClassificacaoPeleMucosa? ClassificacaoPeleMucosa { get; set; }
        [Display(Name = "Icterícia")]
        public bool Ictericia { get; set; } = false;
        [Display(Name = "Lesão Cutânea")]
        public String? LesaoCutanea { get; set; }
        [Display(Name = "Grau da Queimadura")]
        public ClassificacaoQueimadura? ClassificacaoQueimadura { get; set; }
        [Display(Name = "Local da Queimadura")]
        public String? LocalQueimadura { get; set; }
        /*************************FIM PELE E MUCOSA*****************************/

        /*************************RESPIRATORIO*****************************/
        public bool Epistaxe { get; set; } = false;
        public bool Cianose { get; set; } = false;
        public bool Tosse { get; set; } = false;
        [Display(Name = "Expectoração")]
        public bool Expectoracao { get; set; } = false;
        [Display(Name = "Coloração da Expectoração")]
        public ClassificacaoExpectoracao? ClassificacaoExpectoracao { get; set; }
        [Display(Name = "Saturação de Oxigênio")]
        public double? SaturacaoOxigenio { get; set; }
        [Display(Name = "Local da Cianose")]
        public string? LocalCianose { get; set; }
        /*************************FIM RESPIRATORIO*****************************/

        /*************************GENITOURINARIO*****************************/
        [Display(Name = "Classificação Genitourinário")]
        public ClassificacaoGenitoUrinario? ClassificacaoGenitoUrinario { get; set; }
        public bool Metrorragia { get; set; } = false;
        public bool Dismenorreia { get; set; } = false;
        [Display(Name = "Secreção Uretral/Vaginal")]
        public bool SecrecaoUretralVaginal { get; set; } = false;
        /*************************FIM GENITOURINARIO*****************************/

        /*************************GASTROINTESTINAL*****************************/
        [Display(Name = "Hematêmese")]
        public bool Hematemese { get; set; } = false;
        [Display(Name = "Vómito")]
        public bool Vomito { get; set; } = false;
        public bool Melena { get; set; } = false;
        public bool Enterorragia { get; set; } = false;
        [Display(Name = "Obstipação")]
        public bool Obstipacao { get; set; } = false;
        [Display(Name = "Diarréia")]
        public bool Diarreia { get; set; } = false;
        /*************************FIM GASTROINTESTINAL*****************************/

        /*************************TRIAGEM GINECOLOGIA*****************************/
        [Display(Name = "Atraso Menstrual")]
        public bool AtrasoMenstrual { get; set; } = false;
        public bool Mioma { get; set; } = false;
        [Display(Name = "Quistos nos Ovários")]
        public bool QuistosOvarios { get; set; } = false;
        [Display(Name = "Corrimento Vaginal")]
        public bool CorrimentoVaginal { get; set; } = false;
        [Display(Name = "Característica Corrimento Vaginal")]
        public string? CaracteristicaCorrimentoVaginal { get; set; }
        [Display(Name = "Prurido Vaginal")]
        public bool PruridoVaginal { get; set; } = false;
        public bool Gravidez { get; set; } = false;
        [Display(Name = "Médico Assistente")]
        public string? MedicoAssistente { get; set; }
        /*************************FIM TRIAGEM GINECOLOGIA*****************************/

        /*************************TRIAGEM OBSTERICIA*****************************/
        [Display(Name = "Semanas de Gravidez")]
        public double? SemanaGravidez { get; set; }
        [Display(Name = "Contração Uterina")]
        public bool ContracaoUterina { get; set; } = false;
        public bool Hiperemese { get; set; } = false;
        [Display(Name = "Sinais de Desidratação")]
        public bool Desidratacao { get; set; } = false;
        [Display(Name = "Sinais de Abcesso Mamário")]
        public bool AbcessoMamario { get; set; } = false;
        [Display(Name = "Ingurgitamento Mamário")]
        public bool IngurgitamentoMamario { get; set; } = false;
        /*************************FIM TRIAGEM OBSTERICIA*****************************/

        /*************************TRIAGEM PEDIATRIA*****************************/
        [Display(Name = "Dispneia com uso de Musculatura Acessória")]
        public bool DispneiaMusculaturaAcessoria { get; set; } = false;
        [Display(Name = "Sangramento Nasal")]
        public bool SangramentoNasal { get; set; } = false;
        [Display(Name = "Fezes com Sangue")]
        public bool FezesSangue { get; set; } = false;
        [Display(Name = "Urina Com Sangue")]
        public bool UrinaComSangue { get; set; } = false;
        [Display(Name = "Dor à Micção")]
        public bool DorMiccao { get; set; } = false;
        [Display(Name = "Coloração da Pele")]
        public ClassificacaoColoracaoPele? ClassificacaoColoracaoPele { get; set; }
        [Display(Name = "Diurese Presente")]
        public ClassificacaoDiurese? ClassificacaoDiurese { get; set; }
        /*************************FIM TRIAGEM PEDIATRIA*****************************/

        [Column("DataRegisto")]
        public DateTime? DatarRgisto { get; set; }
        public DateTime DatarActualizacao { get; set; } = DateTime.Now;
        [Display(Name = "Hora de Chegada")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh\\:mm\\:ss}")]
        public TimeSpan? HoraChegada { get; set; }
        [Display(Name = "Hora do Atendimento Médico")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh\\:mm\\:ss}")]
        public TimeSpan? HoraAtendimentoMedico { get; set; }
        [Display(Name = "Hora do Acolhimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh\\:mm\\:ss}")]
        public TimeSpan? HoraAcolhimento { get; set; }
        [Display(Name = "Classificação da Triagem")]
        [Required(ErrorMessage = "O Campo {0} é Obrigatório")]
        public ClassificacaoTriagem ClassificacaoTriagem { get; set; }
        [Display(Name = "Estado")]
        public EstadoTriagem EstadoTriagem { get; set; }
        [Display(Name = "Unidade")]
        public ClassificacaoUnidade ClassificacaoUnidade { get; set; } = ClassificacaoUnidade.LDA;

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
