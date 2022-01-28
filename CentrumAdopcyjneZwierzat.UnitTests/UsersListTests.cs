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
using Microsoft.AspNetCore.Http;

namespace CentrumAdopcyjneZwierzat.UnitTests.ControllerTests
{
    public class UsersListControllerTests
    {

        [Fact]
        public void UsersListTest()
        {
            var mock = new Mock<IUsersListRepository>();

            var user = new UsersListController(mock.Object);

            var resultController = user.UsersList();

            resultController.Should().NotBeNull();
            resultController.Should().BeOfType<ViewResult>();
            resultController.Should().BeAssignableTo<IActionResult>();
        }

    }
}
