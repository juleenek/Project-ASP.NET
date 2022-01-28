using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using CentrumAdopcyjneZwierzat.WebAPI_REST;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using CentrumAdopcyjneZwierzat.Models.AdoptionCenter;
using CentrumAdopcyjneZwierzat.DataAccess.Repositories.Contracts;
using CentrumAdopcyjneZwierzat.DataAccess;
using CentrumAdopcyjneZwierzat.DataAccess.Repositories;
using CentrumAdopcyjneZwierzat.Controllers;
using FakeItEasy;
using System.Linq;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CentrumAdopcyjneZwierzat.UnitTests
{
    public class DogsControllerTests
    {
       [Fact]
       public void ApiCreateDog()
        {
            var mock = new Mock<IDogsRepository>();
            var controller = new ApiDogsController(mock.Object);
          
            Dog dog = new Dog
            {
                DogId = "ABC123",
                DogName = "Azor",
                Breed = 0,
                Gender = "Samiec",
                Weight = 0,
                DogBirthYear = 2010,
                ImageFile = null,
                Box = null,
                VolunteerId = 0
            };

            var resultController = controller.Add(dog);

            var result = resultController as OkObjectResult;

            Assert.Equal(200, result.StatusCode);        
       }
        [Fact]
        public void CreateDog_RedirectsToDogs()
        {
            var mock = new Mock<IDogsRepository>();
            var controller = new DogsController(mock.Object);

            Dog dog = new Dog
            {
                DogId = "ABC123",
                DogName = "Azor",
                Breed = 0,
                Gender = "Samiec",
                Weight = 0,
                DogBirthYear = 2010,
                ImageFile = null,
                Box = null,
                VolunteerId = 0
            };

            var result = controller.CreateDog(dog);
            var redirectToActionResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("Dogs", redirectToActionResult.ViewName);
        }
        [Fact]
        public void Delete()
        {
            var mock = new Mock<IDogsRepository>();
            var controller = new DogsController(mock.Object);

            Dog dog = new Dog
            {
                DogId = "ABC123",
                DogName = "Azor",
                Breed = 0,
                Gender = "Samiec",
                Weight = 0,
                DogBirthYear = 2010,
                ImageFile = null,
                Box = null,
                VolunteerId = 0
            };

            var resultCreate = controller.CreateDog(dog);
            var redirectToActionResultCreate = Assert.IsType<ViewResult>(resultCreate);

            var resultDelete = controller.Delete(dog.DogId);
            var redirectToActionResultDelete = Assert.IsType<ViewResult>(resultDelete);

            Assert.Equal(redirectToActionResultCreate.ViewName, redirectToActionResultDelete.ViewName);
        }
    }
}
