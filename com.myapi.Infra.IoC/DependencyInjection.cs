using com.myapi.Application.Mappings;
using com.myapi.Application.Services;
using com.myapi.Application.Services.Interfaces;
using com.myapi.Domain.Repositories;
using com.myapi.Infra.Data.Context;
using com.myapi.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace com.myapi.Infra.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<MyApiContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IPessoaRepository, PessoaRepository>();
        services.AddScoped<IProdutoRepository, ProdutoRepository>();
        services.AddScoped<ICompraRepository, CompraRepository>();
        services.AddScoped<IUnityOfWork, UnityOfWork>();
        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(typeof(DomainToDtoMapping));
        services.AddScoped<IPessoaService, PessoaService>();
        services.AddScoped<IProdutoService, ProdutoService>();
        services.AddScoped<ICompraService, CompraService>();
        return services;
    }
}