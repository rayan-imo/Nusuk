using FluentValidation;
using Nusuk.Services.Dtos;

namespace Nusuk.Services.Validators.Trip;

public class TripValidator : AbstractValidator<TripDto>
{
    public TripValidator()
    {
        RuleFor(x => x.Name)
                .NotEmpty().WithMessage("من فضلك أدخل اسم الرحلة");
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("من فضلك أدخل وصـف الرحلة")
            .MinimumLength(10).WithMessage("الوصـف قصير جدا");

    }
}
