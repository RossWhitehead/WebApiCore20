using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using WebApiCore20.Data;

namespace WebApiCore20.Commands.Customer.Update
{
    public class CommandHandler : IRequestHandler<Command, CommandResult>
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;

        public CommandHandler(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<CommandResult> Handle(Command request, CancellationToken cancellationToken)
        {
            var customer = db.Customers.Where(x => x.CustomerId == request.CustomerId).FirstOrDefault();

            if (customer == null)
            {
                return CommandResult.Failure("Customer does not exist");
            }

            mapper.Map(request, customer);

            await db.SaveChangesAsync();

            return CommandResult.Success();
        }
    }
}

