using TriagemCligest.Data;
using TriagemCligest.Models;

namespace TriagemCligest.Service
{
    public class OperadorService
    {
        private readonly CligestMainContext _context;
        public OperadorService(CligestMainContext context)
        {
            _context = context;
        }
        public List<Operador> FindAll()
        {
            return _context.Operador.ToList();
        }
        public Operador FindById(int id)
        {
            if (!OperadorExists(id)) { return null; }
            return _context.Operador.FirstOrDefault(e => e.ID == id);
        }
        private bool OperadorExists(int id)
        {
            return _context.Operador.Any(e => e.ID == id);
        }
    }
}
