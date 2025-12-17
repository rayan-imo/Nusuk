using FluentValidation;
using Nusuk.Services.Dtos;

namespace Nusuk.Services.Validators.Caravan;

public class CaravanValidator : AbstractValidator<CaravanDto>
{
    public CaravanValidator()
    {
        RuleFor(x => x.Name)
                .NotEmpty().WithMessage("من فضلك أدخل اسم االقافلة");
    }
}
