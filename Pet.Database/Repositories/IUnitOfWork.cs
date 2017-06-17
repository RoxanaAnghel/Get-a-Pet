using Pet.Database.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Database
{
    public interface IUnitOfWork:IDisposable
    {
        IPetRepository PetRepository { get;}
        IUserDetailsRepository UserDetailsRepository { get; }
        void Save();
    }
}
