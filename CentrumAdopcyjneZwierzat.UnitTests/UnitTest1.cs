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

        //[Fact]
        //public void DeleteTest()
        //{
        //    var testUser = new ApplicationUser
        //    {
        //        Id = "123a",
        //        FirstName = "Anna",
        //        LastName = "Nowara",
        //        Phone = "111222333",
        //        StreetAddress = "Mirabelkowa 23",
        //        PostalCode = "12-345",
        //        City = "Kraków"
        //    };

        //    repo.Add(testUser);
        //    var createTest = repo.Add(testUser);

        //    Assert.True(createTest);

        //    var test = repo.FindById(testUser.Id);

        //    Assert.NotNull(test);
        //    Assert.IsAssignableFrom<IEnumerable<ApplicationUser>>(test);

        //    var deleteTest = repo.Delete(test.Id);
        //    Assert.True(deleteTest);
        //}

    }
}
