using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TriagemCligest.Models;

namespace TriagemCligest.Data
{
    public class CligestUContext : DbContext
    {
        public CligestUContext (DbContextOptions<CligestUContext> options)
            : base(options)
        {
        }

        public DbSet<Utente> Utente { get; set; } = default!;
    }
}
