using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace WebApiCore20.Commands.Customer.Create
{ 
    public class Command : IRequest<CommandResult<int>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
