using ServiceInterfaceController.Interfaces;

namespace ServiceInterfaceController.Repositories
{
    public class DriversRepository : IDriversRepository
    {
        static List<string> drivers = new List<string>() { "Richard - Ford", "Ban - Bentley", "Johan - McLaren"};

        public void AddDriver(string name)
        {
            drivers.Add(name);
        }
        public void DeleteDriver(string name)
        {
            drivers.Remove(name);
        }
        public string SearchDriver(string name)
        {
            List<string> container = drivers, drivers2 = new List<string>();
            while (container.Contains(name))
            {
                drivers2.Add(name);
                container.Remove(name);
            }
            return string.Join(", ", drivers2);
        }

        public string GetDrivers()
        {
            string combinedString = string.Join(", ", drivers.ToArray());
            return combinedString;
        }
    }
}
