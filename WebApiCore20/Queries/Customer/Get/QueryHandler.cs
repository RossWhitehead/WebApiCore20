using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApiCore20.Data;

namespace WebApiCore20.Queries.Customer.Get
{
    public class QueryHandler : IRequestHandler<Query, QueryResult>
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;

        public QueryHandler(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<QueryResult> Handle(Query request, CancellationToken cancellationToken)
        {
            var customer = await db.Customers.Where(x => x.CustomerId == request.CustomerId).FirstOrDefaultAsync();

            return mapper.Map<QueryResult>(customer);
        }
    }
}
