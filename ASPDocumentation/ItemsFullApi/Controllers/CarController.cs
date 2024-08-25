using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class CarController : ControllerBase
{
    private readonly ICarRepository _carRepository;

    public CarController(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    // GET: api/Car
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Car>>> GetCars()
    {
        var cars = await _carRepository.GetAllCarsAsync();
        return Ok(cars);
    }

    // GET: api/Car/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Car>> GetCar(int id)
    {
        var car = await _carRepository.GetCarByIdAsync(id);
        if (car == null)
        {
            return NotFound();
        }

        return car;
    }

    // POST: api/Car
    [HttpPost]
    public async Task<ActionResult<Car>> PostCar(Car car)
    {
        await _carRepository.AddCarAsync(car);
        return CreatedAtAction(nameof(GetCar), new { id = car.Id }, car);
    }

    // PUT: api/Car/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCar(int id, Car car)
    {
        if (id != car.Id)
        {
            return BadRequest();
        }

        if (!await _carRepository.CarExistsAsync(id))
        {
            return NotFound();
        }

        await _carRepository.UpdateCarAsync(car);
        return NoContent();
    }

    // DELETE: api/Car/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCar(int id)
    {
        if (!await _carRepository.CarExistsAsync(id))
        {
            return NotFound();
        }

        await _carRepository.DeleteCarAsync(id);
        return NoContent();
    }
}
