using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoFromLuiz.Models;
using ProjetoFromLuiz.Data.Map;

namespace ProjetoFromLuiz.Data
{
    public class SistemaPessoasDBContext : DbContext
    {
        public SistemaPessoasDBContext(DbContextOptions<SistemaPessoasDBContext> options)
            : base(options)
        {

        }

        public DbSet<Pessoa> PessoaSistema { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PessoaMap());
            base.OnModelCreating(modelBuilder);
        }

        internal Pessoa FirstOrDefault(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }
    }
}
