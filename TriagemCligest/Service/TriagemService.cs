using Microsoft.Data.SqlClient.Server;
using Microsoft.Win32;
using NuGet.Protocol.Plugins;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TriagemCligest.Data;
using TriagemCligest.Models;
using TriagemCligest.Models.Enum;
using TriagemCligest.Service.Exception;
using static System.Net.Mime.MediaTypeNames;

namespace TriagemCligest.Service
{
    public class TriagemService
    {
        private readonly TriagemContext _context;
        private readonly CligestMainContext _contextMain;
        private readonly CligestSIContext _contextSI;
        private readonly CligestUContext _contextU;
        //private readonly UtenteService _contextUtente;
        //private readonly MarcacaoService _contextMarcacao;

        public TriagemService(TriagemContext context, CligestUContext contextU, CligestMainContext contextMain, CligestSIContext contextSI)
        {
            _context = context;
            _contextMain = contextMain;
            _contextSI = contextSI;
            _contextU = contextU;
        }


        public List<Triagem> FindAll()
        {
            var resultGroup = from t in _context.Triagem.ToList()
                         group t by new { t.IdOriginal, t.UtenteID } into grp
                         where grp.Count() >= 1
                         select new
                         {
                             Id = grp.Max(t => t.Id),
                             IdOriginal = grp.Key.IdOriginal,
                             Versao = grp.Max(t => t.Versao),
                             UtenteID = grp.Key.UtenteID
                         };

            var result = from t in resultGroup join a in _context.Triagem on t.Id equals a.Id join b in _contextU.Utente on a.UtenteID equals b.ID select new { a, b };
            //if (user.Funcao == Funcao.FUNCIONARIO) result = result.Where(r => r.a.Marcacao.FuncionarioID == user.Id);

            List<Triagem> lstTriagem = new List<Triagem>();
            foreach (var item in result)
            {
                Triagem triagem = item.a;
                triagem.Utente = item.b;
                lstTriagem.Add(triagem);
            }

            return lstTriagem;
        }

        public List<Triagem> FindBySearch(string? search)
        {
            int idUtente;
            var resultGroup = from t in _context.Triagem.ToList()
                         group t by new { t.IdOriginal, t.UtenteID } into grp
                         where grp.Count() >= 1
                         select new
                         {
                             Id = grp.Max(t => t.Id),
                             IdOriginal = grp.Key.IdOriginal,
                             Versao = grp.Max(t => t.Versao),
                             UtenteID = grp.Key.UtenteID
                         };
            var result = from r in resultGroup join t in _context.Triagem.ToList() on r.Id equals t.Id join u in _contextU.Utente.ToList() on t.UtenteID equals u.ID where u.Nome.Contains(search) || u.ID == (int.TryParse(search, out idUtente) ? idUtente : 0) select new { t, u };

            List<Triagem> lstTriagem = new List<Triagem>();
            foreach (var item in result)
            {
                Triagem triagem = item.t;
                triagem.Utente = item.u;
                lstTriagem.Add(triagem);
            }

            return lstTriagem;
        }

        public Triagem FindById(int id)
        {
            
            var result = from a in _context.Triagem.ToList() join b in _contextU.Utente.ToList() on a.UtenteID equals b.ID where a.Id == id select new { a, b };
            //result = result.Where(qt => qt.a.Id == id.Value);
            Triagem triagem = result.Select(x => x.a).FirstOrDefault();
            triagem.Utente = result.Select(x => x.b).FirstOrDefault();
            return triagem;
        }

        public List<Triagem> FindByVersionId(int id)
        {

            var result = from a in _context.Triagem.ToList() join b in _contextU.Utente.ToList() on a.UtenteID equals b.ID where a.IdOriginal == id select new { a, b };
            List<Triagem> lstTriagem = new List<Triagem>();
            foreach (var item in result)
            {
                Triagem triagem = item.a;
                triagem.Utente = item.b;
                lstTriagem.Add(triagem);
            }
            return lstTriagem;
        }

        public List<EntidadeAssistida> FindEntidadeAssistidaAll()
        {
            return _contextMain.EntidadeAssistida.Take(5). ToList();
        }

        /*public Funcionario FindById(int id)
        {
            if (!FuncionarioExists(id)) { return null; }
            return _context.Funcionario.FirstOrDefault(e => e.ID == id);
        }*/
        public void Insert(Triagem triagem)
        {
            InsertFE(triagem);  
            triagem.DataRegisto  = DateTime.Now;
            _context.Add(triagem);
            _context.SaveChanges();
            triagem.IdOriginal = triagem.Id;
            _context.Update(triagem);
            _context.SaveChanges();
            if(triagem.TipoTriagem == TipoTriagem.URGENCIA)
            {
                InsertFE(triagem);
            }
        }
        public void Update(Triagem triagem)
        {
            if (!_context.Triagem.Any(t => t.Id == triagem.Id))
            {
                throw new NotFoundException("Id não encontrado");
            }
            try
            {
                Triagem tri = new()
                {
                    UtenteID = triagem.UtenteID,
                    Versao = triagem.Versao + 1,    
                    MarcacaoID = triagem.MarcacaoID,
                    TipoFichaAtendimento = triagem.TipoFichaAtendimento,
                    Accao = Models.Enum.Accao.UPDATE,
                    FuncionarioID= triagem.FuncionarioID,
                    TipoTriagem = triagem.TipoTriagem,
                    EscalaDor = triagem.EscalaDor,
                    IdOriginal = triagem.IdOriginal,
                    EspecialidadeID = triagem.EspecialidadeID,
                    EntidadeAssistidaID = triagem.EntidadeAssistidaID,
                    ActualizadoPor = triagem.ActualizadoPor,
                    SituacaoQueixa = triagem.SituacaoQueixa,
                    TensaoArterialSitolica = triagem.TensaoArterialSitolica,
                    TensaoArterialDiastolica = triagem.TensaoArterialDiastolica,
                    ClassificacaoTensaoArterial = triagem.ClassificacaoTensaoArterial,
                    Temperatura = triagem.Temperatura,
                    ClassificacaoTemperatura = triagem.ClassificacaoTemperatura,
                    Peso = triagem.Peso,
                    FrequeciaCardiaca = triagem.FrequeciaCardiaca,
                    ClassificacaoFrequenciaCardiaca = triagem.ClassificacaoFrequenciaCardiaca,
                    FrequeciaRespiratoria = triagem.FrequeciaRespiratoria,
                    ClassificacaoFrequenciaRespiratoria = triagem.ClassificacaoFrequenciaRespiratoria,
                    Patologia = triagem.Patologia,
                    DescricaoPatologia = triagem.DescricaoPatologia,
                    Alergia = triagem.Alergia,
                    DescricaoAlergia = triagem.DescricaoAlergia,
                    Medicamento = triagem.Medicamento,
                    DescricaoMedicamento = triagem.DescricaoMedicamento,
                    ClassificacaoPeleMucosa = triagem.ClassificacaoPeleMucosa,
                    Ictericia = triagem.Ictericia,
                    LesaoCutanea = triagem.LesaoCutanea,
                    ClassificacaoQueimadura = triagem.ClassificacaoQueimadura,
                    LocalQueimadura = triagem.LocalQueimadura,
                    Epistaxe = triagem.Epistaxe,
                    Cianose = triagem.Cianose,
                    Tosse = triagem.Tosse,
                    Expectoracao = triagem.Expectoracao,
                    ClassificacaoExpectoracao = triagem.ClassificacaoExpectoracao,
                    SaturacaoOxigenio = triagem.SaturacaoOxigenio,
                    LocalCianose = triagem.LocalCianose,
                    ClassificacaoGenitoUrinario = triagem.ClassificacaoGenitoUrinario,
                    Metrorragia = triagem.Metrorragia,
                    Dismenorreia = triagem.Dismenorreia,
                    SecrecaoUretralVaginal = triagem.SecrecaoUretralVaginal,
                    Hematemese = triagem.Hematemese,
                    Vomito = triagem.Vomito,
                    Melena = triagem.Melena,
                    Enterorragia = triagem.Enterorragia,
                    Obstipacao = triagem.Obstipacao,
                    Diarreia = triagem.Diarreia,
                    AtrasoMenstrual = triagem.AtrasoMenstrual,
                    Mioma = triagem.Mioma,
                    QuistosOvarios = triagem.QuistosOvarios,
                    CorrimentoVaginal = triagem.CorrimentoVaginal,
                    CaracteristicaCorrimentoVaginal = triagem.CaracteristicaCorrimentoVaginal,
                    PruridoVaginal = triagem.PruridoVaginal,
                    Gravidez = triagem.Gravidez,
                    MedicoAssistente = triagem.MedicoAssistente,
                    SemanaGravidez = triagem.SemanaGravidez,
                    ContracaoUterina = triagem.ContracaoUterina,
                    Hiperemese = triagem.Hiperemese,
                    Desidratacao = triagem.Desidratacao,
                    AbcessoMamario = triagem.AbcessoMamario,
                    IngurgitamentoMamario = triagem.IngurgitamentoMamario,
                    DispneiaMusculaturaAcessoria = triagem.DispneiaMusculaturaAcessoria,
                    SangramentoNasal = triagem.SangramentoNasal,
                    FezesSangue = triagem.FezesSangue,
                    UrinaComSangue = triagem.UrinaComSangue,
                    DorMiccao = triagem.DorMiccao,
                    ClassificacaoColoracaoPele = triagem.ClassificacaoColoracaoPele,
                    ClassificacaoDiurese = triagem.ClassificacaoDiurese,
                    DataActualizacao = DateTime.Now,
                    //DataRegisto = triagem.DataRegisto,  
                    RegistadoPor = triagem.RegistadoPor,
                    HoraChegada = triagem.HoraChegada,
                    HoraAtendimentoMedico = triagem.HoraAtendimentoMedico,
                    HoraAcolhimento = triagem.HoraAcolhimento,
                    ClassificacaoTriagem = triagem.ClassificacaoTriagem,
                    EstadoTriagem = triagem.EstadoTriagem,
                    ClassificacaoUnidade = triagem.ClassificacaoUnidade
                };
                _context.Add(tri);
                _context.SaveChanges();
            }
            catch (DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

        public void Delete(Triagem triagem)
        {
            if (!_context.Triagem.Any(t => t.Id == triagem.Id))
            {
                throw new NotFoundException("Id não encontrado");
            }
            try
            {
                Triagem tri = new()
                {
                    UtenteID = triagem.UtenteID,
                    Versao = triagem.Versao + 1,
                    MarcacaoID = triagem.MarcacaoID,
                    TipoFichaAtendimento = triagem.TipoFichaAtendimento,
                    Accao = Models.Enum.Accao.DELETE,
                    TipoTriagem = triagem.TipoTriagem,
                    FuncionarioID= triagem.FuncionarioID,
                    EscalaDor = triagem.EscalaDor,
                    IdOriginal = triagem.IdOriginal,
                    EspecialidadeID = triagem.EspecialidadeID,
                    EntidadeAssistidaID = triagem.EntidadeAssistidaID,
                    ActualizadoPor = triagem.ActualizadoPor,
                    SituacaoQueixa = triagem.SituacaoQueixa,
                    TensaoArterialSitolica = triagem.TensaoArterialSitolica,
                    TensaoArterialDiastolica = triagem.TensaoArterialDiastolica,
                    ClassificacaoTensaoArterial = triagem.ClassificacaoTensaoArterial,
                    Temperatura = triagem.Temperatura,
                    ClassificacaoTemperatura = triagem.ClassificacaoTemperatura,
                    Peso = triagem.Peso,
                    FrequeciaCardiaca = triagem.FrequeciaCardiaca,
                    ClassificacaoFrequenciaCardiaca = triagem.ClassificacaoFrequenciaCardiaca,
                    FrequeciaRespiratoria = triagem.FrequeciaRespiratoria,
                    ClassificacaoFrequenciaRespiratoria = triagem.ClassificacaoFrequenciaRespiratoria,
                    Patologia = triagem.Patologia,
                    DescricaoPatologia = triagem.DescricaoPatologia,
                    Alergia = triagem.Alergia,
                    DescricaoAlergia = triagem.DescricaoAlergia,
                    Medicamento = triagem.Medicamento,
                    DescricaoMedicamento = triagem.DescricaoMedicamento,
                    ClassificacaoPeleMucosa = triagem.ClassificacaoPeleMucosa,
                    Ictericia = triagem.Ictericia,
                    LesaoCutanea = triagem.LesaoCutanea,
                    ClassificacaoQueimadura = triagem.ClassificacaoQueimadura,
                    LocalQueimadura = triagem.LocalQueimadura,
                    Epistaxe = triagem.Epistaxe,
                    Cianose = triagem.Cianose,
                    Tosse = triagem.Tosse,
                    Expectoracao = triagem.Expectoracao,
                    ClassificacaoExpectoracao = triagem.ClassificacaoExpectoracao,
                    SaturacaoOxigenio = triagem.SaturacaoOxigenio,
                    LocalCianose = triagem.LocalCianose,
                    ClassificacaoGenitoUrinario = triagem.ClassificacaoGenitoUrinario,
                    Metrorragia = triagem.Metrorragia,
                    Dismenorreia = triagem.Dismenorreia,
                    SecrecaoUretralVaginal = triagem.SecrecaoUretralVaginal,
                    Hematemese = triagem.Hematemese,
                    Vomito = triagem.Vomito,
                    Melena = triagem.Melena,
                    Enterorragia = triagem.Enterorragia,
                    Obstipacao = triagem.Obstipacao,
                    Diarreia = triagem.Diarreia,
                    AtrasoMenstrual = triagem.AtrasoMenstrual,
                    Mioma = triagem.Mioma,
                    QuistosOvarios = triagem.QuistosOvarios,
                    CorrimentoVaginal = triagem.CorrimentoVaginal,
                    CaracteristicaCorrimentoVaginal = triagem.CaracteristicaCorrimentoVaginal,
                    PruridoVaginal = triagem.PruridoVaginal,
                    Gravidez = triagem.Gravidez,
                    MedicoAssistente = triagem.MedicoAssistente,
                    SemanaGravidez = triagem.SemanaGravidez,
                    ContracaoUterina = triagem.ContracaoUterina,
                    Hiperemese = triagem.Hiperemese,
                    Desidratacao = triagem.Desidratacao,
                    AbcessoMamario = triagem.AbcessoMamario,
                    IngurgitamentoMamario = triagem.IngurgitamentoMamario,
                    DispneiaMusculaturaAcessoria = triagem.DispneiaMusculaturaAcessoria,
                    SangramentoNasal = triagem.SangramentoNasal,
                    FezesSangue = triagem.FezesSangue,
                    UrinaComSangue = triagem.UrinaComSangue,
                    DorMiccao = triagem.DorMiccao,
                    ClassificacaoColoracaoPele = triagem.ClassificacaoColoracaoPele,
                    ClassificacaoDiurese = triagem.ClassificacaoDiurese,
                    DataActualizacao = DateTime.Now,
                    DataAnulacao= DateTime.Now, 
                    RegistadoPor = triagem.RegistadoPor,
                    AnuladoPor= triagem.AnuladoPor,
                    HoraChegada = triagem.HoraChegada,
                    HoraAtendimentoMedico = triagem.HoraAtendimentoMedico,
                    HoraAcolhimento = triagem.HoraAcolhimento,
                    ClassificacaoTriagem = triagem.ClassificacaoTriagem,
                    EstadoTriagem = Models.Enum.EstadoTriagem.ANULADA ,
                    ClassificacaoUnidade = triagem.ClassificacaoUnidade
                };
                _context.Add(tri);
                _context.SaveChanges();
            }
            catch (DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
        public void InsertMarcacao(Triagem triagem)
        { 
        
        }
            public void InsertFE(Triagem tri)
        {
            var triagem = FindById(tri.Id);

            FE fe = new FE();
            
            var entidade = _contextMain.EntidadeAssistida.FirstOrDefault(e => e.Id== triagem.EntidadeAssistidaID);
            
            var preco = entidade.IdPrecario;
            Console.WriteLine("preco " + preco);
            fe.Idfuncionario = triagem.ActualizadoPor;           
            fe.IdTipodeDocumento = 100;
            fe.Estado = 1;
            //fe.Autorizacao = triagem.Utente.IDUtenteExterno;
            fe.Cambio = 420;
            fe.IdEntidade = entidade.Id;
            fe.Entidade = entidade.Entidade;
            fe.DefaultUtente = triagem.Utente.Nome;
            //fe.DefaultEXT = triagem.Utente.ID;
            fe.DataDeEntrada = DateTime.Now;
            fe.DefaultCoef = 1;
            fe.DataDeSaida = DateTime.Now;
            fe.DefaultData = DateTime.Now;
            fe.CentroDeResponsabilidade = "Gil Ferreira";
            fe.Precario = preco;
            fe.Data = DateTime.Now;
            fe.Hora = DateTime.Now;
            fe.DefaultArea = 1;
            fe.IdFuncionarioLast = triagem.ActualizadoPor;
            fe.Marcacao = triagem.MarcacaoID;
            Console.WriteLine("fe.IdFuncionarioLast " + fe.IdFuncionarioLast);

            //var prefixo = _contextSI.g

            var contador = _contextMain.Contador.Where(c => c.Id == 100).Select(c => c.Valor);
            //fe.NdeProcesso = "" + (contador + 1) ;

            var idFELast = _contextSI.FE.ToList().Max(f => f.Id) ;
            fe.Id = (idFELast + 1); 
            Console.WriteLine("idFELast " + idFELast);
        }
    }
}
