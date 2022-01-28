using CentrumAdopcyjneZwierzat.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CentrumAdopcyjneZwierzat.UnitTests
{
    public class RequiredRegisterUserTests
    {
        [Fact]
        public void Login_should_be_required()
        {
            var propertyInfo = typeof(RegisterUserModel).GetProperty("UserName");

            var attribute = propertyInfo.GetCustomAttributes(typeof(RequiredAttribute), false)
                                        .FirstOrDefault();

            Assert.NotNull(attribute);
        }
        [Fact]
        public void Email_should_be_required()
        {
            var propertyInfo = typeof(RegisterUserModel).GetProperty("Email");

            var attribute = propertyInfo.GetCustomAttributes(typeof(RequiredAttribute), false)
                                        .FirstOrDefault();

            Assert.NotNull(attribute);
        }
        [Fact]
        public void Password_should_be_required()
        {
            var propertyInfo = typeof(RegisterUserModel).GetProperty("Password");

            var attribute = propertyInfo.GetCustomAttributes(typeof(RequiredAttribute), false)
                                        .FirstOrDefault();

            Assert.NotNull(attribute);
        }
    }
}
