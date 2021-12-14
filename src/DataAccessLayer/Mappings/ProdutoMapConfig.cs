using MetaData.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Mappings
{
    internal class ProdutoMapConfig : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("PRODUTOS");
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(100).IsUnicode(false);
            builder.Property(x => x.Preco).HasPrecision(10, 2);
            builder.Property(x => x.Preco).HasPrecision(10, 2);
        }
    }
}
