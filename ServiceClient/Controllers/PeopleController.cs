using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceClient.Logic;
using ServiceClient.Models;

namespace ServiceClient.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly IPersonManager _manager;

        public PeopleController(IPersonManager manager)
        {
            _manager = manager;
        }

        [HttpPost]
        public IActionResult Post(Person person)
        {
            try
            {
                _manager.Add(person);

                return Created("", person);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return _manager.GetAll().ToList();
        }
    }
}
