using BlueGrassDigital.Interface;
using BlueGrassDigital.Logic;
using BlueGrassDigital.Models.Admin;
using BlueGrassDigital.Models.Person;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlueGrassDigital.Controllers
{ 
    public class AdminController : Controller
    {

        private readonly IAdmin _admin;
        private readonly IPerson _person;

        public AdminController(IAdmin Admin, IPerson Person)
        {
            _admin = Admin;
            _person = Person;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddUser()
        {
            return View();
        }

        public IActionResult EditUser()
        {
            return View();
        }

        public async Task<IActionResult> PersonDetails(PersonDetails data)
        {
            return View(await _admin.AddPerson(data));
        }
        public async Task<IActionResult> Search(string Search)
        {
            return View("_AdminPersonView", await _person.GetAllPerson(Search));
        }

        public async Task<IActionResult> ViewChanged()
        {
            return View(await _admin.ViewChanged());
        }

    }
}
