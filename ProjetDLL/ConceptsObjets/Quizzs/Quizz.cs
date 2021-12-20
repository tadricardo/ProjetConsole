using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.ConceptsObjets.Quizzs
{
    public class Quizz
    {
        //Variables de classes : contrairement au x variables locales elles possèdent des valeurs par defaut
        //Var numériques: 0
        //Var Bool : False
        //Type complèxe: null

        public int Id { get; set; }
        public string Sujet { get; set; }
        public List<Question> Questions { get; set; }

        public Quizz(string sujet)
        {
            Sujet = sujet;
            Questions = new List<Question>();
        }
    }
}
