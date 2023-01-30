using Microsoft.AspNetCore.Mvc;
using MVC_PROJEKT.Models.Pracownicy;
using MVC_PROJEKT.Models.Produkty;
using MVC_PROJEKT.Services;

namespace MVC_PROJEKT.Controllers
{
    public class ProduktyController : Controller
    {
        private readonly ILogger<ProduktyController> _logger;
        private readonly IProduktservice _Produktservice;
        public ProduktyController(ILogger<ProduktyController> logger, IProduktservice Produktservice)
        {
            _logger = logger;
            _Produktservice = Produktservice;
        }

        public IActionResult Index()
        {
            var model = new ProduktyViewModel()
            {
                Produkty =_Produktservice.GetProdukty()
            };
            return View(model);
        }

        public IActionResult NewPracownicy()
        {
            return View();
        }
        
        public IActionResult CreateNewProdukty(int id, string nazwa, int cena, string kategoria)
        {
            _Produktservice.CreateProdukty(id, nazwa, cena, kategoria);
            return RedirectToAction("Index");
        }
    }
}
