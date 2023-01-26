using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookTestApp
{
    class Program
    {
        private static IPhoneBook phonebook = new PhoneBook(new PhoneBookRepository());
        static void Main(string[] args)
        {
            try
            {
                DatabaseUtil.initializeDatabase();
                /* TODO: create person objects and put them in the PhoneBook and database
                * John Smith, (248) 123-4567, 1234 Sand Hill Dr, Royal Oak, MI
                * Cynthia Smith, (824) 128-8758, 875 Main St, Ann Arbor, MI
                */
                
                var john = PersonDTO.Builder()
                    .WithName("John Smith")
                    .WithPhoneNumber("(248) 123-4567")
                    .WithAddress("1234 Sand Hill Dr, Royal Oak, MI")
                    .Build();
                
                var cynthia = PersonDTO.Builder()
                    .WithName("Cynthia Smith")
                    .WithPhoneNumber("(824) 128-8758")
                    .WithAddress("875 Main St, Ann Arbor, MI")
                    .Build();
                
                phonebook.addPeople(new List<PersonDTO> { john, cynthia });

                // TODO: print the phone book out to System.out
                foreach (var person in phonebook.findAll())
                {
                    Console.WriteLine(person);
                }

                // TODO: find Cynthia Smith and print out just her entry
                var cynthiaSmith = phonebook.findPerson("Cynthia Smith");
                Console.WriteLine(cynthiaSmith);
            }
            finally
            {
                DatabaseUtil.CleanUp();
            }
        }
    }
}
