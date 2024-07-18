namespace ServiceInterfaceController.Interfaces
{
    public interface IDataService
    {
        public void AddCar(string name);
        public void AddDriver(string name);
        public string GetCarByName(int id);
        public string GetDriverByName(int id);
        public string GetAll();
        public void DeleteCar(string name);
        public void DeleteDriver(string name);
        public string SearchCar(string name);
        public string SearchDriver(string name);
    }
}
