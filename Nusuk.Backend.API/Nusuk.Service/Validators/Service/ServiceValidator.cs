using FluentValidation;
using Nusuk.Services.Dtos;

namespace Nusuk.Services.Validators.Service
{
    public class ServiceValidator : AbstractValidator<ServiceDto>
    {
        public ServiceValidator()
        {
            RuleFor(x => x.Name)
                    .NotEmpty().WithMessage("من فضلك أدخل اسم الخدمة");
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("من فضلك أدخل وصـف الخدمة")
                .MinimumLength(10).WithMessage("الوصـف قصير جدا");
            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("يجب أن يكون السعر أكبر من الصفر ");
        }
    }


}
