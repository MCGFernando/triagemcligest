using TriagemCligest.Data;
using TriagemCligest.Models;

namespace TriagemCligest.Service
{
    public class FuncionarioService
    {
        private readonly CligestMainContext _context;

        public FuncionarioService(CligestMainContext context)
        {
            _context = context;
        }

        public List<Funcionario> FindAll()
        {
            return _context.Funcionario.ToList();
        }
        public Funcionario FindById(int id)
        {
            if (!FuncionarioExists(id)) { return null; }
            return _context.Funcionario.FirstOrDefault(e => e.ID == id);
        }

        private bool FuncionarioExists(int id)
        {
            return _context.Funcionario.Any(e => e.ID == id);
        }
    }
}
