using com.myapi.Application.DTO;

namespace com.myapi.Application.Services.Interfaces;

public interface ICompraService
{
    Task<ResultService<CompraDTO>> CreateAsync(CompraDTO comprasDto);
    Task<ResultService<ICollection<CompraDetalheDTO>>> GetAllAsync();
    Task<ResultService<CompraDetalheDTO>> GetById(int id);
    Task<ResultService<CompraDTO>> UpdateAsync(CompraDTO comprasDto);
    Task<ResultService> RemoveAsync(int id);
}