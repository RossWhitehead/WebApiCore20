using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace WebApiCore20.Commands.Customer.Delete
{ 
    public class Command : IRequest<CommandResult>
    {
        public int CustomerId { get; set; }
    }
}
