using System.Linq;
using ServiceClient.Models;

namespace ServiceClient.Logic
{
    public interface IPersonRepository
    {
        IQueryable<Person> Query { get; }
        void Insert(Person person);
    }
}