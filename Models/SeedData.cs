using Microsoft.EntityFrameworkCore;
using Projekt_MVC.Context;
using Projekt_MVC.Models.Produkt;
using Projekt_MVC.Models.Sklep;
using Projekt_MVC.Models.TDriveModel;

namespace Projekt_MVC.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MainContext(serviceProvider.GetRequiredService<DbContextOptions<MainContext>>()))
            {
                if (context.Produkty.Any())
                {
                    return;
                }
                context.Produkty.AddRange(
                    new ProduktModel()
                    {
                        ProduktID = 1,
                        Name = "Aston",
                        Model = "Martin",
                        Price = " 100000",


                    });


                    if (context.PracownicyLista.Any())
                {
                    return;
                }
                context.PracownicyLista.AddRange(
                    new PracownicyModel()
                    {
                        ID = 1,
                        Imie = "Robert",
                        Nazwisko = "Makłowicz",
                        NrTel = 123456789,

                    }

                );
                if (context.Sklepy.Any())
                {
                    return;
                }
                context.Sklepy.AddRange(
                   new SklepModel()
                   {
                       
                       ID=1,
                       Name = "Sklep 1",
                       Address = "Adres 1",
                       Email = "testemail@testmail.com"
                       
                   }

               );
                context.SaveChanges();
            }
        }
    }
}