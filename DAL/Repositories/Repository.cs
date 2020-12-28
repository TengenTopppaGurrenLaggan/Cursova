using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {


        public DataBase context;
        public Repository(DataBase context){

            this.context = context;

        }
        public void Create(T item)
        {
            context.Set<T>().Add(item);
        }

        public void Delete(int id)
        {
            var item = context.Set<T>().Find(id);
            if (item!=null)
            {
                context.Set<T>().Remove(item);
            }
        }

        public IDbSet<T> GetAll()
        {
            return context.Set<T>();
        }

        public T GetTbyID(int id)
        {
            return context.Set<T>().Find(id);
        }

        public void Update(T Item)
        {
            context.Entry(Item).State = EntityState.Modified;
        }
    }
}
