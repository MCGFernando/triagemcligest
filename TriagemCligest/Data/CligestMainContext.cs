using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TriagemCligest.Models;

namespace TriagemCligest.Data
{
    public class CligestMainContext : DbContext
    {
        public CligestMainContext (DbContextOptions<CligestMainContext> options)
            : base(options)
        {
        }

        public DbSet<Funcionario> Funcionario { get; set; } = default!;

        public DbSet<Especialidade> Especialidade { get; set; }

        public DbSet<Operador> Operador { get; set; }

        

        public DbSet<TriagemCligest.Models.EntidadeAssistida>? EntidadeAssistida { get; set; }
    }
}
