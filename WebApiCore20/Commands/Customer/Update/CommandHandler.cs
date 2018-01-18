using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WebApiCore20.Data;

namespace WebApiCore20.Commands.Customer.Update
{
    public class CommandHandler : IRequestHandler<Command, CommandResult>
    {
        private readonly ApplicationDbContext db;

        public CommandHandler(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<CommandResult> Handle(Command request, CancellationToken cancellationToken)
        {
            var customer = db.Customers.Where(x => x.CustomerId == request.CustomerId).FirstOrDefault();

            if (customer == null)
            {
                return CommandResult.Failure("Customer does not exist");
            }

            customer.FirstName = request.FirstName;
            customer.LastName = request.LastName;

            await db.SaveChangesAsync();

            return CommandResult.Success();
        }
    }
}

