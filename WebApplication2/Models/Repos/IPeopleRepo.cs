using PeopleApp.Models.Data;

namespace PeopleApp.Models.Repos
{
    public interface IPeopleRepo
    {
        public Person Create(string name, string phonenumber, string city);
        public List<Person> Read();
        public Person Read(int id);
        public bool Update(Person person);
        public bool Delete(Person person);
    }
}
