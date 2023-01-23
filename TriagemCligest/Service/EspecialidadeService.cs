using TriagemCligest.Data;
using TriagemCligest.Models;

namespace TriagemCligest.Service
{
    public class EspecialidadeService
    {
        private readonly CligestMainContext _context;

        public EspecialidadeService(CligestMainContext context)
        {
            _context = context;
        }

        public List<Especialidade> FindAll()
        {
            return _context.Especialidade.ToList(); 
        }

        public Especialidade FindById( int id)
        {
            if (!EspecialidadeExists(id)) { return null; }
            return _context.Especialidade.FirstOrDefault(e => e.Id == id);
        }



        private bool EspecialidadeExists(int id)
        {
            return _context.Especialidade.Any(e => e.Id == id);
        }
    }
}
