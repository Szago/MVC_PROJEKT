using Projekt_MVC.Context;
using Projekt_MVC.Models.Produkt;

namespace Projekt_MVC.Services.Produkt
{
    public class ProduktService : IProduktService
    {
        private readonly MainContext _ProduktService;
        public ProduktService(MainContext context)
        {
            _ProduktService = context;
        }
        public List<ProduktModel> GetProdukty()
        {
            return _ProduktService.Produkty.ToList();
        }
       

        public void CreateProdukt(string name, string model, string price)
        {
            var lastId = _ProduktService.Produkty.OrderByDescending(x => x.ProduktID).FirstOrDefault()?.ProduktID;
            if (lastId != null)
            {
                var newProdukt = new ProduktModel()
                {
                    ProduktID = (int)lastId + 1,
                    Name = name,
                    Model = model,
                    Price = price,

                };
                _ProduktService.Produkty.Add(newProdukt);
                _ProduktService.SaveChanges();

            }

        }

        public void DeleteProdukt(int id)
        {
            ProduktModel Produkt;
            var produktt = _ProduktService.Produkty.Find(id);
            Produkt = produktt;
            if (Produkt != null)
            {
                _ProduktService.Produkty.Remove(Produkt);
                _ProduktService.SaveChanges();
            }
        }

        public ProduktModel GetProdukt(int id)
        {
            return _ProduktService.Produkty.FirstOrDefault(x => x.ProduktID == id) ?? new ProduktModel();
        }

        public bool EditProdukt(long ProduktID, string name, string model, string price)
        {
            var Produkt = _ProduktService.Produkty.FirstOrDefault(x => x.ProduktID == ProduktID);
            if (Produkt != null)
            {
                Produkt.Name = name;
                Produkt.Model = model;
                Produkt.Price = price;

                _ProduktService.Update(Produkt);
                _ProduktService.SaveChanges();
                return true;
            }
            return false;
        }
    }
   


      
}

