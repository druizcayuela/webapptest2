using System.Collections.Generic;
using System.Data.SQLite;

namespace PhoneBookTestApp
{
    public class PhoneBookRepository : IPhoneBookRepository
    {
        private SQLiteConnection dbConnection;
        
        public PhoneBookRepository()
        {
            if (dbConnection == null)
            {
                dbConnection = DatabaseUtil.GetConnection();
            }
        }
        
        public PersonDTO findPerson(string name)
        {
            using (var command = new SQLiteCommand(dbConnection))
            {
                command.CommandText = "SELECT * FROM PHONEBOOK WHERE NAME = @name";
                command.Parameters.AddWithValue("@name", name);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return PersonDTO.Builder()
                            .WithName(reader["NAME"].ToString())
                            .WithPhoneNumber(reader["PHONENUMBER"].ToString())
                            .WithAddress(reader["ADDRESS"].ToString())
                            .Build();
                    }
                }
                
                return null;
            }
        }

        public void addPerson(PersonDTO newPerson)
        { 
           var entity = newPerson.ToEntity();
           using (var command = new SQLiteCommand(dbConnection))
           {
               command.CommandText = "INSERT INTO PHONEBOOK (NAME, PHONENUMBER, ADDRESS) VALUES(@name, @phoneNumber, @address)";
               command.Parameters.AddWithValue("@name", entity.Name);
               command.Parameters.AddWithValue("@phoneNumber", entity.PhoneNumber);
               command.Parameters.AddWithValue("@address", entity.Address);
               command.ExecuteNonQuery();
           }
        }
        
        public List<PersonDTO> findAll()
        {
            var result = new List<PersonDTO>();
            using (var command = new SQLiteCommand(dbConnection))
            {
                command.CommandText = "SELECT * FROM PHONEBOOK";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(PersonDTO.Builder()
                            .WithName(reader["NAME"].ToString())
                            .WithPhoneNumber(reader["PHONENUMBER"].ToString())
                            .WithAddress(reader["ADDRESS"].ToString())
                            .Build());
                    }
                }
            }
            
            return result;
        }
        
        public void addPeople(List<PersonDTO> newPeople)
        {
            foreach (var person in newPeople)
            {
                addPerson(person);
            }
        }
    }
}