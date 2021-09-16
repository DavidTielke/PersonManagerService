using ServiceClient.Logic;
using ServiceClient.Models;

namespace UnitTests.Logic.PersonManagerTests
{
    public class ValidatorStub : IPersonValidator
    {
        public bool ReturnValue { get; set; }
        public bool ValidNewPerson(Person person) => ReturnValue;

        public bool ValidExistingPerson(Person person) => ReturnValue;
    }
}