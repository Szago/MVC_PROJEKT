using Projekt_MVC.Context;
using Projekt_MVC.Models.Produkt;
using Projekt_MVC.Models.TDriveModel;

namespace Projekt_MVC.Services.Pracownicy
{
    public class PracownicyService : IPracownicyService
    {
        private readonly MainContext _PracownicyService;
        

        public PracownicyService(MainContext context)
        {
            _PracownicyService = context;
        }

        public List<PracownicyModel> GetPracownicyLista()
        {
            return _PracownicyService.PracownicyLista.ToList();
        }
        public void CreatePracownicy( string imie, string nazwisko, int nrtel)
        {
            var lastId = _PracownicyService.PracownicyLista.OrderByDescending(x => x.ID).FirstOrDefault()?.ID;
            if (lastId != null)
            {
                var newTD = new PracownicyModel()
                {
                    ID = (int)lastId + 1,
                    Imie = imie,
                    Nazwisko = nazwisko,
                    NrTel = nrtel,
                };
                _PracownicyService.PracownicyLista.Add(newTD);
                
                _PracownicyService.SaveChanges();
            }

        }
        public async void DeletePracownicy(int id)
        {

            PracownicyModel TD;
            var tdt = _PracownicyService.PracownicyLista.Find(id);
            TD = tdt;
            if (TD != null)
            {
                _PracownicyService.PracownicyLista.Remove(TD);
                _PracownicyService.SaveChanges();
            }
        }

        public PracownicyModel GetPracownicyLista(int id)
        {
            return _PracownicyService.PracownicyLista.FirstOrDefault(x => x.ID == id) ?? new PracownicyModel();
        }

        public void EditPracownicy(long id, string imie, string nazwisko, int nrtel )
        {
            var TD = _PracownicyService.PracownicyLista.FirstOrDefault(x => x.ID == id);
    
            if (TD != null)
            {
                TD.Imie = imie;
               TD.Nazwisko = nazwisko;
                TD.NrTel = nrtel;

                _PracownicyService.Update(TD);
                _PracownicyService.SaveChanges();
            }
        }

    }
}

