using MediatR;
using Moq;
using WebApiCore20.Controllers;
using Get = WebApiCore20.Queries.Customer.Get;
using GetAll = WebApiCore20.Queries.Customer.GetAll;
using Xunit;
using AutoFixture;
using System.Threading;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebApiCore20.Tests.Controllers
{
    public class CustomersControllerTests
    {
        private readonly Mock<IMediator> mockMediator;
        private readonly CustomersController sut;

        public CustomersControllerTests()
        {
            mockMediator = new Mock<IMediator>();
            sut = new CustomersController(mockMediator.Object);
        }

        [Fact]
        public async void GetCustomers_ReturnsOk()
        {
            // Arrange
            var expectedQueryResult = new Fixture().Create<GetAll.QueryResult>();

            mockMediator.Setup(x => x.Send(It.IsAny<GetAll.Query>(), default(CancellationToken))).ReturnsAsync(expectedQueryResult);

            // Act
            var actualResult = await sut.GetCustomers();

            // Assert
            actualResult.Should().BeOfType<OkObjectResult>()
                .Which.Value.Should().BeSameAs(expectedQueryResult);
        }

        [Fact]
        public async void GetCustomer_ReturnsNotFound_WhenCustomerCannotBeFound()
        {
            // Arange
            var notACustomer = 1;

            mockMediator.Setup(x => x.Send(It.IsAny<Get.Query>(), default(CancellationToken))).ReturnsAsync((Get.Model)null);

            // Act
            var actualResult = await sut.GetCustomer(notACustomer);

            // Assert
            actualResult.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async void GetCustomer_ReturnsOk()
        {
            // Arange
            var customer = 1;

            var expectedQueryResult = new Fixture().Create<Get.Model>();

            mockMediator.Setup(x => x.Send(It.Is<Get.Query>(q => q.CustomerId == customer), default(CancellationToken)))
                .ReturnsAsync(expectedQueryResult);

            // Act
            var actualResult = await sut.GetCustomer(customer);

            // Assert
            actualResult.Should().BeOfType<OkObjectResult>()
                .Which.Value.Should().BeSameAs(expectedQueryResult);
        }
    }
}
