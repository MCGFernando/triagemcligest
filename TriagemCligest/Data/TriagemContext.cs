using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TriagemCligest.Models;

namespace TriagemCligest.Data
{
    public class TriagemContext : DbContext
    {
        public TriagemContext (DbContextOptions<TriagemContext> options)
            : base(options)
        {
        }

        public DbSet<TriagemCligest.Models.Triagem> Triagem { get; set; } = default!;

        
    }
}
