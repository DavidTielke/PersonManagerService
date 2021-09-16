using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            lines.Add($"{person.Id},{person.Name},{person.Age},{person.CreatedAt}");
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

            var lines = persons.Select(p => $"{p.Id},{p.Name},{p.Age},{p.CreatedAt}");

            var data = string.Join(Environment.NewLine, lines);

            File.WriteAllText("data.csv", data);
        }
    }
}