using api.Application.DTOs;
using FluentValidation;

namespace api.Application.Validators;

public class VaccinationRecordCreateValidator : AbstractValidator<VaccinationRecordCreateDto>
{
    public VaccinationRecordCreateValidator()
    {
        RuleFor(x => x.VacinaId)
            .NotEmpty().WithMessage("VacinaId é obrigatório.");

        RuleFor(x => x.Dose)
            .NotEmpty().WithMessage("A dose é obrigatória.")
            .IsInEnum().WithMessage("Dose inválida.");

        RuleFor(x => x.DateAplication)
            .LessThanOrEqualTo(DateTime.UtcNow)
            .WithMessage("A data de aplicação não pode ser no futuro.");
    }
}
