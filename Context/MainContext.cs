using Microsoft.EntityFrameworkCore;
using Projekt_MVC.Models.Produkt;
using Projekt_MVC.Models.Salon;
using Projekt_MVC.Models.TDriveModel;

namespace Projekt_MVC.Context
{
    public class MainContext : DbContext
    {

        public MainContext(DbContextOptions options) : base(options)
        {
            
        }


        public DbSet<ProduktModel> Produkty { get; set; }
        public DbSet<PracownicyModel> PracownicyLista { get; set; }
        public DbSet<SalonModel> Salons { get; set; }
        



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProduktModel>().ToTable("Produkty");
            modelBuilder.Entity<PracownicyModel>().ToTable("PracownicyLista");
            modelBuilder.Entity<SalonModel>().ToTable("Salons");
        }


        
    }
}
