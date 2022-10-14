using FluentValidation;

namespace com.myapi.Application.DTO.Validations;

public class ComprasDTOValidator : AbstractValidator<ComprasDTO>
{
    public ComprasDTOValidator()
    {
        RuleFor(x => x.CodigoErp)
            .NotEmpty()
            .NotNull()
            .WithMessage("Codigo Erp deve ser informado!");
        
        RuleFor(x => x.Cpf)
            .NotEmpty()
            .NotNull()
            .WithMessage("Cpf deve ser informado!");
    }
}