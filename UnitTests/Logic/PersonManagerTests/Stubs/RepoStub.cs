using System.Collections.Generic;
using System.Linq;
using ServiceClient.Logic;
using ServiceClient.Models;

namespace UnitTests.Logic.PersonManagerTests
{
    public class RepoStub : IPersonRepository
    {
        public bool WasAdded { get; set; }

        public IQueryable<Person> Query => new List<Person>
        {
            new Person(1, "Test1", 1),
            new Person(2, "Test2", 2),
            new Person(3, "Test3", 3),
        }.AsQueryable();
        public void Insert(Person person)
        {
            person.Id = 4711;
            WasAdded = true;
        }
    }
}