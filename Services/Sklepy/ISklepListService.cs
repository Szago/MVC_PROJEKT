using Projekt_MVC.Models.Sklep;

namespace Projekt_MVC.Services.SklepList
{
    public interface ISklepListService
    {
        public List<SklepModel> GetSklepy();
        void CreateSklep(string name, string address, string email);
        void DeleteSklep(int id);
        public SklepModel GetSklepy(int id);
        public void EditSklepList(long id, string name, string address, string email);
    }
}