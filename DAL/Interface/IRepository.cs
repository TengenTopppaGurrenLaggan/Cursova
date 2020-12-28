using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
   public  interface IRepository<T> where T :class
    {

        IDbSet<T> GetAll();
        T GetTbyID(int id);
        void Create(T item);
        void Update(T Item);
        void Delete(int id);



    }
}
