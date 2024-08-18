using DB.NETApplication.Interfaces;
using DB.NETApplication.Models;
using DB.NETApplication.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DB.NETApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Person>>> Get()
        {
            var people = await _personService.GetAllAsync();
            return Ok(people);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> Get(int id)
        {
            var people = await _personService.GetPersonAsync(id);
            return Ok(people);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Person person)
        {
            await _personService.AddAsync(person);
            return CreatedAtAction(nameof(Get), new { id = person.Id }, person);
        }

        [HttpPost("{id}")]
        public async Task<ActionResult> Post([FromBody] Person person, int id)
        {
            await _personService.UpdateAsync(person, id);
            return CreatedAtAction(nameof(Get), new { id = person.Id }, person);
        }
    }
}