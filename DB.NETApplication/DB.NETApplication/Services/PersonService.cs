using DB.NETApplication.Interfaces;
using DB.NETApplication.Models;

namespace DB.NETApplication.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<List<Person>> GetAllAsync()
        {
            var allPersons = await _personRepository.GetAllAsync();
            List <Person> clients = new List<Person>();

            foreach (var person in allPersons)
            {
                var client = new Person();
                client.Name = person.Name;
                client.Age = person.Age;
                client.IsAdult = person.Age<18 ? false : true;

                clients.Add(client);
            }

            return clients;
        }

        public async Task<Person> GetPersonAsync(int id)
        {
            var allPersons = await _personRepository.GetAllAsync();
            Person client = new Person();

            foreach (var person in allPersons)
            {
                if(person.Id == id)
                {
                    client.Name = person.Name;
                    client.Age = person.Age;
                    client.IsAdult = person.Age < 18 ? false : true;
                }
            }
            return client;
        }

        public async Task AddAsync(Person person)
        {
            await _personRepository.AddAsync(person);
        }

        public async Task UpdateAsync(Person person, int id)
        {
            await _personRepository.UpdateAsync(person, id);
        }
    }
}
