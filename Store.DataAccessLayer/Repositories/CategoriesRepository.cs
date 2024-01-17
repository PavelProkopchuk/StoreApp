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
        public IEnumerable<Categories> GetAll()
        {
            return db.Category.Include(o => o.Id);
        }

        public Categories Get(int id)
        {
            return db.Category.Find(id);
        }

        public void Create(Categories order)
        {
            db.Category.Add(order);
        }

        public void Update(Categories order)
        {
            db.Entry(order).State = EntityState.Modified;
        }
        public IEnumerable<Categories> Find(Func<Categories, Boolean> predicate)
        {
            return db.Category.Include(o => o.Id).Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            Categories order = db.Category.Find(id);
            if (order != null)
                db.Category.Remove(order);
        }
    }
}
