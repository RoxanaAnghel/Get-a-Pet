using Pet.Database;
using Pet.Services.Pet;
using System;
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
        public IHttpActionResult GetAllPets(Guid? ownerId=null)
        {

            Database.Entities.Pet[] pets = petService.GetAllPets(ownerId).ToArray();
            return Ok(pets);
        }

        [Route("")]
        [HttpGet]
        public IHttpActionResult GetAllPetsFor(Guid ownerId)
        {

            Database.Entities.Pet[] pets = petService.GetAllPets(ownerId).ToArray();
            return Ok(pets);
        }

    }
}