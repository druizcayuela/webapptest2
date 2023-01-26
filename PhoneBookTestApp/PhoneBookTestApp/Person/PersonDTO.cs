namespace PhoneBookTestApp
{
    public class PersonDTO
    {
        public string Name;
        public string PhoneNumber;
        public string Address;
        
        public static PersonDTO Builder()
        {
            return new PersonDTO();
        }
        
        public PersonDTO WithName(string name)
        {
            Name = name;
            return this;
        }
        
        public PersonDTO WithPhoneNumber(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
            return this;
        }
        
        public PersonDTO WithAddress(string address)
        {
            Address = address;
            return this;
        }
        
        public PersonDTO Build()
        {
            return this;
        }
        
        public PersonEntity ToEntity()
        {
            return PersonEntity.Builder()
                .WithName(Name)
                .WithPhoneNumber(PhoneNumber)
                .WithAddress(Address)
                .Build();
        }
        
        public override string ToString()
        {
            return $"Name: {Name}, PhoneNumber: {PhoneNumber}, Address: {Address}";
        }
        
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            
            if (obj.GetType() != typeof(PersonDTO))
            {
                return false;
            }
            
            var other = (PersonDTO) obj;
            return Name == other.Name && PhoneNumber == other.PhoneNumber && Address == other.Address;
        }
    }
}