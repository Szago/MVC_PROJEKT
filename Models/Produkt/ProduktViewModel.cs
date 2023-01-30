using Microsoft.EntityFrameworkCore;

namespace Projekt_MVC.Models.Produkt
{
   
    public class ProduktViewModel
    {
        public ProduktViewModel()
        { }
       
        public List<ProduktModel> Produkty { get; set; }
    }
}
