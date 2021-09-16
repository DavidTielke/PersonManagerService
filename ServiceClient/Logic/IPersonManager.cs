using System.Linq;
using ServiceClient.Models;

namespace ServiceClient.Logic
{
    public interface IPersonManager
    {
        IQueryable<Person> GetAll();
        void Add(Person person);
    }
}