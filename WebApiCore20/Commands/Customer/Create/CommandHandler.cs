using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using WebApiCore20.Data;

namespace WebApiCore20.Commands.Customer.Create
{
    public class CommandHandler : IRequestHandler<Command, CommandResult<int>>
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;

        public CommandHandler(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<CommandResult<int>> Handle(Command request, CancellationToken cancellationToken)
        {
            var customer = mapper.Map<Data.Customer>(request);
            db.Customers.Add(customer);
            await db.SaveChangesAsync();

            return CommandResult<int>.Success(customer.CustomerId);
        }
    }
}

