using System;
using System.Collections;
using System.Collections.Generic;

namespace PhoneBookTestApp
{
    public class PhoneBook : IPhoneBook, IEnumerable<PersonDTO>
    {
        private Dictionary<string, PersonDTO> people = new Dictionary<string, PersonDTO>();

        public PersonDTO findPerson(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName))
            {
                throw new ArgumentNullException(nameof(firstName));
            }

            if (string.IsNullOrEmpty(lastName))
            {
                throw new ArgumentNullException(nameof(lastName));
            }

            string name = $"{firstName} {lastName}";

            return people.ContainsKey(name) ? people[name] : throw new PersonNotFoundException();
        }

        public void addPerson(PersonDTO newPerson)
        {
            if (newPerson == null)
            {
                throw new ArgumentNullException(nameof(newPerson));
            }

            if (people.ContainsKey(newPerson.PhoneNumber))
            {
                throw new ArgumentException("A person with this phone number already exists in the phone book.");
            }

            people.Add(newPerson.Name, newPerson);
        }

        public IEnumerator<PersonDTO> GetEnumerator()
        {
            foreach (var person in people)
            {
                yield return person.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}