using data_access.Data;
using data_access.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Repositories
{
    public class UnitOfWork : IUoW, IDisposable
    {
        private static ApplicationContext context = new ApplicationContext();
        // For example
        //private IRepository<MyClass>? myClassRepo = null;

        //public IRepository<MyClass> MyClassRepo
        //{
        //    get
        //    {
        //        if (this.myClassRepo == null)
        //        {
        //            this.myClassRepo = new Repository<MyClass>(context);
        //        }
        //        return myClassRepo;
        //    }
        //}
        public UnitOfWork() { }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
