using PeopleApp.Models.Data;

namespace PeopleApp.Models.Repos
{

    public class InMemoryPeopleRepo : IPeopleRepo
    {
        private static List<Person> peopleList = new List<Person>();
        private static int idCounter = 0;
        public Person Create(string name, string phonenumber, string cityname)
        {
            Person person = new Person(name, phonenumber, cityname);

            person.PersonId = ++idCounter;
            person.Name = name;
            person.PhoneNumber = phonenumber;
            person.CityName = cityname;
            peopleList.Add(person);
            return person;
        }

        public List<Person> Read()
        {
            return peopleList;
        }

        public Person Read(int id)
        {

            foreach (Person person in peopleList)
            {
                if (person.PersonId == id)
                {
                    return person;

                }
            }
            return null;
        }

        public bool Update(Person person)
        {
            Person orgPerson = Read(person.PersonId);
            if (orgPerson == null)
            {
                return false;
            }
            else
            {
                orgPerson.Name = person.Name;
                orgPerson.CityName = person.CityName;
                orgPerson.PhoneNumber = person.PhoneNumber;
                return true;
            }
        }
        public bool Delete(Person person)
        {
            return peopleList.Remove(person);
        }
    }
}
