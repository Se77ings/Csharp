using CursoEFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoEFCore.Data
{
    internal class ApplicationContext : DbContext
    {

        private static readonly ILoggerFactory _logger = LoggerFactory.Create(p => p.AddConsole());
        public DbSet<Pedido> Pedidos { get; set; }

        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Cliente> Clientes { get; set; }    
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=CursoEFCore;Integrated Security=True"); -> Essa string foi a mostrada no curso, mas não funcionou bem.

            optionsBuilder.UseLoggerFactory(_logger).EnableSensitiveDataLogging().UseSqlServer(@"Server=localhost;Database=CursoEFCore;Trusted_Connection=True;TrustServerCertificate=True;", p => p.EnableRetryOnFailure(maxRetryCount:2));
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }
    }
}
