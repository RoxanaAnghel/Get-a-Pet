using Pet.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Database.Repositories
{
    public class UserDetailsRepository:BaseRepository<UserDetails>,IUserDetailsRepository
    {
        public UserDetailsRepository(PetDataContext dbContext, UnitOfWork unitOfWork):
            base(dbContext, unitOfWork)
        { }
    }
}
