using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.AspNetCore.Mvc.Rendering;
using Projekt_MVC.Services.SklepList;
using Projekt_MVC.Models.Sklep;
using System.Xml.Linq;

namespace Projekt_MVC.Controllers
{
    public class SklepListController : Controller
    {
        private readonly ILogger<SklepListController> _logger;
        private readonly ISklepListService _SklepListService;
        public SklepListController(ILogger<SklepListController> logger, ISklepListService sklepListService)
        {
            _logger = logger;
            _SklepListService = sklepListService;
        }
        public IActionResult Index()
        {
            try
            {
                var model = new SklepListViewModel()
                {
                    GetSklepy = _SklepListService.GetSklepy()
                };
               
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while getting sklepy");
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }


        }

        public IActionResult NewSklep()
        {
            try
            {

                var model = new CreateSklepListViewModel();
                if (ModelState.IsValid)
                {
                    return View(model);
                }
                else
                {
                    return RedirectToAction("NewSklep");
                }
                

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating new sklepy");
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
    }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateNewSklep(CreateSklepListViewModel model)
        {
            try
            {
                Console.WriteLine(Json(model));
                TryValidateModel(this.ModelState);
        
                if (ModelState.IsValid)
                {
                    _SklepListService.CreateSklep(model.Name, model.Address,  model.Email);
                    return RedirectToAction("Index");
                }
                else
                {
                    Console.WriteLine(Json(model));
                    return RedirectToAction("NewSklep");
                }


            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating new sklepy");
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
            
        }
        public IActionResult DeleteSklepList(int id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                _SklepListService.DeleteSklep(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while deleting sklepy");
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
      
        }

        public IActionResult EditSklepList(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id == null)
                    {
                        return NotFound();
                    }
                    var SL = _SklepListService.GetSklepy(id);
                    var model = new EditSklepModel()
                    {

                        ID = SL.ID,
                        Name = SL.Name,
                        Address = SL.Address,
                        Email = SL.Email,
                    };

                    return View(model);
                }
                else
                {
                    return RedirectToAction("EditSklepList", new { id = id });
                }
               
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while editing sklepy");
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
            
        }
        public IActionResult EditSklepDetails(long id, string name, string address, string email)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _SklepListService.EditSklepList(id, name, address,  email);
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("EditSklepList", new { id = id });
                }
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while editing sklepy");
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
         
        }

        [HttpGet]
        public async Task<ActionResult> GetSklepListJSON()
        {
            try
            {
                var model = new SklepListViewModel()
                {
                    GetSklepy = _SklepListService.GetSklepy()
                };
                return Json(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while getting sklepy");
                return Json(new { Status = "Get Failed", ErrorMessage = ex.Message });
            }
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteSklepJSON(int id)
        {
            try
            {
                if (id == null)
                {
                    throw new Exception("Niepoprawne ID");
                }
                _SklepListService.DeleteSklep(id);
                return Json(new { Status = "Delete Succesfull" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while deleting sklepy");
                return Json(new { Status = "Delete Failed", ErrorMessage = ex.Message });
            }
        }
        [HttpPost]
        public async Task<ActionResult> CreateNewSklepJSON(string name, string address,  string email)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _SklepListService.CreateSklep(name, address, email);
                    return Json(new { Status = "Add Succesfull" });
                }
                else
                {
                    throw new Exception("Model is invalid");
                }
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating new sklepy");
                return Json(new { Status = "Add Failed", ErrorMessage = ex.Message });
            }
        }
        [HttpPut]
        public async Task<ActionResult> EditSklepDetailsJSON(long id, string name, string address, string email)
        {
            try
            {
                _SklepListService.EditSklepList(id, name, address, email);
                return Json(new { Status = "Edit Succesfull" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while editing sklepy");
                return Json(new { Status = "Edit Failed", ErrorMessage = ex.Message });
            }
        }

    }
}
