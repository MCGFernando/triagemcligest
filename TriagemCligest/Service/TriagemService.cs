using TriagemCligest.Data;
using TriagemCligest.Models;

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
            var queryTriagem = from t in _context.Triagem.ToList() select t;
            var queryUtente = from u in _contextU.Utente select u;
            var result = from a in queryTriagem join b in queryUtente on a.UtenteID equals b.ID select new { a, b };
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
            var qryUtente = from u in _contextU.Utente.ToList() select u;
            var qryTriagem = from t in _context.Triagem.ToList() select t;
            var result = from t in qryTriagem join u in qryUtente on t.UtenteID equals u.ID where u.Nome.Contains(search)  || u.ID == (int.TryParse(search, out  idUtente) ? idUtente : 0) select new { t, u }; 

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
            var queryTriagem = from t in _context.Triagem.ToList() select t;
            var queryUtente = from u in _contextU.Utente select u;
            var result = from a in queryTriagem join b in queryUtente on a.UtenteID equals b.ID where a.Id == id select new { a, b };
            //result = result.Where(qt => qt.a.Id == id.Value);
            Triagem triagem = result.Select(x => x.a).FirstOrDefault();
            triagem.Utente = result.Select(x => x.b).FirstOrDefault();
            return triagem;
        }
    }
}
