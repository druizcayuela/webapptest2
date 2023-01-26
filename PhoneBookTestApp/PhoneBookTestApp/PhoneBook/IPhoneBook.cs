using System.Collections.Generic;

namespace PhoneBookTestApp
{
    public interface IPhoneBook
    {
        PersonDTO findPerson(string name);
        void addPerson(PersonDTO newPerson);
        
        void addPeople(List<PersonDTO> newPeople);
        
        List<PersonDTO> findAll();
    }
}