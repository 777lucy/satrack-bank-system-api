using FluentValidation;
using SatrackBankSystem.Api.Application.Commands;
using SatrackBankSystem.Domain.Enums;

namespace SatrackBankSystem.Api.Validations
{
    public class CreateClientCommandValidator : AbstractValidator<CreateClientCommand>
    {
        public CreateClientCommandValidator()
        {
            When(x => x.ClientType == ClientType.Business, () =>
            {
                RuleFor(x => x.LegalRepresentativeIdentification)
                    .NotEmpty().WithMessage("La identificación del representante legal es obligatoria para cliente tipo empresa.");

                RuleFor(x => x.LegalRepresentativeName)
                    .NotEmpty().WithMessage("El nombre del representante legal es obligatoria para cliente tipo empresa");

                RuleFor(x => x.LegalRepresentativePhone)
                    .NotEmpty().WithMessage("El telléfono del representante legal es obligatoria para cliente tipo empresa");
            });
        }
    }
}
