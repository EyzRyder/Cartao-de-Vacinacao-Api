using api.Application.DTOs;
using FluentValidation;

namespace api.Application.Validators;

public class VaccinationRecordCreateValidator : AbstractValidator<VaccinationRecordCreateDto>
{
    public VaccinationRecordCreateValidator()
    {
        RuleFor(x => x.VaccineId)
            .NotEmpty().WithMessage("VacineId é obrigatório.");
        RuleFor(x => x.PersonId)
            .NotEmpty().WithMessage("PersonId é obrigatório.");

        RuleFor(x => x.Dose)
            .NotEmpty().WithMessage("A dose é obrigatória.")
            .IsInEnum().WithMessage("Dose inválida.");
    }
}
