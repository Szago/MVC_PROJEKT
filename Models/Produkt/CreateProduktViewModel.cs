using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Projekt_MVC.Models.Produkt
{

    [Keyless]
    
    public class CreateProduktViewModel
    {
        [Required(ErrorMessage = "Nazwa jest wymagana")]
        [StringLength(50, ErrorMessage = "Nazwa nie może byc dłuższa niż 50 znaków.")]
        [Display(Name = "Nazwa")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[AaĄąBbCcĆćDdEeĘęFfGgHhIiJjKkLlŁłMmNnŃńOoÓóPpRrSsŚśTtUuWwYyZzŹźŻża-zA-Z0-9\s]*$", ErrorMessage = "Nazwa produktu musi zaczynać się wielką literą")]
        [MinLength(3, ErrorMessage = "Nazwa nie może być krótsza niż 3 litery")]
        [MaxLength(50, ErrorMessage = "Nazwa nie może być dłuższa niż 50 liter")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Nazwa kategorii jest wymagana")]
        [StringLength(50, ErrorMessage = "Nazwa kategorii nie może byc dłuższa niż 50 znaków.")]
        [Display(Name = "Kategoria")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[AaĄąBbCcĆćDdEeĘęFfGgHhIiJjKkLlŁłMmNnŃńOoÓóPpRrSsŚśTtUuWwYyZzŹźŻża-zA-Z0-9\s]*$", ErrorMessage = "Nazwa kategorii musi zaczynać się wielką literą")]
        [MinLength(3, ErrorMessage = "Nazwa kategorii nie może być krótsza niż 3 litery")]
        [MaxLength(50, ErrorMessage = "Nazwa kategorii nie może być dłuższa niż 50 liter")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Cena jest wymagana")]
        [Display(Name = "Cena")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[\d0-9]{0,50}", ErrorMessage = "Cena musi być cyframi")]
        
        public string Price { get; set; }


    
    }
}
