using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TriagemCligest.Models;

namespace TriagemCligest.Data
{
    public class CligestSIContext : DbContext
    {
        public CligestSIContext (DbContextOptions<CligestSIContext> options)
            : base(options)
        {
        }

        public DbSet<Marcacao> Marcacao { get; set; } = default!;
    }
}
