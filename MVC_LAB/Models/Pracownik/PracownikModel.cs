using MVC_PROJEKT.Context;

namespace MVC_PROJEKT.Models.Pracownicy
{
    public class PracownicyModel
    {
        public PracownicyModel()
        {
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public GenderEnum Gender { get; set; }
        public string Dzial { get; set; }

    }

}
