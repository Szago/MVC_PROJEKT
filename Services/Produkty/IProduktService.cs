using Projekt_MVC.Models.Produkt;

namespace Projekt_MVC.Services.Produkt
{
    public interface IProduktService
    {
        public List<ProduktModel> GetProdukty();
        public void CreateProdukt( string name, string model, string price);
        void DeleteProdukt(int id);
        public ProduktModel GetProdukt(int id);
        public bool EditProdukt(long ProduktID, string name, string model, string price);
       
    }
}
