using Microsoft.EntityFrameworkCore;
using Store.DataAccessLayer.Database;
using Store.DataAccessLayer.Entities;
using Store.DataAccessLayer.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Store.DataAccessLayer.Repositories
{
    public class ProductsRepository : IRepository<Product>
    {
        private readonly StoreDbContext db;

        public ProductsRepository(StoreDbContext context)
        {
            this.db = context;
        }

        public IEnumerable<Product> GetAll()
        {
            return db.Product;
        }

        public Product Get(int id)
        {
            return db.Product.Find(id);
        }

        public void Create(Product book)
        {
            db.Product.Add(book);
        }

        public void Update(Product book)
        {
            db.Entry(book).State = EntityState.Modified;
        }

        public IEnumerable<Product> Find(Func<Product, Boolean> predicate)
        {
            return db.Product.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Product products = db.Product.Find(id);
            if (products != null)
                db.Product.Remove(products);
        }
    }
}
