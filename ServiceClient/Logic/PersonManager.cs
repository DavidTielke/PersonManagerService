using System;
using System.Linq;
using System.Threading.Tasks;
using ServiceClient.Models;

namespace ServiceClient.Logic
{
    public class PersonManager : IPersonManager
    {
        private IPersonRepository _repository;
        private readonly IPersonValidator _validator;

        public PersonManager(IPersonRepository repository,
            IPersonValidator validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public IQueryable<Person> GetAll() => _repository.Query;

        public void Add(Person person)
        {
            var isInvalid = !_validator.ValidNewPerson(person);

            if (isInvalid)
            {
                throw new ArgumentException("Person is not in valid format", nameof(person));
            }

            _repository.Insert(person);
        }
    }
}
