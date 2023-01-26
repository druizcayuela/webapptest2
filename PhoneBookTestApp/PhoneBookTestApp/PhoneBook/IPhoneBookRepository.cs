using System.Collections.Generic;

namespace PhoneBookTestApp
{
    public interface IPhoneBookRepository
    {
        PersonDTO findPerson(string name);
        void addPerson(PersonDTO newPerson);
        
        void addPeople(List<PersonDTO> newPeople);

        List<PersonDTO> findAll();
    }
}