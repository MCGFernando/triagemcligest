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
            var operador = Operador.FirstOrDefault(o => o.Login == username && o.Password == password);

            if (operador != null)
            {
                utilizador = new()
                {
                    Id = operador.ID,
                    Nome = operador.UserName,
                    Senha = operador.Password,
                    Funcao = Models.Enum.Funcao.OPERADOR,
                };
                return utilizador;
            }

            var funcionario = Funcionario.FirstOrDefault(o => o.Login == username && o.Password == password);

            if (funcionario != null)
            {
                utilizador = new()
                {
                    Id = funcionario.ID,
                    Nome = funcionario.NomeAbreviado,
                    Senha = funcionario.Password,
                    Funcao = Models.Enum.Funcao.FUNCIONARIO,
                    IdEspecializade = funcionario.Especialidade,
                    //Especializade = _context.Especialidade.FirstOrDefault(e => e.Id == funcionario.Especialidade).Esp
                };
                return utilizador;
            }
            return utilizador;
        }
    }
}
