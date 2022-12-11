using PeopleApp.Models.Data;
using PeopleApp.Models.ViewModels;

namespace PeopleApp.Models.Services
{
    public interface IPeopleService
    {
        Person Add(CreatePersonViewModel createPerson);
        List<Person> All();
        List<Person> Search(string Search);
        Person FindById(int id);
        bool Edit(int id, CreatePersonViewModel editPerson);
        bool Remove(int id);
    }
}
