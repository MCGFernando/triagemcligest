using TriagemCligest.Data;
using TriagemCligest.Models;
using TriagemCligest.Service.Exception;

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
            var result = from a in _context.Triagem join b in _contextU.Utente on a.UtenteID equals b.ID select new { a, b };
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
            var result = from t in _context.Triagem.ToList() join u in _contextU.Utente.ToList() on t.UtenteID equals u.ID where u.Nome.Contains(search)  || u.ID == (int.TryParse(search, out  idUtente) ? idUtente : 0) select new { t, u }; 

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
            /*var queryTriagem = from t in _context.Triagem.ToList() select t;
            var queryUtente = from u in _contextU.Utente select u;*/
            var result = from a in _context.Triagem join b in _contextU.Utente on a.UtenteID equals b.ID where a.Id == id select new { a, b };
            //result = result.Where(qt => qt.a.Id == id.Value);
            Triagem triagem = result.Select(x => x.a).FirstOrDefault();
            triagem.Utente = result.Select(x => x.b).FirstOrDefault();
            return triagem;
        }
        public void Update(Triagem triagem) 
        {
            if (!_context.Triagem.Any(t => t.Id == triagem.Id))
            {
                throw new NotFoundException("Id não encontrado");
            }
            try
            {
                _context.Update(triagem);   
                _context.SaveChanges();
            }
            catch (DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
