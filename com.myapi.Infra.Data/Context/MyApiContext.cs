using com.myapi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace com.myapi.Infra.Data.Context;

public class MyApiContext : DbContext
{
    public MyApiContext(DbContextOptions<MyApiContext> options) : base(options)
    {
    }

    public DbSet<Pessoa> Pessoa { get; set; }
    public DbSet<Produto> Produto { get; set; }
    public DbSet<Compra> Compra { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyApiContext).Assembly);
    }
}