using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Projekt_MVC.Models.Produkt
{
    
    public class ProduktModel
    {
        public ProduktModel()
        {
        }

        [Key]
        public int ProduktID { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string Price { get; set; }


    }
}
