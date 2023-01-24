using TriagemCligest.Models.Enum;

namespace TriagemCligest.Models
{
    public class TriagemClinicaGeral
    {
        public Boolean Patologia { get; set; }
        public String DescricaoPatologia { get; set; }
        public Boolean Alergia { get; set; }
        public String DescricaoAlergia { get; set; }
        public Boolean Medicamento { get; set; }
        public String DescricaoMedicamento { get; set; }

        public ClassificacaoPeleMucosa ClassificacaoPeleMucosa { get; set; }

        public Boolean Ictericia { get; set; }
        public String LesaoCutanea { get; set; }
        public ClassificacaoQueimadura ClassificacaoQueimadura { get; set; }
        public String LocalQueimadura { get; set; }

        public Boolean Epistaxe { get; set; }
        public Boolean Cianose { get; set; }
        public Boolean Tosse { get; set; }
        public Boolean Expectoracao { get; set; }
        public ClassificacaoExpectoracao ClassificacaoExpectoracao { get; set; }
        public double SaturacaoOxigenio { get; set; }
        public string LocalSianose { get; set; }

        public ClassificacaoGenitoUrinario ClassificacaoGenitoUrinario { get; set; }
        public bool Metrorragia { get; set; } = false;
        public bool Dismenorreia { get; set; } = false;
        public bool SecrecaoUretralVaginal { get; set; } = false;

        public bool Hematemese { get; set; } = false;
        public bool Vomito { get; set; } = false;
        public bool Melena { get; set; } = false;
        public bool Enterorragia { get; set; } = false;
        public bool Obstipacao { get; set; } = false;
        public bool Diarreia { get; set; } = false;
    }
}
