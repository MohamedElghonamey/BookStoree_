using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models.Repsotrey
{
    public interface IBookStoreRepostery<TEntity>
    {
        IList<TEntity> List();
        TEntity Find(int ID); 
        void Add(TEntity entity);   
        void Update(int id,TEntity entity);    
        void Delete(int ID);    


    }
}
