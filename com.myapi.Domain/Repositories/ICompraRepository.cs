using com.myapi.Domain.Entities;

namespace com.myapi.Infra.Data.Repositories;

public interface ICompraRepository
{
    Task<Compra> GetByIdAsync(int id);
    Task<ICollection<Compra>> GetAllAsync();
    Task<Compra> CreateAsync(Compra compras);
    Task EditAsync(Compra compra);
    Task DeleteAsync(Compra compra);
    Task<ICollection<Compra>> GetByPessoaIdAsync(int pessoaId);
    Task<ICollection<Compra>> GetByProdutoIdAsync(int produtoId);
}