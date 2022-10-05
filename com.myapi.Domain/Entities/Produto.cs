using com.myapi.Domain.Validations;

namespace com.myapi.Domain.Entities;

public sealed class Produto
{
    public Produto(string nome, string codigoErp, int quantidadeEstoque, double preco)
    {
        Validation(nome, codigoErp, quantidadeEstoque, preco);
    }

    public Produto(int id, string nome, string codigoErp, int quantidadeEstoque, double preco)
    {
        DomainValidationException.When(id < 0, "Id do produto deve ser informado");
        Id = id;
        Validation(nome, codigoErp, quantidadeEstoque, preco);
    }

    public int Id { get; }
    public string Nome { get; private set; }
    public string CodigoErp { get; private set; }
    public int QuantidadeEstoque { get; private set; }
    public double Preco { get; private set; }
    public ICollection<Compra> Compras { get; set; }

    private void Validation(string nome, string codigoErp, int quantidadeEstoque, double preco)
    {
        DomainValidationException.When(string.IsNullOrEmpty(nome), "Nome deve ser informado");
        DomainValidationException.When(string.IsNullOrEmpty(codigoErp), "Codigo Erp deve ser informado");
        DomainValidationException.When(quantidadeEstoque < 0, "Quantidade de estoque deve ser informado");
        DomainValidationException.When(preco < 0.0, "Preco deve ser informado");

        Nome = nome;
        CodigoErp = codigoErp;
        QuantidadeEstoque = quantidadeEstoque;
        Preco = preco;
        Compras = new List<Compra>();
    }
}