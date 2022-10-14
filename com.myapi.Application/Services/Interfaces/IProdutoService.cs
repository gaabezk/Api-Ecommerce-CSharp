using com.myapi.Application.DTO;

namespace com.myapi.Application.Services.Interfaces;

public interface IProdutoService
{
    Task<ResultService<ProdutoDTO>> CreateAsync(ProdutoDTO produtoDto);
    Task<ResultService<ICollection<ProdutoDTO>>> GetAllAsync();
    Task<ResultService<ProdutoDTO>> GetById(int id);
    Task<ResultService> UpdateAsync(ProdutoDTO produtoDto);
    Task<ResultService> RemoveAsync(int id);
}