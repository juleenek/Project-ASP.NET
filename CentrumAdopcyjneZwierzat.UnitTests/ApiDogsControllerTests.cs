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

namespace CentrumAdopcyjneZwierzat.UnitTests
{
    public class DogsControllerTests
    {
        //private IDogsRepository _repo;
        //public DogsControllerTests(IDogsRepository repo)
        //{
        //    _repo = repo;
        //}
       [Fact]
       public void CreateDog()
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
    }
}
