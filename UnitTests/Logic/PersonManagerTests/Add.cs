using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceClient.Models;

namespace UnitTests.Logic.PersonManagerTests
{
    public partial class PersonManagerTest
    {
        [TestMethod]
        public void Add_PersonIsNull_ArgumentNullException()
        {
            var person = (Person) null;

            Action action = () => _sut.Add(person);

            action.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void Add_InvalidPerson_Rejected()
        {
            var person = new Person();
            _validatorStub.ReturnValue = false;

            Action action = () => _sut.Add(person);

            action.Should().ThrowExactly<ArgumentException>();
        }

        [TestMethod]
        public void Add_ValidPerson_Accepted()
        {
            var person = new Person();
            _validatorStub.ReturnValue = true;

            _sut.Add(person);
        }

        [TestMethod]
        public void Add_InvalidPerson_NotAddedToRepo()
        {
            var person = new Person();
            _validatorStub.ReturnValue = false;

            Action action = () => _sut.Add(person);

            try
            {
                action.Invoke();
            }
            catch{}

            _repoStub.WasAdded.Should().BeFalse();
        }

        [TestMethod]
        public void Add_ValidPerson_AddedToRepo()
        {
            var person = new Person();
            _validatorStub.ReturnValue = true;

            _sut.Add(person);

            _repoStub.WasAdded.Should().BeTrue();
        }
    }
}
