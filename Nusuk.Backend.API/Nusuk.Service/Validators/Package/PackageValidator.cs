using FluentValidation;
using Nusuk.Services.Dtos;

namespace Nusuk.Services.Validators.Package
{
    public class PackageValidator: AbstractValidator<PackageDto>
    {
        public PackageValidator()
        {
            RuleFor(x => x.Name)
                    .NotEmpty().WithMessage("من فضلك أدخل اسم الباقة");
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("من فضلك أدخل وصـف الباقة")
                .MinimumLength(10).WithMessage("الوصـف قصير جدا");
            RuleFor(x => x.TotalPrice)
                .GreaterThan(0).WithMessage("يجب أن يكون السعر أكبر من الصفر ");
        }
    }

}
