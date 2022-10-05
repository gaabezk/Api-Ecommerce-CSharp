using com.myapi.Application.DTO;

namespace com.myapi.Application.Services.Interfaces;

public interface IPessoaService
{
    Task<ResultService<PessoaDTO>> CreateAsync(PessoaDTO pessoaDto);
    Task<ResultService<ICollection<PessoaDTO>>> GetAllAsync();
}