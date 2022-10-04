using com.myapi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.myapi.Domain.Repositories
{
    public interface IPessoaRepository
    {
        Task<Pessoa> GetByIdAsync(int id);
        Task<ICollection<Pessoa>> GetAllAsync();
        Task<Pessoa> CreateAsync(Pessoa pessoa);
        Task EditAsync(Pessoa pessoa);
        Task DeleteAsync(Pessoa pessoa);
    }
}
