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
    public class TransacaoMapping : IEntityTypeConfiguration<Transacao>
    {
        public void Configure(EntityTypeBuilder<Transacao> builder)
        {

            builder.HasKey(t => t.Id);
            builder.Property(t => t.Data).HasColumnType("date").IsRequired();
            builder.Property(t => t.Descricao).HasColumnType("varchar(100)").IsRequired();
            builder.Property(t => t.TipoTransacao).HasColumnType("integer").IsRequired();
            builder.Property(t => t.Valor).HasColumnType("decimal(10,2)").IsRequired();

            builder.HasOne(p => p.Fatura).WithMany(f => f.Transacoes).HasForeignKey(p => p.FaturaId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(t => t.ContaOrigem)  // 🔹 Relacionamento com Conta
                .WithMany() // 🔹 Sem referência inversa (não precisa de ICollection<Transacao> na Conta)
                .HasForeignKey(t => t.ContaOrigemId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Transacoes");
        }
    }
}
