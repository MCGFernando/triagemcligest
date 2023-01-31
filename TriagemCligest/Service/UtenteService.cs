using TriagemCligest.Data;
using TriagemCligest.Models;

namespace TriagemCligest.Service
{
    public class UtenteService
    {
        private readonly CligestUContext _context;

        public UtenteService(CligestUContext context)
        {
            _context = context;
        }
        public List<Utente> FindAll()
        {
            return _context.Utente.ToList();
        }
        public Utente FindById(int id)
        {
            if (!UtenteExists(id)) { return null; }
            return _context.Utente.FirstOrDefault(e => e.ID == id);
        }

        public List<Utente> FindBySearch(string search)
        {
            
            return _context.Utente.Where(u => u.Nome.Contains(search))
                .Take(10)
                .ToList();
        }
        private bool UtenteExists(int id)
        {
            return _context.Utente.Any(e => e.ID == id);
        }

    }
}
