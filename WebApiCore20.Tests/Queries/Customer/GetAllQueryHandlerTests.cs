using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using WebApiCore20.Queries.Customer.GetAll;
using WebApiCore20.Tests.Builders;
using AutoFixture;
using System.Linq;
using System.Threading;
using FluentAssertions;
using AutoMapper;
using Moq;

namespace WebApiCore20.Tests.Queries.Customer
{
    public class GetAllQueryHandlerTests
    {
        [Fact]
        public async void Handle_ReturnsQueryResult()
        {
            // Arrange
            var fixture = new Fixture();

            var customerData = fixture.CreateMany<Data.Customer>().ToList();
            var testDbContext = new ApplicationDbContextBuilder().WithCustomers(customerData).Build();

            var expectedCustomers = fixture.CreateMany<QueryResult.Customer>().ToArray();

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<QueryResult.Customer[]>(customerData)).Returns(expectedCustomers);

            var sut = new QueryHandler(testDbContext, mockMapper.Object);

            // Act
            var actualResult = await sut.Handle(new Query(), default(CancellationToken));

            // Assert
            actualResult.Should().BeOfType<QueryResult>()
                .Which.Customers.Should().BeSameAs(expectedCustomers);
        }
    }
}
