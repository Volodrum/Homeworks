using ServiceInterfaceController.Interfaces;

namespace ServiceInterfaceController.Repositories
{
    public class CarsRepository : ICarsRepository
    {
        static List<string> cars = new List<string>() { "Mersedes - Daniel", "Jaguar - Oliver", "Nissan - Michael"};

        public void AddCar(string name)
        {
            cars.Add(name);
        }

        public void DeleteCar(string name)
        {
            cars.Remove(name);
        }
        public string SearchCar(string name)
        {
            List<string> container = cars, cars2 = new List<string>();
            while (container.Contains(name))
            {
                cars2.Add(name);
                container.Remove(name);
            }
            return string.Join(", ", cars2);
        }

        public string GetCars()
        {
            return string.Join(", ", cars.ToArray());
        }
    }
}
