using MVC_PROJEKT.Context;
using MVC_PROJEKT.Models.Pracownicy;

namespace MVC_PROJEKT.Services
{
    public class Personservice : IPersonservice
    {
        private readonly PracownicyContext _context;
        public Personservice(PracownicyContext context)
        {
            _context = context;
        }

        public void CreatePracownicy(int id, string name, string dzial, GenderEnum gender)
        {
            _context.PracownicyLista.Add(new PracownicyModel()
            {
                ID = id,
                Name = name,
                Dzial = dzial,
                Gender = gender
            });
            _context.SaveChanges();
        }

        public List<PracownicyModel> GetPersons()
        {
            return _context.PracownicyLista.ToList();
        }
    }
}
