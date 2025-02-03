using Financas.Business.Models;
using Financas.Business.Models.Tipos;
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
        public MeuDbContext(DbContextOptions<MeuDbContext> options) : base(options)
        {
        }
        // Para rodar o migration, preciso criar um projeto de aplicação, para colocar a connection string em algum lugar.
        // Como vai demandar algum tempo, vou fazer mais tarde.
        public DbSet<Fatura> Faturas { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }

        public DbSet<Conta> Contas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MeuDbContext).Assembly);
       
            modelBuilder.Entity<Transacao>()
                .HasDiscriminator<TipoTransacaoDetalhada>("TipoTransacaoDetalhada")
                .HasValue<TransacaoAVista>(TipoTransacaoDetalhada.AVista)
                .HasValue<TransacaoAPrazo>(TipoTransacaoDetalhada.APrazo)
                .HasValue<TransacaoCartao>(TipoTransacaoDetalhada.Cartao);

        
            base.OnModelCreating(modelBuilder);
        }
    }
}
