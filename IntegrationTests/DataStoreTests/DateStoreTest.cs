using System;
using System.Linq;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ServiceClient.FrameworkAdapter;
using ServiceClient.Logic;
using ServiceClient.Models;

namespace IntegrationTests
{
    [TestClass]
    public class DateStoreTest
    {
        private StoreHelper _store = new StoreHelper();
        private Mock<IDateTimeAdapter> _datetimeMock;
        private PersonRepository _sut;

        [TestInitialize]
        public void Setup()
        {
            _datetimeMock = new Mock<IDateTimeAdapter>();
            _datetimeMock.Setup(m => m.Now).Returns(DateTime.Now);
            _sut = new PersonRepository(_datetimeMock.Object);
            _store.Seed();
        }

        [TestCleanup]
        public void CleanUp()
        {
            _store.Clear();
        }

        [TestMethod]
        public void Insert_3PeopleInStore_4PeopleStore()
        {
            var person = new Person(0, "David", 37);

            _sut.Insert(person);

            _sut.Query.ToList().Count.Should().Be(4);
        }

        [TestMethod]
        public void Insert_3PeopleInStore_5PeopleStore()
        {
            var person1 = new Person(0, "David", 37);
            var person2 = new Person(0, "Lena", 34);

            _sut.Insert(person1);
            _sut.Insert(person2);

            _sut.Query.ToList().Count.Should().Be(5);
        }

        [TestMethod]
        public void Insert_3PeopleInStore_CreatedAtIsCorrect()
        {
            var person1 = new Person(0, "David", 37);
            _datetimeMock.Setup(m => m.Now).Returns(new DateTime(2021, 9, 15));

            _sut.Insert(person1);
            var lastPerson = _sut.Query.Last();

            lastPerson.CreatedAt.Should().Be(new DateTime(2021, 9, 15));
        }
    }
}
