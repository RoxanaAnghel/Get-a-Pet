using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pet.Database.Entities;
namespace Pet.Services.Pet
{
    public interface IPetService
    {
        IEnumerable<Database.Entities.Pet> GetAllPets();
        void Delete(Guid id);
        void Update(Database.Entities.Pet pet);
        Database.Entities.Pet GetPet(Guid id);
        void Create(Database.Entities.Pet pet);
        Database.Entities.Pet[] GetPetsForOwner(Guid id);


    }
}
