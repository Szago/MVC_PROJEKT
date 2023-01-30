using Microsoft.EntityFrameworkCore;
using Projekt_MVC.Models.Produkt;
using System.ComponentModel.DataAnnotations;

namespace Projekt_MVC.Models.TDriveModel
{
    [Keyless]
    public class EditPracownicyModel
    {

        public EditPracownicyModel()
        {

        }
        public int ID { get; set; }


        [Required(ErrorMessage = "Imie jest wymagane")]
        [Display(Name = "Imie")]
        [RegularExpression(@"^[AaĄąBbCcĆćDdEeĘęFfGgHhIiJjKkLlŁłMmNnŃńOoÓóPpRrSsŚśTtUuWwYyZzŹźŻża-zA-Z0-9\s]{3,50}", ErrorMessage = "Imie musi mieć więcej niż 3 znaki")]
        [DataType(DataType.Text)]
        public string Imie { get; set; }
        [Required(ErrorMessage = "Pole Nazwisko jest wymagane")]
        [Display(Name = "Nazwisko")]
        [RegularExpression(@"^[AaĄąBbCcĆćDdEeĘęFfGgHhIiJjKkLlŁłMmNnŃńOoÓóPpRrSsŚśTtUuWwYyZzŹźŻża-zA-Z0-9\s]{3,50}", ErrorMessage = "Nazwisko musi mieć więcej niż 3 znaki")]
        [DataType(DataType.Text)]
        public string Nazwisko { get; set; }



        [Required(ErrorMessage = "Pole Numer telefonu jest wymagane")]
        [Display(Name = "Numer Telefonu")]
        [StringLength(9, ErrorMessage = "NrTel nie może być dłuższy niż 9 znaków")]
        [RegularExpression(@"^(\d{3}-\d{3}-\d{3}|^\d{3}\d{3}\d{3})$", ErrorMessage = "Telefon musi być w formacie : 123-123-123 lub 123123123 ")]
        [DataType(DataType.Text)]
        [MinLength(9, ErrorMessage = "Numer telefonu musi mieć 9 znaków")]
        [MaxLength(9, ErrorMessage = "Numer telefonu nie może być dłuższy niż 9 znaków")]

        public int NrTel { get; set; }

    }
}
