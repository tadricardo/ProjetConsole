using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.Demeter
{
    public class School
    {
        public List<Grade> Grades { get; set; }

        //Objectif: compter le nombre d'etudiant de School

        //public int CountStudents()
        //{
        //    int count = 0;
        //    foreach (var grade in Grades)
        //    {
        //        foreach (var studentClasse in grade.Classes)
        //        {
        //            foreach (var student in studentClasse.Students)
        //            {
        //                count++;
        //            }
        //        }
        //    }

        //    return count;
        //}

        //Loi Demeter
        public int CountStudents()
        {
            int count = 0;
            foreach (var grade in Grades)
            {
                count += grade.CountStudents();
            }

            return count;
        }
    }
}
