using FluentValidation;
using Nusuk.Services.Dtos;

namespace Nusuk.Services.Validators.User
{
    public class UserValidator : AbstractValidator<UserDto>
    {
        public UserValidator()
        {
            RuleFor(x => x.UserName)
                    .NotEmpty().WithMessage("من فضلك أدخل الاسم");

            RuleFor(x => x.Email)
                    .NotEmpty().WithMessage("من فضلك أدخل البريد الإلكتروني");
                    

            RuleFor(x => x.Password)
                  .NotEmpty().WithMessage("من فضلك أدخل كلمة المرور")
                  .MinimumLength(8).WithMessage("كلمة المرور قصيرة جدًا، يجب أن تكون 8 أحرف على الأقل");

            RuleFor(x => x.Phone)
               .Matches(@"^\d+$").WithMessage("يجب أن يحتوي الرقم على أرقام فقط");
        }
    }
}