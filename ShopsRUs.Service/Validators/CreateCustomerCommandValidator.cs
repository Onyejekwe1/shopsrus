using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using ShopsRUs.Service.Commands;

namespace ShopsRUs.Service.Validators
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(c => c.FirstName).NotEmpty();
            RuleFor(c => c.LastName).NotEmpty();
        }
    }
}
