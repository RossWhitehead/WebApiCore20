using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApiCore20.Data
{
    public static class DbSeeder
    {
        public static void Seed(ApplicationDbContext context)//SchoolContext is EF context
        {
            context.Database.Migrate();

            if (context.Customers.Any())
            {
                return;   // DB has already been seeded
            }

            var customers = new Customer[]
            {
                new Customer { CustomerId = 1, FirstName = "Ross", LastName = "Whitehead", ContactEmail = "ross@ross.co.uk" },
                new Customer { CustomerId = 2, FirstName = "John", LastName = "Smith", ContactEmail = "john@ross.co.uk"},
                new Customer { CustomerId = 3, FirstName = "Joe", LastName = "Bloggs", ContactEmail = "joe@ross.co.uk" },
            };

            context.Database.OpenConnection();
            context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Customers ON");
            context.AddRange(customers);
            context.SaveChanges();
            context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Customers OFF");
            context.Database.CloseConnection();
        }
    }
}
