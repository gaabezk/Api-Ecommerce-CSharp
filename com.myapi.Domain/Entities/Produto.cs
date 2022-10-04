using com.myapi.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.myapi.Domain.Entities
{
    public sealed class Produto
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string CodigoErp { get; private set; }
        public int QuantidadeEstoque { get; private set; }
        public double Preco { get; private set; }
        public ICollection<Compra> Compras { get; set; }

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

        }


    }
}
