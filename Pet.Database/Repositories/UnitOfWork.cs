﻿using Pet.Database.Repositories;
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
        private IUserDetailsRepository userDetailsRepository;

        public IUserDetailsRepository UserDetailsRepository
        {
            get
            {
                if (userDetailsRepository == null)
                {
                    userDetailsRepository = new UserDetailsRepository(dbContext, this);
                }
                return userDetailsRepository;
            }
        }

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

        public void Save()
        {
            dbContext.SaveChanges();
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
