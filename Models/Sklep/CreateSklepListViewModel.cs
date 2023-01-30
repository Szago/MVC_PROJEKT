using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Projekt_MVC.Models.Sklep
{
    [Keyless]
    public class CreateSklepListViewModel
    {
        [Required(ErrorMessage = "Nazwa jest wymagana")]
        [Display(Name = "Name")]
        [RegularExpression(@"^[AaĄąBbCcĆćDdEeĘęFfGgHhIiJjKkLlŁłMmNnŃńOoÓóPpRrSsŚśTtUuWwYyZzŹźŻża-zA-Z0-9\s]*$", ErrorMessage = "Nazwa Sklepu nie jest poprawna.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Adres jest wymagany")]
        [Display(Name = "Address")]
        [RegularExpression(@"^[AaĄąBbCcĆćDdEeĘęFfGgHhIiJjKkLlŁłMmNnŃńOoÓóPpRrSsŚśTtUuWwYyZzŹźŻża-zA-Z0-9\s]*$", ErrorMessage = "Adres nie jest poprawny.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Email jest wymagany")]
        [Display(Name = "Email")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Email nie jest poprawny")]
        public string Email { get; set; }

    }
}
