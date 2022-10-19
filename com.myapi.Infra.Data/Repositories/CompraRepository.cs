using com.myapi.Domain.Entities;
using com.myapi.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace com.myapi.Infra.Data.Repositories;

public class CompraRepository : ICompraRepository
{
    private readonly MyApiContext _db;

    public CompraRepository(MyApiContext db)
    {
        _db = db;
    }

    public async Task<Compra> CreateAsync(Compra compra)
    {
        _db.Add(compra);
        await _db.SaveChangesAsync();
        return compra;
    }

    public async Task DeleteAsync(Compra compra)
    {
        _db.Remove(compra);
        await _db.SaveChangesAsync();
    }

    public async Task EditAsync(Compra compra)
    {
        _db.Update(compra);
        await _db.SaveChangesAsync();
    }

    public async Task<Compra> GetByIdAsync(int id)
    {
        var compra = await _db.Compra
            .Include(x => x.Produto)
            .Include(x => x.Pessoa)
            .FirstOrDefaultAsync(x => x.Id == id);

        return compra;
    }

    public async Task<ICollection<Compra>> GetByPessoaIdAsync(int pessoaId)
    {
        return await _db.Compra
            .Include(x => x.Produto)
            .Include(x => x.Pessoa)
            .Where(x => x.PessoaId == pessoaId).ToListAsync();
    }

    public async Task<ICollection<Compra>> GetByProdutoIdAsync(int produtoId)
    {
        return await _db.Compra
            .Include(x => x.Produto)
            .Include(x => x.Pessoa)
            .Where(x => x.ProdutoId == produtoId).ToListAsync();
    }

    public async Task<ICollection<Compra>> GetAllAsync()
    {
        return await _db.Compra
            .Include(x => x.Produto)
            .Include(x => x.Pessoa)
            .ToListAsync();
    }
}