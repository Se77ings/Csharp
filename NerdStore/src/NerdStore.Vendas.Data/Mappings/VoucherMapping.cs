﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using NerdStore.Vendas.Domain;

namespace NerdStore.Vendas.Data.Mappings
{
    public class VoucherMapping : IEntityTypeConfiguration<Voucher>
    {
        public void Configure(EntityTypeBuilder<Voucher> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Codigo).IsRequired().HasColumnType("varchar(100)");

            builder.HasMany(c => c.Pedidos).WithOne(c => c.Voucher).HasForeignKey(c => c.VoucherId);

            builder.ToTable("Vouchers");
        }
    }
}
