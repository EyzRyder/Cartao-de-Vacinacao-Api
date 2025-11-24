using api.Application.DTOs;
using FluentValidation;

namespace api.Application.Validators;

public class VaccineCreateValidator : AbstractValidator<VaccineCreateDto>
{
    public VaccineCreateValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("O nome da vacina é obrigatório.")
            .MinimumLength(2).WithMessage("A vacina deve ter no mínimo 2 caracteres.")
            .MaximumLength(120).WithMessage("A vacina deve ter no máximo 120 caracteres.");
    }
}
