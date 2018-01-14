using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WebApiCore20.Data;

namespace WebApiCore20.Queries.Customer.GetAll
{
    public class QueryHandler : IRequestHandler<Query, QueryResult>
    {
        private readonly ApplicationDbContext db;

        public QueryHandler(ApplicationDbContext db)
        {
            this.db = db;
        }

        public Task<QueryResult> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = new QueryResult();

            result.Customers = new List<Model>
            {
                new Model
                {
                    CustomerId = 1,
                    FirstName = "Ross",
                    LastName = "Whitehead"
                },
                new Model
                {
                    CustomerId = 2,
                    FirstName = "John",
                    LastName = "Smith"
                }
            }.ToArray();

            return Task.FromResult<QueryResult>(result);
        }
    }
}
