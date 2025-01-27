using Financas.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financas.Data.Mappings
{
    public class FaturaMapping : IEntityTypeConfiguration<Fatura>
    {
        public void Configure(EntityTypeBuilder<Fatura> builder)
        {
            builder.HasKey(f => f.Id);
            builder.Property(f => f.DateOnly).IsRequired().HasColumnType("date");
            builder.Property(f=> f.Mes).IsRequired().HasColumnType("integer");
            builder.HasMany(f=> f.Transacoes).WithOne(t=> t.Fatura).HasForeignKey(t=> t.FaturaId);

            builder.ToTable("Faturas");
        }
    }
}
