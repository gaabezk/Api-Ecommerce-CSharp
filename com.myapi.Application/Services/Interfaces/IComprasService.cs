using com.myapi.Application.DTO;

namespace com.myapi.Application.Services.Interfaces;

public interface ICompraService
{
    Task<ResultService<CompraDTO>> CreateAsync(CompraDTO comprasDto);
    Task<ResultService<ICollection<CompraDTO>>> GetAllAsync();
    Task<ResultService<CompraDTO>> GetById(int id);
    Task<ResultService> UpdateAsync(CompraDTO comprasDto);
    Task<ResultService> RemoveAsync(int id);
}