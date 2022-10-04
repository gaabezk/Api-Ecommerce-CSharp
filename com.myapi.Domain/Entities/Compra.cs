using com.myapi.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.myapi.Domain.Entities
{
    public sealed class Compra
    {
        public int Id { get; private set; }
        public int ProdutoId { get; private set; }
        public int PessoaId { get; private set; }
        public DateTime Date { get; private set; } = DateTime.Now;
        public Pessoa Pessoa { get; set; }
        public Produto Produto { get; set; }

        public Compra(int produtoId, int pessoaId, DateTime date)
        {
            Validation(produtoId, pessoaId);

        }
        public Compra(int id, int produtoId, int pessoaId, DateTime date)
        {
            DomainValidationException.When(id < 0, "Id da compra deve ser informado")
            Id = id;
            Validation(produtoId, pessoaId);

        }

        private void Validation(int produtoId, int pessoaId)
        {
            DomainValidationException.When(produtoId < 0, "Id do produto deve ser informado");
            DomainValidationException.When(pessoaId < 0, "Id do usuario deve ser informado");

            ProdutoId = produtoId;
            PessoaId = pessoaId;

        }

    }
}
