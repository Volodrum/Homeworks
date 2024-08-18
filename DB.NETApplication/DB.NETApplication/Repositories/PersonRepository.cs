using DB.NETApplication.Interfaces;
using DB.NETApplication.Models;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System.Collections.Generic;
using System.Data;

namespace DB.NETApplication.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly string _connectionString = "server=localhost;port=3306;database=testdata;user=root;password=1234;";

        //public PersonRepository(IConfiguration configuration)
        //{
        //    _connectionString = configuration.GetConnectionString("DefaultConnection");
        //}

        public async Task<List<Person>> GetAllAsync()
        {
            var people = new List<Person>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "SELECT Id, Name, Age FROM People";

                using (var command = new MySqlCommand(query, connection))
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var person = new Person
                        {
                            Id = reader.GetInt32("Id"),
                            Name = reader.GetString("Name"),
                            Age = reader.GetInt32("Age")
                        };
                        people.Add(person);
                    }
                }
            }

            return people;
        }

        public async Task AddAsync(Person person)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "INSERT INTO People (Name, Age) VALUES (@name, @age)";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", person.Name);
                    command.Parameters.AddWithValue("@age", person.Age);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task UpdateAsync(Person person, int id)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "UPDATE People SET Name = @name, Age = @age WHERE id = @id;";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", person.Name);
                    command.Parameters.AddWithValue("@age", person.Age);
                    command.Parameters.AddWithValue("@id", id);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
