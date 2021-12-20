using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.Genericite
{
    public class ProductRepository : IRepository<Product>
    {
        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(Product obj)
        {
            throw new NotImplementedException();
        }
    }
}
