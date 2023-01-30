using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Projekt_MVC.Models.Sklep
{
    [Keyless]
    public class EditSklepModel
    {

        public EditSklepModel()
        {
        }
        public int ID { get; set; }
        [Required]
        [Display(Name = "Name")]
        [RegularExpression(@"^[AaĄąBbCcĆćDdEeĘęFfGgHhIiJjKkLlŁłMmNnŃńOoÓóPpRrSsŚśTtUuWwYyZzŹźŻża-zA-Z0-9\s]*$", ErrorMessage = "Nazwa Sklepu nie jest poprawna.")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Email nie jest poprawny.")]
        public string Email { get; set; }

    }
}
