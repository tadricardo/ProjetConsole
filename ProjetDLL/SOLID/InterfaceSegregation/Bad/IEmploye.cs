using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.SOLID.InterfaceSegregation.Bad
{
    public interface IEmploye
    {
        List<Employe> GetAll();
        Employe GetById(int id);
        string GetContratType();
        DateTime GetDateEmbauche();

        void Delete(int id);
        void Update(Employe e);
    }
}
