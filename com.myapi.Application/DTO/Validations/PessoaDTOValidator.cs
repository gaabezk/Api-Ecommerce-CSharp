using FluentValidation;

namespace com.myapi.Application.DTO.Validations;

public class PessoaDTOValidator : AbstractValidator<PessoaDTO>
{
    public PessoaDTOValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty()
            .NotNull()
            .WithMessage("Nome deve ser informado!");

        RuleFor(x => x.Email)
            .NotEmpty()
            .NotNull()
            .WithMessage("Email deve ser informado!");

        RuleFor(x => x.Senha)
            .NotEmpty()
            .NotNull()
            .WithMessage("Senha deve ser informado!");

        RuleFor(x => x.Cpf)
            .NotEmpty()
            .NotNull()
            .WithMessage("CPF deve ser informado!");

        RuleFor(x => x.Telefone)
            .NotEmpty()
            .NotNull()
            .WithMessage("Telefone deve ser informado!");
    }
}