using MetaData.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DataAccessLayer.Mappings
{
    internal class ClienteMapConfig : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("CLIENTES");
            builder.Property(x => x.Nome).HasMaxLength(70).IsRequired().IsUnicode(false);
            builder.Property(x => x.CPF).IsFixedLength().HasMaxLength(11).IsUnicode(false).IsRequired();
            builder.HasIndex(x => x.CPF).IsUnique().HasDatabaseName("UQ_CLIENTE_CPF"); //"Está em where, usa index"
            builder.HasIndex(x => x.Nome);
            builder.Property(x => x.Telefone).IsRequired().HasMaxLength(15).IsUnicode(false);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(100).IsUnicode(false);
            builder.HasIndex(x => x.Email).IsUnique().HasDatabaseName("UQ_CLIENTE_EMAIL");
            builder.Property(x => x.DataNascimento).HasColumnType("date");
            builder.Property(x => x.Ativo).HasDefaultValue(true);
            builder.Property(x => x.TimeCreated).HasDefaultValueSql("getdate()");
        }
    }
}
