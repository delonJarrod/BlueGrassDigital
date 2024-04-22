using BlueGrassDigital.Interface;
using BlueGrassDigital.Models;
using BlueGrassDigital.Models.Person;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace BlueGrassDigital.Controllers
{
    public class HomeController : Controller
    {

        private readonly IPerson _person;

        public HomeController(IPerson Person)
        {
            _person = Person;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Search(string Search)
        {
            return View("_PersonView", await _person.GetAllPerson(Search));  
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}