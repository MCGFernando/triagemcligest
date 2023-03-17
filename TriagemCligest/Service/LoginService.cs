using Microsoft.EntityFrameworkCore;
using TriagemCligest.Data;
using TriagemCligest.Models;

namespace TriagemCligest.Service
{
    public class LoginService
    {
        private readonly CligestMainContext _context;
        private DbSet<Operador> Operador { get; set; }  
        private DbSet<Funcionario> Funcionario { get; set; }

        public LoginService(CligestMainContext context)
        {
            _context = context;
            Operador = _context.Set<Operador>();
            Funcionario = _context.Set<Funcionario>();
        }

        public Utilizador CheckUserCredentials(string username, string password)
        {
            Utilizador utilizador = null;
            var operador = _context.Operador
                
                .FirstOrDefault(o => o.Login == username && o.Password == password);

            if (operador != null)
            {
                utilizador = new()
                {
                    Id = operador.ID,
                    Nome = "Enf(a). " + operador.UserName,
                    Senha = operador.Password,
                    Funcao = operador.AccessLevel== 1000? Models.Enum.Funcao.ADMIN : Models.Enum.Funcao.OPERADOR,
                    IdEspecializade = -1,
                    Especializade = "Enfemeiro",
                };
                return utilizador;
            }

            var funcionario = _context.Funcionario
                .Include(e => e.Especialidade)
                .FirstOrDefault(o => o.Login == username && o.Password == password);

            if (funcionario != null)
            {
                utilizador = new()
                {
                    Id = funcionario.ID,
                    Nome = "Dr(a). " + funcionario.NomeAbreviado,
                    Senha = funcionario.Password,
                    Funcao = Models.Enum.Funcao.FUNCIONARIO,
                    IdEspecializade = funcionario.EspecialidadeId,
                    Especializade = funcionario.Especialidade.Esp,
                };
                return utilizador;
            }
            return utilizador;
        }
    }
}
