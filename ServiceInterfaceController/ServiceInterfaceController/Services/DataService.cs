using ServiceInterfaceController.Interfaces;

namespace ServiceInterfaceController.Services
{
    public class DataService : IDataService
    {
        private ICarsRepository _carRepository;
        private IDriversRepository _driverRepository;

        public DataService(ICarsRepository carsRepository, IDriversRepository driversRepository)
        {
            _carRepository = carsRepository;
            _driverRepository = driversRepository;
        }

        public string GetAll()
        {
            return $"Cars: {_carRepository.GetCars()} \nDrivers: {_driverRepository.GetDrivers()}";
        }

        public void AddCar(string name)
        {
            _carRepository.AddCar(name);
        }

        public void AddDriver(string name)
        {
            _driverRepository.AddDriver(name);
        }

        public string GetCarByName(int id)
        {
            return "car";
        }

        public string GetDriverByName(int id)
        {
            return "driver";
        }
        public void DeleteCar(string name)
        {
            _carRepository.DeleteCar(name);
        }
        public void DeleteDriver(string name)
        {
            _driverRepository.DeleteDriver(name);
        }
        public string SearchCar(string name)
        {
            return $"Result: {_carRepository.SearchCar(name)}";
        }
        public string SearchDriver(string name)
        {
            return $"Result: {_driverRepository.SearchDriver(name)}";
        }
    }
}
