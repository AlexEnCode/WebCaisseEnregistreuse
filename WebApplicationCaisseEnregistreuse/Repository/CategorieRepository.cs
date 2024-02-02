using WebApplicationCaisseEnregistreuse.Data;

namespace WebApplicationCaisseEnregistreuse.Repository
{
    public class CategorieRepository
    {
        private readonly ApplicationDbContext _context;

        public CategorieRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Models.Categorie> GetAll()
        {
            return _context.Set<Models.Categorie>().ToList();
        }

        public Models.Categorie? GetById(int id)
        {
            return _context.Set<Models.Categorie>().FirstOrDefault(c => c.Id == id);
        }

        public bool Add(Models.Categorie aCategorie)
        {

            _context.Set<Models.Categorie>().Add(aCategorie);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteByID(int id)
        {
            var categorie = GetById(id);

            if (categorie == null)
                return false;
            _context.Set<Models.Categorie>().Remove(categorie);
            _context.SaveChanges();
            return true;

        }
    }
}
