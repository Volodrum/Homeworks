using System.Collections.Generic;
using System.Threading.Tasks;

public interface ICarRepository
{
    Task<IEnumerable<Car>> GetAllCarsAsync();
    Task<Car?> GetCarByIdAsync(int id);
    Task AddCarAsync(Car car);
    Task UpdateCarAsync(Car car);
    Task DeleteCarAsync(int id);
    Task<bool> CarExistsAsync(int id);
}
