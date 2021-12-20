using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.SOLID.InterfaceSegregation.Good
{
    public interface IPersistence
    {
        List<Employe> GetAll();
        Employe GetById(int id);
        void Delete();
        void Update();
        void Add();
    }
}
