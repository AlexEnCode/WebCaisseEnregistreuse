using Microsoft.EntityFrameworkCore;
using WebApplicationCaisseEnregistreuse.Data;


namespace WebApplicationCaisseEnregistreuse.Repository
{
    public class ProduitRepository
    {

        private readonly ApplicationDbContext _context;

        public ProduitRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Models.Produit> GetAll()
        {
            return _context.Set<Models.Produit>().ToList();
        }

        public Models.Produit? GetById(int id)
        {
            return _context.Set<Models.Produit>().FirstOrDefault(c => c.Id == id);
        }

        public bool Add(Models.Produit aProduit)
        {

            _context.Set<Models.Produit>().Add(aProduit);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteByID(int id)
        {
            var produit = GetById(id);

            if (produit == null)
                return false;
            _context.Set<Models.Produit>().Remove(produit);
            _context.SaveChanges();
            return true;

        }
    }
}