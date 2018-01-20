using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using WebApiCore20.Data;

namespace WebApiCore20.Tests.Builders
{
    public class ApplicationDbContextBuilder
    {
        private ApplicationDbContext applicationDbContext;
        private List<Customer> customers;

        public ApplicationDbContextBuilder()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase(databaseName: "temp")
               .Options;

            this.applicationDbContext = new ApplicationDbContext(options);
        }

        public static implicit operator ApplicationDbContext(ApplicationDbContextBuilder instance)
        {
            return instance.Build();
        }

        public ApplicationDbContext Build()
        {
            this.applicationDbContext.Customers.AddRange(this.customers);
            this.applicationDbContext.SaveChanges();
            return this.applicationDbContext;
        }

        public ApplicationDbContextBuilder WithCustomers(List<Customer> customers)
        {
            this.customers = customers;
            return this;
        }
    }

}
