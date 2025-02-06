using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NerdStore.Catalogo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Catalogo.Data.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(250)");
            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(500)");
            builder.Property(p => p.Imagem)
                .IsRequired()
                .HasColumnType("varchar(250)");
            builder.OwnsOne(p => p.Dimensoes, dm =>
            {
                dm.Property(d => d.Altura)
                    .HasColumnName("Altura")
                    .HasColumnType("int");
                dm.Property(d => d.Largura)
                    .HasColumnName("Largura")
                    .HasColumnType("int");
                dm.Property(d => d.Profundidade)
                    .HasColumnName("Profundidade")
                    .HasColumnType("int");
            });
            builder.ToTable("Produtos");
        }
    }

    public class CategoriaMapping : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Codigo)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(250)");


            // 1 : N => Categorias : Produtos
            builder.HasMany(c => c.Produtos)
                .WithOne(p => p.Categoria)
                .HasForeignKey(p => p.CategoriaId);
            builder.ToTable("Categorias");
        }
    }
}
