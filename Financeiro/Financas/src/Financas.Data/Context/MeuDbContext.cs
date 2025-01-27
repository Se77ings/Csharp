using Financas.Business.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financas.Data.Context
{
    public class MeuDbContext : DbContext
    {
        // Para rodar o migration, preciso criar um projeto de aplicação, para colocar a connection string em algum lugar.
        // Como vai demandar algum tempo, vou fazer mais tarde.
        public DbSet<Fatura> Faturas { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MeuDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
