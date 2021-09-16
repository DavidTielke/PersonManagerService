using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ServiceClient.Models;

namespace UnitTests.Controller.PeopleControllerTests
{
    public partial class PeopleControllerTest
    {
        [TestMethod]
        public void Post_InvalidPerson_BadRequest()
        {
            _managerMock
                .Setup(m => m.Add(It.IsAny<Person>()))
                .Throws<ArgumentException>();

            var response = _sut.Post(null);

            response.Should().BeOfType<BadRequestObjectResult>();
        }


        [TestMethod]
        public void Post_ValidPerson_BadRequest()
        {
            var person = new Person(0, "Test", 2);
            
            var response = _sut.Post(person);

            response.Should().BeOfType<CreatedResult>();
            var createdResult = response as CreatedResult;
            var returnedPerson = (Person)createdResult.Value;
            returnedPerson.Should().BeSameAs(person);
        }
    }
}
