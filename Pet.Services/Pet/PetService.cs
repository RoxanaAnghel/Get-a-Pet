using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pet.Database.Entities;
using Pet.Database;

namespace Pet.Services.Pet
{
    public class PetService : IPetService
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        public PetService(UnitOfWorkFactory unitOfWorkFactory)
        {
            this.unitOfWorkFactory = unitOfWorkFactory;
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Database.Entities.Pet> GetAllPets()
        {
            using (IUnitOfWork unitOfWork = unitOfWorkFactory.Create())
            {
                return unitOfWork.PetRepository.GetAll();
            }
        }



        public void GetPet(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(Database.Entities.Pet pet)
        {
            throw new NotImplementedException();
        }
    }
}
