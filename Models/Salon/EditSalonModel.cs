using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Projekt_MVC.Models.Salon
{
    [Keyless]
    public class EditSalonModel
    {

        public EditSalonModel()
        {
        }
        public int ID { get; set; }
        [Required]
        [Display(Name = "Name")]
        [RegularExpression(@"^[AaĄąBbCcĆćDdEeĘęFfGgHhIiJjKkLlŁłMmNnŃńOoÓóPpRrSsŚśTtUuWwYyZzŹźŻża-zA-Z0-9\s]*$", ErrorMessage = "Nazwa Salonu nie jest poprawna.")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Phone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\d{3}-\d{3}-\d{3}|^\d{3}\d{3}\d{3})$", ErrorMessage = "Telefon musi być w formacie : 123-123-123 lub 123123123 ")]
        public string Phone { get; set; }

        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Email nie jest poprawny.")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Open Hours")]
        [RegularExpression(@"^([0-1]?[0-9]|2[0-3]):[0-5][0-9]-([0-1]?[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessage = "Godziny otwarcia muszą być w formacie: 00:00-00:00")]
        public string OpenHours { get; set; }

        [Required]
        [Display(Name = "Open Days")]
        [RegularExpression(@"^[AaĄąBbCcĆćDdEeĘęFfGgHhIiJjKkLlŁłMmNnŃńOoÓóPpRrSsŚśTtUuWwYyZzŹźŻża-zA-Z0-9\s-]*$", ErrorMessage = "Dni otwarcia muszą być w formacie: Poniedziałek-Niedziela")]
        public string OpenDays { get; set; }
    }
}
