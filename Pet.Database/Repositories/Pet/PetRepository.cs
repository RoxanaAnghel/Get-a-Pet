using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pet.Database.Entities;

namespace Pet.Database.Repositories
{
    public class PetRepository:BaseRepository<Entities.Pet>,IPetRepository
    {
        public PetRepository(PetDataContext dbContext,UnitOfWork unitOfWork):
            base(dbContext, unitOfWork)
        { }

        public Entities.Pet[] getAll()
        {
            return dbSet.ToArray();
        }
    }
}
