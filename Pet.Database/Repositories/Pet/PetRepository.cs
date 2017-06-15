using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Database.Repositories
{
    public class PetRepository:BaseRepository<Entities.Pet>,IPetRepository
    {
        public PetRepository(PetDataContext dbContext,UnitOfWork unitOfWork):
            base(dbContext, unitOfWork)
        { }
    }
}
