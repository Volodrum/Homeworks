namespace ServiceInterfaceController.Interfaces
{
    public interface ICarsRepository
    {
        public void AddCar(string name);
        public void DeleteCar(string name);
        public string SearchCar(string name);
        public string GetCars();
    }
}
