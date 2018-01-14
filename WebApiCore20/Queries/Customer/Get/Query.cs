using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace WebApiCore20.Queries.Customer.Get
{
    public class Query : IRequest<Model>
    {
        public Query(int customerId)
        {
            CustomerId = customerId;
        }

        public int CustomerId { get; set; }
    }
}
