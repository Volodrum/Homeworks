using DB.NETApplication.Models;

namespace DB.NETApplication.Interfaces
{
    public interface IPersonRepository
    {
        Task<List<Person>> GetAllAsync();
        Task AddAsync(Person person);
        Task UpdateAsync(Person person, int id);
    }
}
