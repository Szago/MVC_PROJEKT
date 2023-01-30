using Projekt_MVC.Context;
using Projekt_MVC.Models.Sklep;

namespace Projekt_MVC.Services.SklepList
{
    public class SklepListService : ISklepListService
    {
        private readonly MainContext _SklepListService;
        public SklepListService(MainContext context)
        {
            _SklepListService = context;
        }

        public List<SklepModel> GetSklepy()
        {
            return _SklepListService.Sklepy.ToList();
        }
        public void CreateSklep(string name, string address, string email)
        {
            var lastId = _SklepListService.Sklepy.OrderByDescending(x => x.ID).FirstOrDefault()?.ID;
            if (lastId != null)
            {
                var newSL = new SklepModel()
                {
                    ID = (int)lastId + 1,
                    Name = name,
                    Address = address,

                    Email = email,

                };
                _SklepListService.Sklepy.Add(newSL);
                _SklepListService.SaveChanges();
            }

        }
        public async void DeleteSklep(int id)
        {

            SklepModel SL;
            var sls = _SklepListService.Sklepy.Find(id);
            SL = sls;
            if (SL != null)
            {
                _SklepListService.Sklepy.Remove(SL);
                _SklepListService.SaveChanges();
            }
        }

        public SklepModel GetSklepy(int id)
        {
            return _SklepListService.Sklepy.FirstOrDefault(x => x.ID == id) ?? new SklepModel();
        }

        public void EditSklepList(long id, string name, string address, string email )
        {
            var S = _SklepListService.Sklepy.FirstOrDefault(x => x.ID == id);
            if (S != null)
            {
                S.Name = name;
                S.Address = address;
                S.Email = email;

                _SklepListService.Update(S);
                _SklepListService.SaveChanges();
            }
        }


    }
}