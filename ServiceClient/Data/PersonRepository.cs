using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ServiceClient.Models;

namespace ServiceClient.Logic
{
    public class PersonRepository : IPersonRepository
    {
        private List<Person> _persons;

        public PersonRepository()
        {
            _persons = File
                .ReadAllLines("data.csv")
                .Select(l => l.Split(','))
                .Select(p => new Person
                {
                    Id = int.Parse(p[0]),
                    Name = p[1],
                    Age = int.Parse(p[2])
                })
                .ToList();
        }

        public IQueryable<Person> Query => _persons.AsQueryable();
        public void Insert(Person person)
        {
            var data = File.ReadAllText("data.csv");
            data += Environment.NewLine + $"{person.Id},{person.Name},{person.Age}";
            File.WriteAllText("data.csv", data);
        }
    }
}