namespace ServiceInterfaceController.Interfaces
{
    public interface IDriversRepository
    {
        public void AddDriver(string name);
        public void DeleteDriver(string name);
        public string SearchDriver(string name);
        public string GetDrivers();
    }
}
