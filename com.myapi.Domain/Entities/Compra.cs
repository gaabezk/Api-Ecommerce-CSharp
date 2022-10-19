using com.myapi.Domain.Validations;

namespace com.myapi.Domain.Entities;

public sealed class Compra
{
    public Compra(int produtoId, int pessoaId)
    {
        Validation(produtoId, pessoaId);
    }

    public Compra(int id, int produtoId, int pessoaId)
    {
        DomainValidationException.When(id <= 0, "Id da compra deve ser informado");
        Id = id;
        Validation(produtoId, pessoaId);
    }
    
    public void Edit(int id, int produtoId, int pessoaId)
    {
        DomainValidationException.When(id <= 0, "Id da compra deve ser informado");
        Id = id;
        Validation(produtoId, pessoaId);
    }

    public int Id { get; private set; }
    public int ProdutoId { get; private set; }
    public int PessoaId { get; private set; }
    public DateTime Date { get; private set; }
    public Pessoa Pessoa { get; set; }
    public Produto Produto { get; set; }

    private void Validation(int produtoId, int pessoaId)
    {
        DomainValidationException.When(produtoId <= 0, "Id do produto deve ser informado");
        DomainValidationException.When(pessoaId <= 0, "Id do usuario deve ser informado");

        ProdutoId = produtoId;
        PessoaId = pessoaId;
        Date = DateTime.Now;
    }
}