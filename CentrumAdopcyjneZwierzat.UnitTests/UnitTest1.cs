using CentrumAdopcyjneZwierzat.Controllers;
using CentrumAdopcyjneZwierzat.DataAccess.Repositories.Contracts;
using CentrumAdopcyjneZwierzat.Models.User;
using Moq;
using Shouldly;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using CentrumAdopcyjneZwierzat.WebAPI_REST;
using FluentAssertions;

namespace CentrumAdopcyjneZwierzat.UnitTests.ControllerTests
{
    public class UsersListControllerTests
    {
        [Fact]
        public void UsersListTest()
        {
            //Arrange
            var mock = new Mock<IUsersListRepository>();

            var user = new UsersListController(mock.Object);

            //Art
            var resultController = user.UsersList();

            //Assert
            resultController.Should().NotBeNull();
            resultController.Should().BeOfType<ViewResult>();
            resultController.Should().BeAssignableTo<IActionResult>();
        }

        [Fact]
        public void DetailsTest()
        {
            var mock = new Mock<IUsersListRepository>();

            var user = new UsersListController(mock.Object);

            ApplicationUser expected = new ApplicationUser()
            {
                Id = "123a",
                FirstName = "Anna",
                LastName = "Nowara",
                Phone = "111222333",
                StreetAddress = "Mirabelkowa 23",
                PostalCode = "12-345",
                City = "Kraków"
            };

            var actionResult = user.Details("123");
            var viewResult = actionResult as ViewResult;
            var actual = viewResult.ViewData.Model as ApplicationUser;

            Assert.Equal(expected.Id, actual.Id);
        }
    }
}
