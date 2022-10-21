using com.myapi.Domain.Entities;
using com.myapi.Domain.FiltersDb;

namespace com.myapi.Domain.Repositories;

public interface IPessoaRepository
{
    Task<Pessoa> GetByIdAsync(int id);
    Task<ICollection<Pessoa>> GetAllAsync();
    Task<Pessoa> CreateAsync(Pessoa pessoa);
    Task EditAsync(Pessoa pessoa);
    Task DeleteAsync(Pessoa pessoa);
    Task<int> GetIdByCpfAsync(string cpf);
    Task<PagedBaseResponse<Pessoa>> GetPageAsync(PessoaFilterDb request);
}