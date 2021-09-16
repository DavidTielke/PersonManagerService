using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceClient.Models;

namespace UnitTests.Logic.PersonValidatorTests
{
    public partial class PersonValidatorTest
    {
        [TestMethod]
        public void IsValidNewPerson_PersonIsNull_ArgumentNullException()
        {
            var person = (Person) null;

            Action action = () => _sut.ValidNewPerson(person);

            action.Should().Throw<ArgumentNullException>("null is not allowed as a person");
        }

        [TestMethod]
        public void IsValidNewPerson_ValidPerson_IsValid()
        {
            var person = new Person
            {
                Id = 0,
                Name = "Test",
                Age = 23
            };

            var actual = _sut.ValidNewPerson(person);

            actual.Should().BeTrue("valid person was passed in");
        }

        [TestMethod]
        public void IsValidNewPerson_PersonWithPositiveId_IsInvalid()
        {
            var person = new Person
            {
                Id = 1,
                Name = "Test",
                Age = 23
            };

            var actual = _sut.ValidNewPerson(person);

            actual.Should().BeFalse("person with positve id is not valid");
        }

        [TestMethod]
        public void IsValidNewPerson_PersonWithNegativeId_IsInvalid()
        {
            var person = new Person
            {
                Id = -1,
                Name = "Test",
                Age = 23
            };

            var actual = _sut.ValidNewPerson(person);

            actual.Should().BeFalse("person with negative id is not valid");
        }


        [TestMethod]
        public void IsValidNewPerson_PersonWithNullName_IsInvalid()
        {
            var person = new Person
            {
                Id = 0,
                Name = null,
                Age = 23
            };

            var actual = _sut.ValidNewPerson(person);

            actual.Should().BeFalse("person with null name is not valid");
        }

        [TestMethod]
        public void IsValidNewPerson_PersonWithEmptyName_IsInvalid()
        {
            var person = new Person
            {
                Id = 0,
                Name = "",
                Age = 23
            };

            var actual = _sut.ValidNewPerson(person);

            actual.Should().BeFalse("person with empty name is not valid");
        }
        
        [TestMethod]
        public void IsValidNewPerson_PersonWithAgeZero_IsInvalid()
        {
            var person = new Person
            {
                Id = 0,
                Name = "Test",
                Age = 0
            };

            var actual = _sut.ValidNewPerson(person);

            actual.Should().BeFalse("person with age zero is not valid");
        }

        [TestMethod]
        public void IsValidNewPerson_PersonWithAgeOne_IsValid()
        {
            var person = new Person
            {
                Id = 0,
                Name = "Test",
                Age = 1
            };

            var actual = _sut.ValidNewPerson(person);

            actual.Should().BeTrue("person with age one is valid");
        }

        [TestMethod]
        public void IsValidNewPerson_PersonWithAge99_IsValid()
        {
            var person = new Person
            {
                Id = 0,
                Name = "Test",
                Age = 99
            };

            var actual = _sut.ValidNewPerson(person);

            actual.Should().BeTrue("person with age one is valid");
        }

        [TestMethod]
        public void IsValidNewPerson_PersonWithAge100_IsInvalid()
        {
            var person = new Person
            {
                Id = 0,
                Name = "Test",
                Age = 100
            };

            var actual = _sut.ValidNewPerson(person);

            actual.Should().BeFalse("person with age 100 is invalid");
        }
    }
}
