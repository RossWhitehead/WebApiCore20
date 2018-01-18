using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCore20.Queries.Customer.GetAll
{ 
    public class QueryResult
    {
        public Customer[] Customers { get; set; }

        public class Customer
        {
            public int CustomerId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    }
}
