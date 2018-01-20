using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApiCore20.Data;

namespace WebApiCore20.Queries.Customer.GetAll
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
            var customerData = await db.Customers.ToArrayAsync();

            var result = new QueryResult();
            result.Customers = mapper.Map<QueryResult.Customer[]>(customerData);
          
            return result;
        }
    }
}
