using com.myapi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace com.myapi.Infra.Data.Maps;

public class CompraMap : IEntityTypeConfiguration<Compra>
{
    public void Configure(EntityTypeBuilder<Compra> builder)
    {
        builder.ToTable("compra");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id_compra")
            .UseIdentityColumn();

        builder.Property(x => x.ProdutoId)
            .HasColumnName("id_produto");

        builder.Property(x => x.PessoaId)
            .HasColumnName("id_pessoa");

        builder.Property(x => x.Date)
            .HasColumnName("data_compra");

        builder.HasOne(x => x.Pessoa)
            .WithMany(x => x.Compras);

        builder.HasOne(x => x.Produto)
            .WithMany(x => x.Compras);
    }
}