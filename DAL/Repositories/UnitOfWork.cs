
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace DAL.Repositories
{
    public class UnitOfWork : IDisposable
    {

        private DataBase context = new DataBase();
        private Repository<Category> Categoryrep;
        private Repository<Cust> Custrep;
        private Repository<Resume> Resumerep;
        private Repository<Unem> Unemrep;
        private Repository<Vac> Vacrep;


        public Repository<Category> Categorys
        {
            get
            {
                if (Categoryrep == null)
                {
                    Categoryrep = new Repository<Category>(context);
                }
                return Categoryrep ;
            }
            
        }

        public Repository<Cust> Custs
        {
            get
            {
                if (Custrep == null)
                {
                    Custrep = new Repository<Cust>(context);
                }
                return Custrep;
            }
            
        }
        public Repository<Resume> Resumes
        {
            get
            {
                if (Resumerep == null)
                {
                    Resumerep = new Repository<Resume>(context);
                }
                return Resumerep;
            }
            
        }
        public Repository<Unem> Unems
        {
            get
            {
                if (Unemrep == null)
                {
                    Unemrep = new Repository<Unem>(context);
                }
                return Unemrep;
            }
            
        }
        public Repository<Vac> Vacs
        {
            get
            {
                if (Vacrep == null)
                {
                    Vacrep = new Repository<Vac>(context);
                }
                return Vacrep;
                
            }
        }
        







        public void Save()
        {
            context.SaveChanges();
        }


        private bool disposingvalue = false;
        public void Dispose(bool disposing)
        {
            if (!disposingvalue)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                this.disposingvalue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
