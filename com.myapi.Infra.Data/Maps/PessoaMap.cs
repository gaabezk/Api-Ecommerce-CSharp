using com.myapi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace com.myapi.Infra.Data.Maps;

public class PessoaMap : IEntityTypeConfiguration<Pessoa>
{
    public void Configure(EntityTypeBuilder<Pessoa> builder)
    {
        builder.ToTable("pessoa");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .HasColumnName("id_pessoa")
            .UseIdentityColumn();

        builder.Property(c => c.Nome)
            .HasColumnName("nome");

        builder.Property(c => c.Email)
            .HasColumnName("email");

        builder.Property(c => c.Senha)
            .HasColumnName("senha");

        builder.Property(c => c.Cpf)
            .HasColumnName("cpf");

        builder.Property(c => c.Telefone)
            .HasColumnName("telefone");

        builder.Property(c => c.Role)
            .HasColumnName("role");

        builder.HasMany(c => c.Compras)
            .WithOne(p => p.Pessoa)
            .HasForeignKey(p => p.PessoaId);
    }
}