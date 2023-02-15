using TriagemCligest.Data;
using TriagemCligest.Models;

namespace TriagemCligest.Service
{
    public class TriagemService
    {
        private readonly TriagemContext _context;
        private readonly UtenteService _contextUtente;
        private readonly MarcacaoService _contextMarcacao;

        public TriagemService(TriagemContext context, UtenteService contextUtente, MarcacaoService contextMarcacao)
        {
            _contextMarcacao = contextMarcacao;
            _context = context; 
            _contextUtente= contextUtente;  
        }

        public List<Triagem> FindAll()
        {
            var queryTriagem = from t in _context.Triagem.ToList() select t;
            var queryUtente = from u in _contextUtente.FindAll() select u;
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

        public Triagem FindById(int id)
        {
            var queryTriagem = from t in _context.Triagem.ToList() select t;
            var queryUtente = from u in _contextUtente.FindAll() select u;
            var result = from a in queryTriagem join b in queryUtente on a.UtenteID equals b.ID where a.Id == id select new { a, b };
            //result = result.Where(qt => qt.a.Id == id.Value);
            Triagem triagem = result.Select(x => x.a).FirstOrDefault();
            triagem.Utente = result.Select(x => x.b).FirstOrDefault();
            return triagem;
        }
    }
}
