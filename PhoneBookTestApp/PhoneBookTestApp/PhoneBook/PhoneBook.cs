using System;
using System.Collections.Generic;

namespace PhoneBookTestApp
{
    public class PhoneBook : IPhoneBook
    {
        private IPhoneBookRepository repository;
        
        public PhoneBook(IPhoneBookRepository repository)
        {
            this.repository = repository;
        }
        public PersonDTO findPerson(string name)
        {
            var person = repository.findPerson(name);
            
            if (person == null)
            {
                throw new PersonNotFoundException();
            }
            
            return person;
        }

        public void addPerson(PersonDTO newPerson)
        {
            repository.addPerson(newPerson);
        }
        
        public List<PersonDTO> findAll()
        {
            return repository.findAll();
        }
        
        public void addPeople(List<PersonDTO> newPeople)
        {
            repository.addPeople(newPeople);
        }
    }
}