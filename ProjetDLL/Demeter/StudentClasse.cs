using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.Demeter
{
    public class StudentClasse
    {
        public List<Student> AllStudents { get; set; }

        internal int CountStudents()
        {
            return AllStudents.Count;
        }
    }
}
