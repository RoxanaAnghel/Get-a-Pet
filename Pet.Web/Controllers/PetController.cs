using Pet.Database;
using Pet.Services.Pet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            return View(petService.GetAllPets());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Models.Pet());
        }

        [HttpPost]
        public ActionResult Create(Database.Entities.Pet pet)
        {
            pet.ID = Guid.NewGuid();

            petService.Create(pet);

            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Details(Guid id)
        {
            Database.Entities.Pet pet = petService.GetPet(id);
            return View(pet);
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            Database.Entities.Pet pet = petService.GetPet(id);
            return View(pet);
        }

        [HttpPost]
        public ActionResult Edit(Database.Entities.Pet pet)
        {
            petService.Update(pet);
            return RedirectToAction("Details", pet);
        }

        public ActionResult Delete(Guid id)
        {
            //petsCache.Remove(petsCache.First(x => x.ID == id));
            petService.Delete(id);
            return RedirectToAction("List");
        }
    }
}