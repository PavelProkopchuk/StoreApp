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
    public class ProductsRepository : IRepository<Products>
    {
        private readonly StoreDbContext db;

        public ProductsRepository(StoreDbContext context)
        {
            this.db = context;
        }

        public IEnumerable<Products> GetAll()
        {
            return db.Product;
        }

        public Products Get(int id)
        {
            return db.Product.Find(id);
        }

        public void Create(Products book)
        {
            db.Product.Add(book);
        }

        public void Update(Products book)
        {
            db.Entry(book).State = EntityState.Modified;
        }

        public IEnumerable<Products> Find(Func<Products, Boolean> predicate)
        {
            return db.Product.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Products products = db.Product.Find(id);
            if (products != null)
                db.Product.Remove(products);
        }
    }
}
