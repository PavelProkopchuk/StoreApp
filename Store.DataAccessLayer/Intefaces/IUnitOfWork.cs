using Store.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Store.DataAccessLayer.Intefaces
{
    public  interface IUnitOfWork
    {
        IRepository<Product> Product { get; }
        IRepository<Category> Category { get; }
        void Save();
    }
}
