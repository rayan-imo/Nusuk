using FluentValidation;
using Nusuk.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nusuk.Services.Validators.Booking
{
    public class BookingValidator : AbstractValidator<BookingDto>
    {
        public BookingValidator() {

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("يجب أن يكون السعر أكبر من الصفر ");
          

        }
    }
} 
