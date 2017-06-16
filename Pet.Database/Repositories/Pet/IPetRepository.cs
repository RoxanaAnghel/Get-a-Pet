﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Database.Repositories
{
    public interface IPetRepository:IBaseRepository<Entities.Pet>
    {
        Entities.Pet[] getAll();
    }
}