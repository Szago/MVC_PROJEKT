using Microsoft.AspNetCore.Mvc;
using System.Net;
using Projekt_MVC.Services.Pracownicy;
using Projekt_MVC.Models.TDriveModel;
using Projekt_MVC.Services.Produkt;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Projekt_MVC.Controllers

{
    public class PracownicyController : Controller
    {
        private readonly ILogger<PracownicyController> _logger;
        private readonly IPracownicyService _PracownicyService;
        public PracownicyController(ILogger<PracownicyController> logger, IPracownicyService PracownicyService)
        {
            _logger = logger;
            _PracownicyService = PracownicyService;
          
        }
        public IActionResult Index()
        {
            try
            {
                var model = new PracownicyViewModel()
                {
                    PracownicyLista = _PracownicyService.GetPracownicyLista(),
                    
            };
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while getting test drives");
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
          

        }
        /*
        public IActionResult NewPracownicy(int ProduktID)
        {
            try
            {
               
                if (ModelState.IsValid)
                {

                    var model = new CreatePracownicyViewModel()
                    {
                        ProduktID = ProduktID
                    };

                    return View(model);
                }
                else
                {
                    return RedirectToAction("NewPracownicy", new { ProduktID = ProduktID });
                }


            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating new test drives");
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
            
        }
        
        public IActionResult CreateNewPracownicy(string imie, string nazwisko, string pesel, string data, int nrtel, int ProduktID)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _PracownicyService.CreatePracownicy(imie, nazwisko, pesel, data, nrtel, ProduktID);
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("NewPracownicy", new { imie = imie, nazwisko = nazwisko, pesel = pesel, data = data, nrtel = nrtel, ProduktID = ProduktID });

                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating new test drives");
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
           
        }
        */

        public IActionResult DeletePracownicy(int id)
        {
            try 
            {
                
                if (id == null)
                {
                    return NotFound();
                }
                _PracownicyService.DeletePracownicy(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while deleting test drives");
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
            
        }

        public IActionResult EditPracownicy(int id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {

                    var TD = _PracownicyService.GetPracownicyLista(id);

                    var model = new EditPracownicyModel()
                    {
                        ID = TD.ID,
                        Imie = TD.Imie,
                        Nazwisko = TD.Nazwisko,
                        NrTel = TD.NrTel
                    };


                    return View(model);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while editing test drives");
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
            
        }
        public IActionResult EditPracownicyDetails(long id, string imie, string nazwisko,  int nrtel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _PracownicyService.EditPracownicy(id, imie, nazwisko,  nrtel);
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("EditPracownicy", new { id = id, imie = imie, nazwisko = nazwisko, nrtel = nrtel});
                }
               

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while editing test drives");
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
            
        }


        [HttpGet]
        public async Task<ActionResult> GetPracownicyListaJson()
        {
            try
            {
                var model = new PracownicyViewModel()
                {
                    PracownicyLista = _PracownicyService.GetPracownicyLista()
                };
                return Json(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while getting test drives");
                return Json(new { Status = "Get Failed", StatusCode = StatusCode((int)HttpStatusCode.InternalServerError), ErrorMessage = ex.Message });
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeletePracownicyJson(int id)
        {
            try
            {
                
                if (id == null || id <=0)
                {
                    throw new Exception("Niepoprawny ID");
                }
                _PracownicyService.DeletePracownicy(id);
                return Json(new { Status = "Delete Succesful" });
            }
            catch (Exception e)
            {
                return Json(new { Status = "Delete Failed" ,StatusCode= StatusCode((int)HttpStatusCode.InternalServerError), ErrorMessage= e.Message});
            }

        }
        [HttpPost]
        public async Task<ActionResult> CreatePracownicyJson(string imie, string nazwisko, int nrtel )
        {
            try
            {
                _PracownicyService.CreatePracownicy(imie, nazwisko, nrtel);
                return Json(new { Status = "Add Succesful" });
            }
            catch (Exception ex)
            {

                return Json(new { Status = "Add Failed", StatusCode = StatusCode((int)HttpStatusCode.InternalServerError), ErrorMessage = ex.Message });
            }
        }
        [HttpPut]
        public async Task<ActionResult> EditPracownicyJson(long id,string imie, string nazwisko, int nrtel)
        {
            try
            {
                _PracownicyService.EditPracownicy(id, imie, nazwisko, nrtel);
                return Json(new { Status = "Edit Succesful" });
            }
            catch (Exception e)
            {
                return Json(new { Status = "Edit Failed", StatusCode = StatusCode((int)HttpStatusCode.InternalServerError), ErrorMessage = e.Message });
            }
        }
    }
}
