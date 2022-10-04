using com.myapi.Domain.Enum;
using com.myapi.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.myapi.Domain.Entities
{
    public sealed class Pessoa
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public string Cpf { get; private set; }
        public string Telefone { get; private set; }
        public string Role { get; private set; } = Enum.Role.ROLE_USER.ToString();
        public ICollection<Compra> Compras { get; set; }


        public Pessoa(string nome, string email, string senha, string cpf, string telefone)
        {
            Validation(nome, email, senha, cpf, telefone);
        }

        public Pessoa(int id,string nome, string email, string senha, string cpf, string telefone)
        {
            DomainValidationException.When(id < 0, "ID deve ser maior que zero");
            Id= id;
            Validation(nome, email, senha, cpf, telefone);
        }

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


        }

    }
}
