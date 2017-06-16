using Pet.Database;
using Pet.Services.Pet;
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
        private static UnitOfWorkFactory unitOfWorkFactory;
        private static IPetService petService;

        private static IEnumerable<Pet.Database.Entities.Pet> petsCache;

        public PetController()
        {
            unitOfWorkFactory = new UnitOfWorkFactory(new Config());
            petService = new PetService(unitOfWorkFactory);

            petsCache = petService.GetAllPets();
        }

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

            //petsCache.Add(pet);

            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Details(Guid id)
        {
            return View(petsCache.First(x => x.ID == id));
        }


        public ActionResult Delete(Guid id)
        {
            //petsCache.Remove(petsCache.First(x => x.ID == id));
            return RedirectToAction("List");
        }
    }
}