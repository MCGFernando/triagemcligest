using TriagemCligest.Models.Enum;

namespace TriagemCligest.Models
{
    public class TriagemPediatria
    {
        public bool DispneiaMusculaturaAcessoria{ get; set; }
        public bool SangramentoNasal{ get; set; }
        public bool FezesSangue{ get; set; }
        public bool UrinaComSangue{ get; set; }
        public bool DorMiccao{ get; set; }
        public ClassificacaoColoracaoPele ClassificacaoColoracaoPele { get; set; }
        public ClassificacaoDiurese ClassificacaoDiurese { get; set; }
    }
}
