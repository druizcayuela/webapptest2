using Moq;
using NUnit.Framework;
using PhoneBookTestApp;
using System.Collections.Generic;

namespace PhoneBookTestAppTests
{
    [TestFixture]
    public class PhoneBookRepositoryTest
    {
        private IPhoneBookRepository repository;

        [SetUp]
        public void setUp()
        {
            DatabaseUtil.initializeDatabase();
            repository = new PhoneBookRepository();
        }

        [TearDown]
        public void tearDown()
        {
            DatabaseUtil.CleanUp();
        }


        [Test]
        public void addPerson_verifyIsInsertedInDB()
        {
            var person = PersonDTO.Builder()
                .WithName("John Smith")
                .WithPhoneNumber("(248) 123-4567")
                .WithAddress("1234 Sand Hill Dr, Royal Oak, MI")
                .Build();

            repository.addPerson(person);

            var result = repository.findPerson("John Smith");

            Assert.AreEqual(person, result);
        }


        [Test]
        public void findAll_verifyAllPeopleAreReturned()
        {
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

            repository.addPeople(new List<PersonDTO> { john, cynthia });

            var result = repository.findAll();

            Assert.Contains(john, result);
            Assert.Contains(cynthia, result);
        }

        [Test]
        public void findPerson_verifyPersonIsNull()
        {
            var result = repository.findPerson("John Smith");

            Assert.IsNull(result);
        }
    }
}