using ServiceClient.Models;

namespace ServiceClient.Logic
{
    public class PersonValidator : IPersonValidator
    {
        public bool ValidNewPerson(Person person) => person.Id == 0;

        public bool ValidExistingPerson(Person person) => person.Id > 0;
    }
}