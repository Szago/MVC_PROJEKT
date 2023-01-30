using Microsoft.AspNetCore.Mvc;
using MVC_PROJEKT.Models.Pracownicy;
using MVC_PROJEKT.Services;

namespace MVC_PROJEKT.Controllers
{
    public class PracownicyController : Controller
    {
        private readonly ILogger<PracownicyController> _logger;
        private readonly IPersonservice _Personservice;
        public PracownicyController(ILogger<PracownicyController> logger, IPersonservice Personservice)
        {
            _logger = logger;
            _Personservice = Personservice;
        }

        public IActionResult Index()
        {
            var model = new PracownicyViewModel()
            {
                Persons =_Personservice.GetPersons()
            };
            return View(model);
        }

        public IActionResult NewPracownicy()
        {
            return View();
        }

        public IActionResult CreateNewPracownicy(int id, string name, string dzial, GenderEnum gender)
        {
            _Personservice.CreatePracownicy(id, name, dzial, gender);
            return RedirectToAction("Index");
        }
    }
}
