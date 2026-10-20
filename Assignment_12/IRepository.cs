using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_12
{
    internal interface IRepository<TEntity>
    {
        void Create(TEntity entity);
        List<TEntity> GetAll();
        TEntity GetById(int id);
        void Update(int id , TEntity entity);
        void Delete(int id);

    }
}
