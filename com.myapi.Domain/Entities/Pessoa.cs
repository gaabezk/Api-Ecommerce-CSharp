using com.myapi.Domain.Validations;

namespace com.myapi.Domain.Entities;

public sealed class Pessoa
{
    public Pessoa(string nome, string email, string senha, string cpf, string telefone)
    {
        Validation(nome, email, senha, cpf, telefone);
    }

    public Pessoa(int id, string nome, string email, string senha, string cpf, string telefone)
    {
        DomainValidationException.When(id < 0, "ID deve ser maior que zero");
        Id = id;
        Validation(nome, email, senha, cpf, telefone);
    }

    public int Id { get; }
    public string Nome { get; private set; }
    public string Email { get; private set; }
    public string Senha { get; private set; }
    public string Cpf { get; private set; }
    public string Telefone { get; private set; }
    public string Role { get; private set; }
    public ICollection<Compra> Compras { get; set; }

    private void Validation(string nome, string email, string senha, string cpf, string telefone)
    {
        DomainValidationException.When(string.IsNullOrEmpty(nome), "Nome deve ser informado");
        DomainValidationException.When(string.IsNullOrEmpty(email), "Email deve ser informado");
        DomainValidationException.When(string.IsNullOrEmpty(senha), "Senha deve ser informado");
        DomainValidationException.When(string.IsNullOrEmpty(cpf), "Cpf deve ser informado");
        DomainValidationException.When(string.IsNullOrEmpty(telefone), "Telefone deve ser informado");

        Nome = nome;
        Email = email;
        Senha = senha;
        Cpf = cpf;
        Telefone = telefone;
        Role = Enum.Role.ROLE_USER.ToString();
        Compras = new List<Compra>();
    }
}