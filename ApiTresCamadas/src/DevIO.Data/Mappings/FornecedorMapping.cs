using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Data.Mappings
{
    public class FornecedorMapping : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.HasKey(p=> p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Nome).IsRequired().HasColumnType("varchar(14)");

            builder.HasOne(p => p.Endereco).WithOne(e=> e.Fornecedor);

            builder.HasMany(p => p.Produtos).WithOne(p=> p.Fornecedor).HasForeignKey(p=> p.FornecedorID);

            builder.ToTable("Fornecedores");
        }
    }
}
