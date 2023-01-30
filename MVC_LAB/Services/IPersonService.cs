using MVC_PROJEKT.Models.Pracownicy;

namespace MVC_PROJEKT.Services
{
    public interface IPersonservice
    {
        public List<PracownicyModel> GetPersons();
        public void CreatePracownicy(int id, string name, string dzial, GenderEnum gender);
    }
}
