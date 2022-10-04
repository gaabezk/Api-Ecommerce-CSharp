using com.myapi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.myapi.Infra.Data.Maps
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("produto");
            builder.HasKey(x => x.Id);

            builder.Property(c => c.Id)
                .HasColumnName("id_produto")
                .UseIdentityColumn();

            builder.Property(c => c.Nome)
                .HasColumnName("nome");

            builder.Property(c => c.CodigoErp)
                .HasColumnName("codigo_erp");

            builder.Property(c => c.QuantidadeEstoque)
                .HasColumnName("quantidade_estoque");

            builder.Property(c => c.Preco)
                .HasColumnName("preco");

            builder.HasMany(c => c.Compras)
                .WithOne(p => p.Produto)
                .HasForeignKey(p => p.ProdutoId);

        }
    }
}
