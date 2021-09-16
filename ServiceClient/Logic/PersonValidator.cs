using System;
using ServiceClient.Models;

namespace ServiceClient.Logic
{


    public class PersonValidator : IPersonValidator
    {
        public bool ValidNewPerson(Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullException(nameof(person));
            }

            var idIsValid = person.Id == 0;
            var nameIsValid = !string.IsNullOrEmpty(person.Name);
            var ageIsValid = person.Age > 0 && person.Age < 100;

            return idIsValid && nameIsValid && ageIsValid;
        }

        public bool ValidExistingPerson(Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullException(nameof(person));
            }

            var idIsValid = person.Id > 0;
            var nameIsValid = !string.IsNullOrEmpty(person.Name);
            var ageIsValid = person.Age > 0 && person.Age < 100;

            return idIsValid && nameIsValid && ageIsValid;
        }
    }
}