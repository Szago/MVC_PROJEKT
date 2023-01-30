using Projekt_MVC.Context;
using Projekt_MVC.Models.Salon;

namespace Projekt_MVC.Services.SalonList
{
    public class SalonListService : ISalonListService
    {
        private readonly MainContext _SalonListService;
        public SalonListService(MainContext context)
        {
            _SalonListService = context;
        }

        public List<SalonModel> GetSalons()
        {
            return _SalonListService.Salons.ToList();
        }
        public void CreateSalon(string name, string address, string phone, string email, string openhours, string opendays)
        {
            var lastId = _SalonListService.Salons.OrderByDescending(x => x.ID).FirstOrDefault()?.ID;
            if (lastId != null)
            {
                var newSL = new SalonModel()
                {
                    ID = (int)lastId + 1,
                    Name = name,
                    Address = address,
                    Phone = phone,
                    Email = email,
                    OpenHours = openhours,
                    OpenDays = opendays
                };
                _SalonListService.Salons.Add(newSL);
                _SalonListService.SaveChanges();
            }

        }
        public async void DeleteSalon(int id)
        {

            SalonModel SL;
            var sls = _SalonListService.Salons.Find(id);
            SL = sls;
            if (SL != null)
            {
                _SalonListService.Salons.Remove(SL);
                _SalonListService.SaveChanges();
            }
        }

        public SalonModel GetSalons(int id)
        {
            return _SalonListService.Salons.FirstOrDefault(x => x.ID == id) ?? new SalonModel();
        }

        public void EditSalonList(long id, string name, string address, string phone, string email, string openhours, string opendays)
        {
            var S = _SalonListService.Salons.FirstOrDefault(x => x.ID == id);
            if (S != null)
            {
                S.Name = name;
                S.Address = address;
                S.Phone = phone;
                S.Email = email;
                S.OpenHours = openhours;
                S.OpenDays = opendays;
                _SalonListService.Update(S);
                _SalonListService.SaveChanges();
            }
        }
    }
}