using MVC_PROJEKT.Models.Produkty;

namespace MVC_PROJEKT.Services
{
    public interface IProduktservice
    {
        public List<ProduktModel> GetProdukty();
        public void CreateProdukty(int id, string nazwa, int cena, string kategoria);
    }
}
