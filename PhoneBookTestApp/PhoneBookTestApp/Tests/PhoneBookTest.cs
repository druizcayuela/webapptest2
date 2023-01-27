using NUnit.Framework;
using System;

namespace PhoneBookTestApp
{
    [TestFixture]
    public class PhoneBookTest
    {
        private PhoneBook phonebook;

        [SetUp]
        public void setUp()
        {
            phonebook = new PhoneBook();
        }


        [Test]
        public void addPerson_verifyIsInsertedInMap()
        {
            var person = PersonDTO.Builder()
                .WithName("John Smith")
                .WithPhoneNumber("(248) 123-4567")
                .WithAddress("1234 Sand Hill Dr, Royal Oak, MI")
                .Build();

            phonebook.addPerson(person);

            var result = phonebook.findPerson("John", "Smith");

            Assert.AreEqual(person, result);
        }

        [Test]
        public void addPerson_throwArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => phonebook.addPerson(null));
        }

        [Test]
        public void addPerson_throwArgumenException()
        {

            var person = PersonDTO.Builder()
                .WithName("John Smith")
                .WithPhoneNumber("(248) 123-4567")
                .WithAddress("1234 Sand Hill Dr, Royal Oak, MI")
                .Build();

            phonebook.addPerson(person);

            Assert.Throws<ArgumentException>(() => phonebook.addPerson(person));
        }

        [Test]
        public void findPerson_verifyIsReturned()
        {
            var person = PersonDTO.Builder()
                .WithName("John Smith")
                .WithPhoneNumber("(248) 123-4567")
                .WithAddress("1234 Sand Hill Dr, Royal Oak, MI")
                .Build();

            phonebook.addPerson(person);

            var result = phonebook.findPerson("John", "Smith");

            Assert.AreEqual(person, result);
        }

        [Test]
        public void findPerson_throwArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => phonebook.findPerson(null, null));
        }

        [Test]
        public void findPerson_throwPersonNotFoundException()
        {
            Assert.Throws<PersonNotFoundException>(() => phonebook.findPerson("John", "Smith"));
        }
    }
 }