using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.Genericite
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        void Insert(T obj);
    }
}
