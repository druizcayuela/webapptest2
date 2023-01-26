using System.ComponentModel.DataAnnotations;

namespace PhoneBookTestApp
{
    public class PersonEntity
    {
        public string Name;
        [Key]
        public string PhoneNumber;
        public string Address;
        
        public static PersonEntity Builder()
        {
            return new PersonEntity();
        }
        
        public PersonEntity WithName(string name)
        {
            Name = name;
            return this;
        }
        
        public PersonEntity WithPhoneNumber(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
            return this;
        }
        
        public PersonEntity WithAddress(string address)
        {
            Address = address;
            return this;
        }
        
        public PersonEntity Build()
        {
            return this;
        }
    }
}