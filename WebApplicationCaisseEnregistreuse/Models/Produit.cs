using System.ComponentModel.DataAnnotations;

namespace WebApplicationCaisseEnregistreuse.Models
{
    public class Produit
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom est requis")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "La description est requise")]
        public string Description { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Le prix doit être supérieur à zéro")]
        public decimal Prix { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "La quantité en stock doit être un nombre positif")]
        public int QuantiteStock { get; set; }

        [Required(ErrorMessage = "La catégorie est requise")]
        public string Categorie { get; set; }

        public string ImageUrl { get; set; }
    }
}
