using DB.NETApplication.Models;

namespace DB.NETApplication.Interfaces
{
    public interface IPersonService
    {
        Task<List<Person>> GetAllAsync();
        Task AddAsync(Person person);
        Task<Person> GetPersonAsync(int id);
        Task UpdateAsync(Person person, int id);
    }
}
