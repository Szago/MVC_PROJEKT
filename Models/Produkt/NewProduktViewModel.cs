using Microsoft.EntityFrameworkCore;

namespace Projekt_MVC.Models.Produkt
{
    [Keyless]
    public class NewProduktViewModel
    {
        public int ProduktID { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string Price { get; set; }

    }
}
