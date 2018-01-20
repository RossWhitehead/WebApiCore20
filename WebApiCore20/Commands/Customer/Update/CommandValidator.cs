using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using WebApiCore20.Data;

namespace WebApiCore20.Commands.Customer.Update
{
    public class CommandValidator : AbstractValidator<Command>
    {
        private ApplicationDbContext context;

        public CommandValidator(ApplicationDbContext context)
        {
            this.context = context;

            RuleFor(command => command.FirstName).NotEmpty();
            RuleFor(command => command.LastName).NotEmpty();
            RuleFor(command => command.ContactEmail).EmailAddress()
                .Must(BeUnique);
        }

        private bool BeUnique(string contactEmail)
        {
            return context.Customers.Where(x => x.ContactEmail == contactEmail).Count() > 0;
        }
    }
}
