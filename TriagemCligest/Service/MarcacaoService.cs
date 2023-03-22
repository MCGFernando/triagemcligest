using System.Collections.Generic;
using TriagemCligest.Data;
using TriagemCligest.Models;

namespace TriagemCligest.Service
{
    public class MarcacaoService
    {
        private readonly CligestSIContext _context;
        private readonly CligestMainContext _contextMain;

        public MarcacaoService(CligestSIContext context, CligestMainContext contextMain)
        {
            _context = context;
            _contextMain = contextMain; 
        }
        public List<Marcacao> FindAll()
        {
            var result = from obj in _context.Marcacao.Where(m => m.Datam == DateTime.Today).ToList() 
                         join f in _contextMain.Funcionario.ToList() on obj.FuncionarioID equals f.ID join e in _contextMain.Especialidade.ToList() on f.EspecialidadeId equals e.Id
                         select new { obj, f };
            //result = result.Where(m => m.Datam == DateTime.Today);
            List < Marcacao > lstMarcacao = new List<Marcacao>();   
            foreach (var r in result)
            {
                Marcacao marcacao = r.obj;
                marcacao.Funcionario = r.f;
                lstMarcacao.Add(marcacao);  
                
            }
            return lstMarcacao;
        }
        public Marcacao FindById(int id)
        {
            if (!MarcacaoExists(id)) { return null; }
            return _context.Marcacao.FirstOrDefault(e => e.ID == id);
        }

        public List<Marcacao> FindBySeach(string? Pesquisar)
        {
            //var result = from obj in _context.Marcacao select obj;
            //result = result.Where(m => m.Datam == DateTime.Today && m.Utente.Contains(Pesquisar));
            var result = from obj in _context.Marcacao.Where(m => m.Datam == DateTime.Today && m.Utente.Contains(Pesquisar)).ToList()
                         join f in _contextMain.Funcionario.ToList() on obj.FuncionarioID equals f.ID
                         join e in _contextMain.Especialidade.ToList() on f.EspecialidadeId equals e.Id
                         //where obj.Datam == DateTime.Today && obj.Utente.Contains(Pesquisar)
                         select new { obj, f };
            //result = result.Where(m => m.Datam == DateTime.Today);
            List<Marcacao> lstMarcacao = new List<Marcacao>();
            foreach (var r in result)
            {
                Marcacao marcacao = r.obj;
                marcacao.Funcionario = r.f;
                lstMarcacao.Add(marcacao);

            }
            return lstMarcacao;
        }

        private bool MarcacaoExists(int id)
        {
            return _context.Marcacao.Any(e => e.ID == id);
        }
    }
}
