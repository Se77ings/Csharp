﻿using Financeiro.Business.Aggregates;
using Financeiro.Business.Aggregates.Direito;
using Financeiro.Business.Aggregates.Obrigação;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Financeiro.Infra.Mappings
{
	public class CompetenciaMapping : IEntityTypeConfiguration<Competencia>
	{
		public void Configure(EntityTypeBuilder<Competencia> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Mes).IsRequired().HasMaxLength(10);
			builder.Property(x => x.Ano).IsRequired();
			builder.HasMany<ContasAReceber>("_contasAReceber").WithOne(x=> x.Competencia).HasForeignKey(x => x.CompetenciaId).OnDelete(DeleteBehavior.Restrict);
			builder.HasMany<DespesaAVista>("_contasAPagar").WithOne(x => x.Competencia).HasForeignKey(x => x.CompetenciaId).OnDelete(DeleteBehavior.Restrict);
			builder.HasMany<DespesaCartao>("_contasAPagar").WithOne(x => x.Competencia).HasForeignKey(x => x.CompetenciaId).OnDelete(DeleteBehavior.Restrict);
		}
	}
}
