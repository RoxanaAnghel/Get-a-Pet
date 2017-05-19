using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pet.Web.Controllers
{
    [Authorize]
    public class PetController : Controller
    {
        private static List<Models.Pet> petsCache = new List<Models.Pet>()
        {
            new Models.Pet() { ID = Guid.NewGuid(), Location = "Location1", Name = "Name1", ImageUrl = "https://images-na.ssl-images-amazon.com/images/G/01/img15/pet-products/small-tiles/23695_pets_vertical_store_dogs_small_tile_8._CB312176604_.jpg" },
            new Models.Pet() { ID = Guid.NewGuid(), Location = "Location2", Name = "Name2", ImageUrl = "https://images-na.ssl-images-amazon.com/images/G/01/img15/pet-products/small-tiles/23695_pets_vertical_store_dogs_small_tile_8._CB312176604_.jpg" },
            new Models.Pet() { ID = Guid.NewGuid(), Location = "Location3", Name = "Name3", ImageUrl = "https://images-na.ssl-images-amazon.com/images/G/01/img15/pet-products/small-tiles/23695_pets_vertical_store_dogs_small_tile_8._CB312176604_.jpg" },
        };

        // GET: Pet
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            return View(petsCache);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Models.Pet());
        }

        [HttpPost]
        public ActionResult Create(Models.Pet pet)
        {
            pet.ID = Guid.NewGuid();

            petsCache.Add(pet);

            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Details(Guid id)
        {
            return View(petsCache.First(x => x.ID == id));
        }


        public ActionResult Delete(Guid id)
        {
            petsCache.Remove(petsCache.First(x => x.ID == id));
            return RedirectToAction("List");
        }
    }
}