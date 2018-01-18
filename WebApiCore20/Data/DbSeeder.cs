using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCore20.Data
{
    public static class DbSeeder
    {
        public static void Seed(ApplicationDbContext context)//SchoolContext is EF context
        {

            context.Database.EnsureCreated();

            if (context.Customers.Any())
            {
                return;   // DB has been seeded
            }

            var customers = new Customer[]
            {
                new Customer { CustomerId = 1, FirstName = "Ross", LastName = "Whitehead" },
                new Customer { CustomerId = 2, FirstName = "John", LastName = "Smith" },
                new Customer { CustomerId = 3, FirstName = "Joe", LastName = "Bloggs" },
            };

            context.AddRange(customers);
            context.SaveChanges();

        }
    }
}
