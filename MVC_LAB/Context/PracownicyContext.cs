using Microsoft.EntityFrameworkCore;
using MVC_PROJEKT.Models.Pracownicy;


namespace MVC_PROJEKT.Context
{
    public class PracownicyContext : DbContext
    {

        public PracownicyContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<PracownicyModel> PracownicyLista { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
