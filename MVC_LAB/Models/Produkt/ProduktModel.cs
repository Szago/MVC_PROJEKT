using MVC_PROJEKT.Context;

namespace MVC_PROJEKT.Models.Produkty
{
    public class ProduktModel
    {
        public ProduktModel()
        {
        }

        public int ID { get; set; }
        public string Nazwa { get; set; }
        public int Cena { get; set; }
        public string Kategoria { get; set; }

    }
}
