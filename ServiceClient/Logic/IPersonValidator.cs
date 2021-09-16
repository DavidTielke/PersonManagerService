using ServiceClient.Models;

namespace ServiceClient.Logic
{
    public interface IPersonValidator
    {
        bool ValidNewPerson(Person person);
        bool ValidExistingPerson(Person person);
    }
}