using com.myapi.Domain.Entities;

namespace com.myapi.Domain.Repositories;

public interface IProdutoRepository
{
    Task<Produto> GetByIdAsync(int id);
    Task<ICollection<Produto>> GetAllAsync();
    Task<Produto> CreateAsync(Produto produto);
    Task EditAsync(Produto produto);
    Task DeleteAsync(Produto produto);
    Task<int> GetIdByCodigoErpAsync(string codigoErp);
}