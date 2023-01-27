using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneBookTestApp
{
    [Table("PHONEBOOK")]
    public class PersonEntity
    {
        [Key]
        [MaxLength(250)]
        public string Name;
        [Required]
        [MaxLength(250)]
        public string PhoneNumber;
        [Required]
        [MaxLength(250)]
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