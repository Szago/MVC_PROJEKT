using MVC_PROJEKT.Context;
using MVC_PROJEKT.Models.Produkty;

namespace MVC_PROJEKT.Services
{
    public class Produktservice : IProduktservice
    {
        private readonly ProduktyContext _context;
        public Produktservice(ProduktyContext context)
        {
            _context = context;
        }

        public void CreateProdukty(int id, string nazwa, int cena, string kategoria)
        {
            _context.Produkty.Add(new ProduktModel()
            {
                ID = id,
                Nazwa = nazwa,
                Cena = cena,
                Kategoria = kategoria
            });
            _context.SaveChanges();
        }

        public List<ProduktModel> GetProdukty()
        {
            return _context.Produkty.ToList();
        }
    }
}
