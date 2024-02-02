using System.Collections.Generic;
using System.Reflection.Emit;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplicationCaisseEnregistreuse.Models;

namespace WebApplicationCaisseEnregistreuse.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {
        }
        public DbSet<Produit> Produits { get; set; }
        public DbSet<Categorie> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produit>().HasData(
            new Produit() {
                Id = 1,
                Nom = "Ordinateur portable",
                Description = "Ordinateur portable haute performance",
                Prix = 999.99m,
                QuantiteStock = 50,
                Categorie = "Informatique",
                ImageUrl = "url_de_l_image1.jpg"
            },
                new Produit() {
                    Id = 2,
                    Nom = "Smartphone",
                    Description = "Smartphone dernier cri",
                    Prix = 599.99m,
                    QuantiteStock = 30,
                    Categorie = "Électronique",
                    ImageUrl = "url_de_l_image2.jpg"
                },
                new Produit()
                {
                    Id = 3,
                    Nom = "Livre",
                    Description = "Livre captivant",
                    Prix = 19.99m,
                    QuantiteStock = 100,
                    Categorie = "Littérature",
                    ImageUrl = "url_de_l_image3.jpg"
                }
                );

            modelBuilder.Entity<Categorie>().HasData(
           new Categorie()
           {
               Id = 1,
               Nom = "Informatique",
               ListeProduits = new List<Produit> { }
           },
               new Categorie()
               {
                   Id = 2,
                   Nom = "Électronique",
                   ListeProduits = new List<Produit> { }
               },
               new Categorie() {
                   Id = 3,
                   Nom = "Littérature",
                   ListeProduits = new List<Produit> {  }
               }
               );
        }
    }
}

