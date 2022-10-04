using com.myapi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.myapi.Domain.Repositories
{
    public interface IProdutoRepository
    {
        Task<Produto> GetByIdAsync(int id);
        Task<ICollection<Produto>> GetAllAsync();
        Task<Produto> CreateAsync(Produto produto);
        Task EditAsync(Produto produto);
        Task DeleteAsync(Produto produto);
    }
}
