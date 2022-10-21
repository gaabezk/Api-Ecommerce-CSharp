using com.myapi.Domain.Repositories;
using com.myapi.Infra.Data.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace com.myapi.Infra.Data.Repositories;

public class UnityOfWork : IUnityOfWork
{
    private readonly MyApiContext _db;
    private IDbContextTransaction _transaction;

    public UnityOfWork(MyApiContext db)
    {
        _db = db;
    }

    public async Task BeginTransaction()
    {
        _transaction = await _db.Database.BeginTransactionAsync();
    }

    public async Task Commit()
    {
        await _transaction.CommitAsync();
    }

    public async Task Rollback()
    {
        await _transaction.RollbackAsync();
    }
    
    public void Dispose()
    {
        _transaction?.Dispose();
    }
}