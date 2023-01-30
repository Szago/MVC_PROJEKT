using Projekt_MVC.Models.Salon;

namespace Projekt_MVC.Services.SalonList
{
    public interface ISalonListService
    {
        public List<SalonModel> GetSalons();
        void CreateSalon(string name, string address, string phone, string email, string openhours, string opendays);
        void DeleteSalon(int id);
        public SalonModel GetSalons(int id);
        public void EditSalonList(long id, string name, string address, string phone, string email, string openhours, string opendays);
    }
}