using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Database.Repositories
{
    public interface IBaseRepository<TModel>
    {
        IEnumerable<TModel> GetAll1();
        Task<TModel> GetByIDAsync(int? id);
        TModel[] GetAll();
        void Create(TModel model);
        void Update(TModel model);
        void Delete(TModel model);
    }
}
