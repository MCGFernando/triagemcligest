using TriagemCligest.Data;
using TriagemCligest.Models;

namespace TriagemCligest.Service
{
    public class MarcacaoService
    {
        private readonly CligestSIContext _context;

        public MarcacaoService(CligestSIContext context)
        {
            _context = context;
        }
        public List<Marcacao> FindAll()
        {
            var result = from obj in _context.Marcacao select obj;
            result = result.Where(m => m.Datam == DateTime.Today);
            return result.ToList();
        }
        public Marcacao FindById(int id)
        {
            if (!MarcacaoExists(id)) { return null; }
            return _context.Marcacao.FirstOrDefault(e => e.ID == id);
        }

        private bool MarcacaoExists(int id)
        {
            return _context.Marcacao.Any(e => e.ID == id);
        }
    }
}
