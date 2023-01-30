using Projekt_MVC.Models.TDriveModel;

namespace Projekt_MVC.Services.Pracownicy
{
    public interface IPracownicyService
    {
        public List<PracownicyModel> GetPracownicyLista();
        void CreatePracownicy(string imie, string nazwisko, int nrtel );
        void DeletePracownicy(int id);
        public PracownicyModel GetPracownicyLista(int id);
        public void EditPracownicy(long id, string imie, string nazwisko,  int nrtel );
       
        
    }
}
