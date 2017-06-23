using Pet.Database;
using Pet.Services.Pet;
using System.Linq;
using System.Web.Http;

namespace Pet.Web.Controllers.API
{
    [RoutePrefix("api/pets")]
    public class PetsController : ApiController
    {
        private static UnitOfWorkFactory unitOfWorkFactory;
        private static IPetService petService;

        public PetsController()
        {
            unitOfWorkFactory = new UnitOfWorkFactory(new Config());
            petService = new PetService(unitOfWorkFactory);
        }

        [Route("")]
        [HttpGet]
        public IHttpActionResult GetAllPets()
        {
            Database.Entities.Pet[] pets = petService.GetAllPets().ToArray();
            return Ok(pets);
        }
    }
}