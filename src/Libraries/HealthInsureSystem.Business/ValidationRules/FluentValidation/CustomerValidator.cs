using FluentValidation;
using HealthInsureSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthInsureSystem.Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(p => p.FirstName)
                .NotEmpty()
                .MaximumLength(50);
            RuleFor(p => p.LastName)
                .NotEmpty()
                .MaximumLength(50);
            RuleFor(p => p.IdentityNumber)
                .Length(11)
                .NotEmpty()
                .WithMessage("Geçersiz Tc Kimlik Numarası");

        }
    }
}
