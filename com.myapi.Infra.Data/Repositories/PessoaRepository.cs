using com.myapi.Domain.Entities;
using com.myapi.Domain.Repositories;
using com.myapi.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace com.myapi.Infra.Data.Repositories;

public class PessoaRepository : IPessoaRepository
{
    private readonly MyApiContext _db;

    public PessoaRepository(MyApiContext db)
    {
        _db = db;
    }

    public async Task<Pessoa> CreateAsync(Pessoa pessoa)
    {
        _db.Add(pessoa);
        await _db.SaveChangesAsync();
        return pessoa;
    }

    public async Task DeleteAsync(Pessoa pessoa)
    {
        _db.Remove(pessoa);
        await _db.SaveChangesAsync();
    }

    public async Task<int> GetIdByCpfAsync(string cpf)
    {
        return (await _db.Pessoa.FirstOrDefaultAsync(x => x.Cpf == cpf))?.Id ??
               0; // se tiver informacao retorno Id se nao retorna 0
    }

    public async Task EditAsync(Pessoa pessoa)
    {
        _db.Update(pessoa);
        await _db.SaveChangesAsync();
    }

    public async Task<ICollection<Pessoa>> GetAllAsync()
    {
        return await _db.Pessoa.ToListAsync();
    }

    public async Task<Pessoa> GetByIdAsync(int id)
    {
        return await _db.Pessoa.FirstOrDefaultAsync(x => x.Id == id);
    }
}