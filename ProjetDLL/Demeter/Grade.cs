using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.Demeter
{
    public class Grade 
    {
        public List<StudentClasse> StudentClasses { get; set; }

        internal int CountStudents()
        {
            int count = 0;
            foreach (var classe in StudentClasses)
            {
                count += classe.CountStudents();
            }

            return count;
        }
    }
}
