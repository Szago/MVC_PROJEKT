using Microsoft.EntityFrameworkCore;
using MVC_PROJEKT.Models.Pracownicy;
using MVC_PROJEKT.Models.Produkty;


namespace MVC_PROJEKT.Context
{ 
    public class ProduktyContext : DbContext
    {

        public ProduktyContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<ProduktModel> Produkty { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
