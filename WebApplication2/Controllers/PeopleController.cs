using Microsoft.AspNetCore.Mvc;
using PeopleApp.Models.Data;
using PeopleApp.Models.Repos;
using PeopleApp.Models.Services;
using PeopleApp.Models.ViewModels;

namespace PeopleApp.Controllers
{
    public class PeopleController : Controller
    {
        IPeopleService _peopleService;
        public PeopleController()
        {
            _peopleService = new PeopleService(new InMemoryPeopleRepo());
        }
        public IActionResult People()
        {
            return View(_peopleService.All());
        }
        public IActionResult Details(int id) 
        {
            Person person = _peopleService.FindById(id);

            if (person == null)
            {
                return RedirectToAction(nameof(People));
                //return NotFound();//404
            }

            return View(person);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreatePersonViewModel());
        }
        [HttpPost]
        public IActionResult Create(CreatePersonViewModel createPerson)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _peopleService.Add(createPerson);
                }
                catch (ArgumentException exception)
                {
                    ModelState.AddModelError("Name,PhoneNumber & City", exception.Message);
                    return View(createPerson);
                }

                return RedirectToAction(nameof(People));
            }
            return View(createPerson);
        }

        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(int id)
        {
            Person person = _peopleService.FindById(id);

            if (person == null)
            {
                return RedirectToAction(nameof(People));
                //return NotFound();//404
            }
            CreatePersonViewModel editPerson = new CreatePersonViewModel()
            {
                Name = person.Name,
                PhoneNumber = person.PhoneNumber,
                CityName = person.CityName
            };

            return View(editPerson);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(int id, CreatePersonViewModel editPerson)
        {

            if (ModelState.IsValid)
            {
                _peopleService.Edit(id, editPerson);
                return RedirectToAction(nameof(People));
                //return NotFound();//404
            }
            _peopleService.Add(editPerson);
            return View(editPerson);
        }
        public IActionResult Delete(int id)
        {
            Person person = _peopleService.FindById(id);
            //_peopleService.Remove(id);
            if (person == null)
            {
                return RedirectToAction(nameof(People));
                //return NotFound();//404
            }
            else
            {
                _peopleService.Remove(id);

            }

            return View();
            
        }

        //step 1 while you are gone
        [HttpPost]
        public IActionResult People(string search)
        {
            if (search != null)
            {
                return View(_peopleService.Search(search));
            }
            return RedirectToAction(nameof(People));
        }

        //****************Ajax********************//
        public IActionResult PartialViewPeople()
        {
            return PartialView("_PeopleList", _peopleService.All());
        }
        [HttpPost]
        public IActionResult PartialViewDetails(int id)
        {
            Person person = _peopleService.FindById(id);
            if (person != null)
            {
                return PartialView("_PersonDetails", person);
            }
            return NotFound();
        }
        public IActionResult AjaxDelete(int id)
        {
            Person person = _peopleService.FindById(id);
            if (_peopleService.Remove(id))
            {
                return PartialView("_PeopleList", _peopleService.All());
            }
            return NotFound();
        }
    }
}
