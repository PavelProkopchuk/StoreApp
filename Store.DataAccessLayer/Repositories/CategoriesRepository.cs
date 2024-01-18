using Microsoft.EntityFrameworkCore;
using Store.DataAccessLayer.Database;
using Store.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DataAccessLayer.Repositories
{
    public class CategoriesRepository
    {
        private readonly StoreDbContext db;

        public CategoriesRepository(StoreDbContext db) 
        { 
            this.db = db;
        }
        public IEnumerable<Category> GetAll()
        {
            return db.Category.Include(o => o.Id);
        }

        public Category Get(int id)
        {
            return db.Category.Find(id);
        }

        public void Create(Category order)
        {
            db.Category.Add(order);
        }

        public void Update(Category order)
        {
            db.Entry(order).State = EntityState.Modified;
        }
        public IEnumerable<Category> Find(Func<Category, Boolean> predicate)
        {
            return db.Category.Include(o => o.Id).Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            Category order = db.Category.Find(id);
            if (order != null)
                db.Category.Remove(order);
        }
    }
}
