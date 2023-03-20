using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizzeriaHub.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Get(object id);
        TEntity Find (object id);
        void Add(TEntity entity);
        void Update (TEntity entity);
        void Delete(object id);
        void Remove(TEntity entity);
        int SaveChanges();
    }
}
