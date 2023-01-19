using TriagemCligest.Models.Enum;

namespace TriagemCligest.Models
{
    public class DadosVitais
    {
        public int TensaoArterialSitolica { get; set; }
        public int TensaoArterialDiastolica { get; set; }
        public Double Temperatura { get; set; }
        public ClassificacaoTemperatura ClassificacaoTemperatura { get; set; }
        public Double Peso { get; set; }
        public int FrequeciaCardiaca { get; set; }
        public ClassificacaoFrequenciaCardiaca ClassificacaoFrequenciaCardiaca { get; set; }
        public int FrequeciaRespiratoria { get; set; }
        public ClassificacaoFrequenciaRespiratoria ClassificacaoFrequenciaRespiratoria { get; set; }

        public string GetTensaoArterial() { return TensaoArterialSitolica + " : " + TensaoArterialDiastolica; }

        public ClassificacaoTemperatura GetClassificacaoTemperatua(Double temperatura)
        {
            if (temperatura < 35.5) return ClassificacaoTemperatura.HIPOTERMIA;
            if (temperatura >= 35.5 && temperatura <=37.5) return ClassificacaoTemperatura.NORMAL;
            if (temperatura > 37.5) return ClassificacaoTemperatura.HIPERTERMIA;
            return ClassificacaoTemperatura.ERROR;
        }
    }
}