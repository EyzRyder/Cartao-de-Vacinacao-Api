using api.Application.DTOs;
using FluentValidation;

namespace api.Application.Validators;

public class PersonCreateValidator : AbstractValidator<PersonCreateDto>
{
    public PersonCreateValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("O nome é obrigatório.")
            .MinimumLength(2).WithMessage("O nome deve ter no mínimo 2 caracteres.")
            .MaximumLength(100).WithMessage("O nome deve ter no máximo 100 caracteres.");
    }
}
