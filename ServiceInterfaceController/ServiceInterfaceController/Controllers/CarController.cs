using Microsoft.AspNetCore.Mvc;
using ServiceInterfaceController.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServiceInterfaceController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private IDataService _service;

        public CarController(IDataService service)
        {
            _service = service;
        }

        // GET: api/<DriversController>
        [HttpGet]
        public string GetAll()
        {
            return _service.GetAll();
        }

        // GET api/<DriversController>/5
        [HttpGet("{value}")]
        public string SearchCar(string value)
        {
            return _service.SearchCar(value);
        }

        // PUT api/<DriversController>/5
        [HttpPut("{value}")]
        public void Put(string value)
        {
            _service.AddCar(value);
        }

        // DELETE api/<DriversController>/5
        [HttpDelete("{value}")]
        public void Delete(string value)
        {
            _service.DeleteCar(value);
        }
    }
}
