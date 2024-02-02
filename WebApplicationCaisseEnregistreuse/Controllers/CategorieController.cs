using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplicationCaisseEnregistreuse.Models;
using WebApplicationCaisseEnregistreuse.Repository;

namespace WebApplicationCaisseEnregistreuse.Controllers
{
    public class CategorieController : Controller
    {
        private readonly CategorieRepository _categorieFromDb;

        public CategorieController(CategorieRepository CategorieFromDb)
        {
            _categorieFromDb = CategorieFromDb;
        }


        public IActionResult Index()
        {
            return View(_categorieFromDb.GetAll());
        }

        public IActionResult Add(Categorie aCategorie)
        {
            _categorieFromDb.Add(aCategorie);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult DeleteByID(int id)
        {

            Categorie? CategorieToDelete = _categorieFromDb.GetById(id);

            if (CategorieToDelete == null)
                return RedirectToAction(nameof(Index));


            _categorieFromDb.DeleteByID(id);
            return RedirectToAction(nameof(Index));

        }
    }
}
