using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Domain.Dtos;
using FluentValidation;

namespace Application.Validators
{
    public class FizzBuzzRequestValidator : AbstractValidator<FizzBuzzRequest>
    {
        public FizzBuzzRequestValidator()
        {
            RuleFor(x => x.Limit)
                .GreaterThan(0)
                .WithMessage("Limit must be greater than 0.");

            RuleFor(x => x.Divisors)
                .NotNull()
                .WithMessage("Divisors cannot be null.");

            RuleFor(x => x.Divisors)
                .NotEmpty()
                 .WithMessage("Divisors cannot be empty.");

            RuleFor(x => x.Divisors)          
                .Must(divisors => divisors?.Count >= 2)     
                .WithMessage("At least two rules must be provided.");
            
            
            RuleFor(x => x.Divisors)   
                .Must(divisors => divisors != null && divisors.Keys.All(key => key > 0))  
                .WithMessage("All divisor keys must be greater than 0.");
        }
    }
}
