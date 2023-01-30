using Microsoft.AspNetCore.Mvc;
using System.Net;
using Projekt_MVC.Models.Produkt;
using Projekt_MVC.Services.Produkt;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Projekt_MVC.Controllers
{
    public class ProduktListController : Controller
    {
        private readonly ILogger<ProduktListController> _logger;
        private readonly IProduktService _ProduktService;
        public ProduktListController(ILogger<ProduktListController> logger, IProduktService ProduktService)
        {
            _logger = logger;
            _ProduktService = ProduktService;
        }
        
        public IActionResult Index()
        {
            try
            {
                
                var model = new ProduktViewModel()
                {
                    Produkty = _ProduktService.GetProdukty()
                };
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while getting produkty");
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
           
           
        }
        public IActionResult NewProdukt()
        {/*
            try
            {
                if (ModelState.IsValid)
                {
                    var model = new CreateProduktViewModel()
                    {
                        Engine = new List<SelectListItem>()
                    };

                    foreach (var item in Enum.GetValues(typeof(EngineEnum)))
                    {

                        model.Engine.Add(new SelectListItem()
                        {
                            Text = item.ToString(),
                            Value = item.ToString()
                        });
                    }
                    return View(model);
                }
                else
                {
                    return View();
                }
              
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while getting produkts");
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
           */
            return View();
        }
        
        public IActionResult CreateNewProdukt( string name, string model, string price)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (Int32.Parse(price) <= 0)
                    {
                        throw new Exception("Cena nie mniejsza niż 0");
                    }
                    _ProduktService.CreateProdukt(name, model, price);
                    return RedirectToAction("Index");

                }
                else
                {
                    return RedirectToAction("NewProdukt");

                }
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.NotAcceptable, e.Message);
            }
            
        }
        
        public IActionResult DeleteProdukt(int id)
        {
            try
            {
                _ProduktService.DeleteProdukt(id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
            
        }

        
        public IActionResult EditProdukt(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var produkt = _ProduktService.GetProdukt(id);
                    var model = new EditProduktViewModel()
                    {
                        ProduktID = produkt.ProduktID,
                        Name = produkt.Name,
                        Model = produkt.Model,

                        Price = produkt.Price,

                    };




                    return View(model);
                }
                else
                {
                    return RedirectToAction("EditProdukt",new {ProduktID=id});
                }
                
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
        
        public IActionResult EditProduktDetails(long ProduktID, string name, string model, string price)
        {

            if (ModelState.IsValid)
            {
                if (Int32.Parse(price) <= 0)
                {
                    throw new Exception("Cena nie mniejsza niż 0");
                }
                _ProduktService.EditProdukt(ProduktID, name, model, price);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("EditProdukt", new { ProduktID=ProduktID, name=name,model=model });
            }
        }


        [HttpGet]
        public async Task<ActionResult> GetProduktyListJson()
        {
            try
            {
                var model = new ProduktViewModel()
                {
                    Produkty = _ProduktService.GetProdukty()
                };
                return Json(model);
            }
            catch (Exception e)
            {
                return Json(new { Status = "Get Failed", ErrorMessage = e.Message });
            }
            
           
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteProduktJson(int ProduktID)
        {
            try
            {
                if (ProduktID == null)
                {
                    throw new Exception("Niepoprawne ID");
                   
                    
                }
                _ProduktService.DeleteProdukt(ProduktID);
                return Json(new { Status = "Delete Succesfull"});
            }
            catch (Exception e)
            {
                return Json(new { Status = "Delete Failed", ErrorMessage = e.Message });
            }
        }
        [HttpPost]
        public async Task<ActionResult> CreateProduktJson(string name, string model, string price)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (Int32.Parse(price) <= 0)
                    {
                        throw new Exception("Cena nie mniejsza niż 0");
                    }
                    _ProduktService.CreateProdukt(name, model, price);
                    return Json(new { Status = "Add Succesfull" });

                }
                else
                {
                    throw new Exception("Model is invalid");

                }
            }
            catch (Exception e)
            {
                return Json(new { Status = "Add Failed", ErrorMessage = e.Message });
            }
        }
      
        [HttpPut]
        public async Task<ActionResult> EditProduktJson(long ProduktID, string name, string model, string price)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (Int32.Parse(price) <= 0)
                    {
                        throw new Exception("Cena nie mniejsza niż 0");
                    }
                    if (_ProduktService.EditProdukt(ProduktID, name, model, price))
                    {

                        return Json(new { Status = "Edit Succesfull" });
                    }
                    else
                    {
                        throw new Exception("Bład edycji produktu");
                    }
                }
                else
                {
                    throw new Exception("Model is invalid");
                }
            }
            catch (Exception e)
            {
                return Json(new { Status = "Edit Failed", ErrorMessage = e.Message });
            }
        }
    }
}
