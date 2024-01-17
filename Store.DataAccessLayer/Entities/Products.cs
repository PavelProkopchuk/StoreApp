using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DataAccessLayer.Entities
{
    public class Products
    {
        public int Id { get; set; }
        public string CategoryId { get; set; }
        public string ProductsName { get; set; }
        public string ProductType { get; set; }
        public string ProductDescription { get; set; }
        public string ProductPrice { get; set; }
        public ICollection<Categories> Categories { get; set; }
    }
}
