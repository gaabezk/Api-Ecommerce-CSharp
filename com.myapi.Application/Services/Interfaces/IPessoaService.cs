using com.myapi.Application.DTO;
using com.myapi.Domain.FiltersDb;

namespace com.myapi.Application.Services.Interfaces;

public interface IPessoaService
{
    Task<ResultService<PessoaDTO>> CreateAsync(PessoaDTO pessoaDto);
    Task<ResultService<ICollection<PessoaDTO>>> GetAllAsync();
    Task<ResultService<PessoaDTO>> GetById(int id);
    Task<ResultService> UpdateAsync(PessoaDTO pessoaDto);
    Task<ResultService> RemoveAsync(int id);
    Task<ResultService<PagedBaseResponseDTO<PessoaDTO>>> GetPagedAsync(PessoaFilterDb pessoaFilterDb);
}