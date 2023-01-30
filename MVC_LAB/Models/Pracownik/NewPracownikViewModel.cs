namespace MVC_PROJEKT.Models.Pracownicy
{
    public class NewPracownicyViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public GenderEnum Gender { get; set; }
        public string Dzial { get; set; }
    }
}
