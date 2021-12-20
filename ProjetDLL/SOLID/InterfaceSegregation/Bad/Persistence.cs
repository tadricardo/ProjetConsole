using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.SOLID.InterfaceSegregation.Bad
{
    public class Persistence : IEmploye
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Employe> GetAll()
        {
            throw new NotImplementedException();
        }

        public Employe GetById(int id)
        {
            throw new NotImplementedException();
        }

        public string GetContratType()
        {
            throw new NotImplementedException();
        }

        public DateTime GetDateEmbauche()
        {
            throw new NotImplementedException();
        }

        public void Update(Employe e)
        {
            throw new NotImplementedException();
        }
    }
}
