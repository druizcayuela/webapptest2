using System.Collections.Generic;

namespace PhoneBookTestApp
{
    public interface IPhoneBook
    {
        PersonDTO findPerson(string firstName, string lastName);
        void addPerson(PersonDTO newPerson);
       
    }
}