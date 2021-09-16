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
        public void IsValidExistingPerson_PersonIsNull_ArgumentNullException()
        {
            var person = (Person)null;

            Action action = () => _sut.ValidExistingPerson(person);

            action.Should().Throw<ArgumentNullException>("null is not allowed as a person");
        }

        [TestMethod]
        public void IsValidExistingPerson_ValidPerson_IsValid()
        {
            var person = new Person
            {
                Id = 1,
                Name = "Test",
                Age = 23
            };

            var actual = _sut.ValidExistingPerson(person);

            actual.Should().BeTrue("valid person was passed in");
        }

        [TestMethod]
        public void IsValidExistingPerson_PersonWithZeroId_IsInvalid()
        {
            var person = new Person
            {
                Id = 0,
                Name = "Test",
                Age = 23
            };

            var actual = _sut.ValidExistingPerson(person);

            actual.Should().BeFalse("person with zero id is not valid");
        }

        [TestMethod]
        public void IsValidExistingPerson_PersonWithNegativeId_IsInvalid()
        {
            var person = new Person
            {
                Id = -1,
                Name = "Test",
                Age = 23
            };

            var actual = _sut.ValidExistingPerson(person);

            actual.Should().BeFalse("person with negative id is not valid");
        }


        [TestMethod]
        public void IsValidExistingPerson_PersonWithNullName_IsInvalid()
        {
            var person = new Person
            {
                Id = 1,
                Name = null,
                Age = 23
            };

            var actual = _sut.ValidExistingPerson(person);

            actual.Should().BeFalse("person with null name is not valid");
        }

        [TestMethod]
        public void IsValidExistingPerson_PersonWithEmptyName_IsInvalid()
        {
            var person = new Person
            {
                Id = 1,
                Name = "",
                Age = 23
            };

            var actual = _sut.ValidExistingPerson(person);

            actual.Should().BeFalse("person with empty name is not valid");
        }

        [TestMethod]
        public void IsValidExistingPerson_PersonWithAgeZero_IsInvalid()
        {
            var person = new Person
            {
                Id = 1,
                Name = "Test",
                Age = 0
            };

            var actual = _sut.ValidExistingPerson(person);

            actual.Should().BeFalse("person with age zero is not valid");
        }

        [TestMethod]
        public void IsValidExistingPerson_PersonWithAgeOne_IsValid()
        {
            var person = new Person
            {
                Id = 1,
                Name = "Test",
                Age = 1
            };

            var actual = _sut.ValidExistingPerson(person);

            actual.Should().BeTrue("person with age one is valid");
        }

        [TestMethod]
        public void IsValidExistingPerson_PersonWithAge99_IsValid()
        {
            var person = new Person
            {
                Id = 1,
                Name = "Test",
                Age = 99
            };

            var actual = _sut.ValidExistingPerson(person);

            actual.Should().BeTrue("person with age one is valid");
        }

        [TestMethod]
        public void IsValidExistingPerson_PersonWithAge100_IsInvalid()
        {
            var person = new Person
            {
                Id = 1,
                Name = "Test",
                Age = 100
            };

            var actual = _sut.ValidExistingPerson(person);

            actual.Should().BeFalse("person with age 100 is invalid");
        }
    }
}
