using Microsoft.AspNetCore.Mvc;
using WebApplicationCaisseEnregistreuse.Models;
using WebApplicationCaisseEnregistreuse.Repository;

namespace WebApplicationCaisseEnregistreuse.Controllers
{
    public class ProduitController : Controller
    {
        private readonly ProduitRepository _produitFromDb;

        public ProduitController(ProduitRepository ProduitFromDb)
        {
            _produitFromDb = ProduitFromDb;
        }


        public IActionResult Index()
        {
            return View(_produitFromDb.GetAll());
        }

        public IActionResult Details(int id)
        {

            Produit? ProduitDetails = _produitFromDb.GetById(id);
            return View(ProduitDetails);
        }

        public IActionResult Add(int id)
        {
            if (id == 0) 
                return View();

            var produit = _produitFromDb.GetById(id);
            return View(produit);
        }



        public IActionResult DeleteByID(int id)
        {

            Produit? ProduitToDelete = _produitFromDb.GetById(id);

            if (ProduitToDelete == null)
                return RedirectToAction(nameof(Index));


            _produitFromDb.DeleteByID(id);
            return RedirectToAction(nameof(Index));

        }
    }
}
