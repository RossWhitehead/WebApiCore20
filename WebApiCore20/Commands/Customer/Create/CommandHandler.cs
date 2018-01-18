using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WebApiCore20.Data;

namespace WebApiCore20.Commands.Customer.Create
{
    public class CommandHandler : IRequestHandler<Command, CommandResult<int>>
    {
        private readonly ApplicationDbContext db;

        public CommandHandler(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<CommandResult<int>> Handle(Command request, CancellationToken cancellationToken)
        {
            var customer = new Data.Customer { FirstName = request.FirstName, LastName = request.LastName };
            db.Customers.Add(customer);
            await db.SaveChangesAsync();

            return CommandResult<int>.Success(customer.CustomerId);
        }
    }
}

