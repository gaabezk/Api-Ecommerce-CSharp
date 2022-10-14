using com.myapi.Domain.Entities;
using com.myapi.Domain.Repositories;
using com.myapi.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace com.myapi.Infra.Data.Repositories;

public class ProdutoRepository : IProdutoRepository
{
    private readonly MyApiContext _db;

    public ProdutoRepository(MyApiContext db)
    {
        _db = db;
    }

    public async Task<Produto> CreateAsync(Produto produto)
    {
        _db.Add(produto);
        await _db.SaveChangesAsync();
        return produto;
    }

    public async Task DeleteAsync(Produto produto)
    {
        _db.Remove(produto);
        await _db.SaveChangesAsync();
    }

    public async Task<int> GetIdByCodigoErpAsync(string codigoErp)
    {
        return (await _db.Produtos.FirstOrDefaultAsync(x => x.CodigoErp == codigoErp))?.Id ?? 0;  // se tiver informacao retorno Id se nao retorna 0
    }

    public async Task EditAsync(Produto produto)
    {
        _db.Update(produto);
        await _db.SaveChangesAsync();
    }

    public async Task<ICollection<Produto>> GetAllAsync()
    {
        return await _db.Produtos.ToListAsync();
    }

    public async Task<Produto> GetByIdAsync(int id)
    {
        return await _db.Produtos.FirstOrDefaultAsync(x => x.Id == id);
    }
}