using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace WebApiCore20.Commands.Customer.Create
{
    public class CommandValidator : AbstractValidator<Command>
    {
        public CommandValidator()
        {
            RuleFor(command => command.FirstName).NotEmpty();
            RuleFor(command => command.LastName).NotEmpty();
        }
    }
}
