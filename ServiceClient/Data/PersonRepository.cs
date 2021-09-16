using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ServiceClient.Models;

namespace ServiceClient.Logic
{
    public class PersonRepository : IPersonRepository
    {
        public IQueryable<Person> Query => File
            .ReadAllLines("data.csv")
            .Select(l => l.Split(','))
            .Select(p => new Person
            {
                Id = int.Parse(p[0]),
                Name = p[1],
                Age = int.Parse(p[2])
            })
            .AsQueryable();

        public void Insert(Person person)
        {
            var data = File.ReadAllText("data.csv");
            
            data += Environment.NewLine + $"{4711},{person.Name},{person.Age}";
            File.WriteAllText("data.csv", data);
        }
    }
}