using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceClient.Logic;
using ServiceClient.Models;

namespace IntegrationTests
{
    public class StoreHelper
    {
        public void Clear()
        {
            File.WriteAllText("data.csv","");
        }

        public void Add(Person person)
        {
            var lines = File.ReadAllLines("data.csv").ToList();
            lines.Add($"{person.Id},{person.Name},{person.Age}");
            File.WriteAllLines("data.csv", lines.ToArray());
        }

        public void Seed()
        {
            var persons = new List<Person>
            {
                new Person(1, "Test1", 2),
                new Person(2, "Test2", 3),
                new Person(3, "Test3", 4),
            };

            var lines = persons.Select(p => $"{p.Id},{p.Name},{p.Age}");

            var data = string.Join(Environment.NewLine, lines);

            File.WriteAllText("data.csv", data);
        }
    }

    [TestClass]
    public class UnitTest1
    {
        private StoreHelper _store = new StoreHelper();
        private PersonRepository _sut;

        [TestInitialize]
        public void Setup()
        {
            _sut = new PersonRepository();
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
    }
}
