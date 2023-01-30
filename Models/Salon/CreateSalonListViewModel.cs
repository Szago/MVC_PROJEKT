using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Projekt_MVC.Models.Salon
{
    [Keyless]
    public class CreateSalonListViewModel
    {
        [Required(ErrorMessage = "Nazwa jest wymagana")]
        [Display(Name = "Name")]
        [RegularExpression(@"^[AaĄąBbCcĆćDdEeĘęFfGgHhIiJjKkLlŁłMmNnŃńOoÓóPpRrSsŚśTtUuWwYyZzŹźŻża-zA-Z0-9\s]*$", ErrorMessage = "Nazwa Salonu nie jest poprawna.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Adres jest wymagany")]
        [Display(Name = "Address")]
        [RegularExpression(@"^[AaĄąBbCcĆćDdEeĘęFfGgHhIiJjKkLlŁłMmNnŃńOoÓóPpRrSsŚśTtUuWwYyZzŹźŻża-zA-Z0-9\s]*$", ErrorMessage = "Adres nie jest poprawny.")]
        public string Address { get; set; }
        
        [Required(ErrorMessage = "Numer telefonu jest wymagany")]
        [Display(Name = "Phone")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(12, ErrorMessage = "Telefon może składać się z maksymalnie 12 znaków.")]
        [RegularExpression(@"^(\d{3}-\d{3}-\d{3}|^\d{3}\d{3}\d{3})$", ErrorMessage = "Telefon musi być w formacie : 123-123-123 lub 123123123 ")]
        [MinLength(9, ErrorMessage = "Telefon musi składać się z 9 cyfr")]
        [MaxLength(12, ErrorMessage = "Telefon musi składać się z 12 cyfr")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email jest wymagany")]
        [Display(Name = "Email")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Email nie jest poprawny")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Godziny otwarcia są wymagane")]
        [Display(Name = "Open Hours")]
        [RegularExpression(@"^([0-1]?[0-9]|2[0-3]):[0-5][0-9]-([0-1]?[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessage = "Godziny otwarcia powinny mieć następujący format 00:00-00:00")]
        public string OpenHours { get; set; }

        [Required(ErrorMessage = "Dni otwarcia są wymagane")]
        [Display(Name = "Open Days")]
        [RegularExpression(@"^[AaĄąBbCcĆćDdEeĘęFfGgHhIiJjKkLlŁłMmNnŃńOoÓóPpRrSsŚśTtUuWwYyZzŹźŻża-zA-Z0-9\s-]*$", ErrorMessage = "Dni otwarcia powinny mieć następujący format Poniedziałek-Niedziela")]
        public string OpenDays { get; set; }
    }
}
