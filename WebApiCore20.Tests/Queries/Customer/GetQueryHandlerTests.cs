using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using WebApiCore20.Queries.Customer.Get;
using WebApiCore20.Tests.Builders;
using AutoFixture;
using System.Linq;
using System.Threading;
using FluentAssertions;
using AutoMapper;
using Moq;
using System.Collections;

namespace WebApiCore20.Tests.Queries.Customer
{
    public class GetQueryHandlerTests
    {
        private readonly Fixture fixture;
        private readonly Mock<IMapper> mockMapper;

        public GetQueryHandlerTests()
        {
            fixture = new Fixture();
            mockMapper = new Mock<IMapper>();
        }

        [Fact]
        public async void Handle_ReturnsCustomer_WhereCustomerExists()
        {
            // Arrange
            var customerData = fixture.CreateMany<Data.Customer>(1).ToList();
            var testDbContext = new ApplicationDbContextBuilder().WithCustomers(customerData).Build();

            var expectedCustomer = fixture.Create<QueryResult>();

            mockMapper.Setup(x => x.Map<QueryResult>(It.Is<Data.Customer>(y => y.CustomerId == customerData[0].CustomerId))).Returns(expectedCustomer);

            var sut = new QueryHandler(testDbContext, mockMapper.Object);

            // Act
            var actualResult = await sut.Handle(new Query(customerData[0].CustomerId), default(CancellationToken));

            // Assert
            actualResult.Should().BeOfType<QueryResult>()
                .And.BeSameAs(expectedCustomer);
        }

        [Fact]
        public async void Handle_ReturnsNull_WhereCustomerDoesNotExists()
        {
            // Arrange
            var customerId = fixture.Create<int>();
            var testDbContext = new ApplicationDbContextBuilder().Build();

            mockMapper.Setup(x => x.Map<QueryResult>(null)).Returns((QueryResult)null);

            var sut = new QueryHandler(testDbContext, mockMapper.Object);

            // Act
            var actualResult = await sut.Handle(new Query(customerId), default(CancellationToken));

            // Assert
            actualResult.Should().BeNull();
        }
    }
}
