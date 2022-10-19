using FluentValidation;

namespace com.myapi.Application.DTO.Validations;

public class ProdutoDTOValidator : AbstractValidator<ProdutoDTO>
{
    public ProdutoDTOValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty()
            .NotNull()
            .WithMessage("Nome deve ser informado!");

        RuleFor(x => x.CodigoErp)
            .NotEmpty()
            .NotNull()
            .WithMessage("Codigo erp deve ser informado!");

        RuleFor(x => x.QuantidadeEstoque)
            .GreaterThan(0)
            .WithMessage("Quantidade de estoque deve ser informada!");

        RuleFor(x => x.Preco)
            .GreaterThan(0.0)
            .WithMessage("Preço deve ser informado!");
    }
}