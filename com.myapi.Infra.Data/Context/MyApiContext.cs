using com.myapi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace com.myapi.Infra.Data.Context
{
    public class MyApiContext : DbContext
    {
        public MyApiContext(DbContextOptions<MyApiContext> options) : base(options) { }

        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Compra> Compras { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyApiContext).Assembly);

        }


    }
}
