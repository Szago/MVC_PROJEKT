using Microsoft.EntityFrameworkCore;
using MVC_PROJEKT.Context;
using MVC_PROJEKT.Models.Pracownicy;

namespace MVC_PROJEKT.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PracownicyContext(serviceProvider.GetRequiredService<DbContextOptions<PracownicyContext>>()))
            {
                if (context.PracownicyLista.Any())
                {
                    return;
                }
                context.PracownicyLista.AddRange(
                    new PracownicyModel()
                    {
                        Name = "Andrzej",
                        Dzial = "Rzeszów",
                        Gender = GenderEnum.Male,
                        ID = 1
                    },
                    new PracownicyModel()
                    {
                        Name = "Katarzyna",
                        Dzial = "Rzeszów",
                        Gender = GenderEnum.Female,
                        ID = 2
                    },
                    new PracownicyModel()
                    {
                        Name = "Julia",
                        Dzial = "Kraków",
                        Gender = GenderEnum.Female,
                        ID = 3
                    },
                    new PracownicyModel()
                    {
                        Name = "Piotr",
                        Dzial = "Warszawa",
                        Gender = GenderEnum.Male,
                        ID = 4
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
