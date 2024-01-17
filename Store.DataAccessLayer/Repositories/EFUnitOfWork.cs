using Store.DataAccessLayer.Database;
using Store.DataAccessLayer.Entities;
using Store.DataAccessLayer.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DataAccessLayer.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly StoreDbContext db;
        private ProductsRepository productsRepository;
        private CategoriesRepository categoriesRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new StoreDbContext(connectionString);
        }

        public IRepository<Products> Product
        {
            get
            {
                if (productsRepository == null)
                {
                    productsRepository = new ProductsRepository(db);
                }
                return productsRepository;
            }
        }
        public IRepository<Categories> Category
        {
            get
            {
                if (categoriesRepository == null)
                {
                    categoriesRepository = new CategoriesRepository(db);
                }
                return (IRepository<Categories>)categoriesRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }
        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if(disposing) 
                { 
                    db.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
