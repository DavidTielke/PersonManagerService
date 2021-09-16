using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using ServiceClient.FrameworkAdapter;
using ServiceClient.Models;

namespace ServiceClient.Logic
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IDateTimeAdapter _datetime;

        public PersonRepository(IDateTimeAdapter datetime)
        {
            _datetime = datetime;
        }

        public IQueryable<Person> Query => File
            .ReadAllLines("data.csv")
            .Select(l => l.Split(','))
            .Select(p => new Person
            {
                Id = int.Parse(p[0]),
                Name = p[1],
                Age = int.Parse(p[2]),
                CreatedAt = DateTime.Parse(p[3])
            })
            .AsQueryable();

        public void Insert(Person person)
        {
            var data = File.ReadAllText("data.csv");

            person.CreatedAt = _datetime.Now;

            data += Environment.NewLine + $"{4711},{person.Name},{person.Age}, {person.CreatedAt}";
            File.WriteAllText("data.csv", data);
        }
    }
}