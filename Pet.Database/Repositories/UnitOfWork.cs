using Pet.Database.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Database
{
    public class UnitOfWork:IUnitOfWork,IDisposable
    {
        private readonly PetDataContext dbContext;

        private IPetRepository petRepository;

        public IPetRepository PetRepository
        {
            get
            {
                if (petRepository == null)
                {
                    petRepository = new PetRepository(dbContext, this);
                }
                return petRepository;
            }
        }

        public UnitOfWork(IConfig config)
        {
            dbContext = new PetDataContext();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            if (dbContext != null)
            {
                dbContext.Dispose();
            }
        }

        
    }
}
