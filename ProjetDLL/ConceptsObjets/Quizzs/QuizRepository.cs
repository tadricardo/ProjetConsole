using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.ConceptsObjets.Quizzs
{
    public class QuizRepository
    {

        public static Quizz GenerateQuizz()
        {
            Quizz quiz = new Quizz("c#");
            Question qst1 = new Question("Comment déclarer une constante?", false, 1);
            qst1.Reponses.Add(new Reponse("const type nom=valeur", true));
            qst1.Reponses.Add(new Reponse("#define type nom=valeur", false));
            quiz.Questions.Add(qst1);

            Question qst2 = new Question("Quels sont les accesseurs de visibilité en c#?", true, 2);
            qst2.Reponses.Add(new Reponse("public", true));
            qst2.Reponses.Add(new Reponse("restricted", false));
            qst2.Reponses.Add(new Reponse("private", true));
            qst2.Reponses.Add(new Reponse("protect", false));
            quiz.Questions.Add(qst2);

            return quiz;

        }
    }
}
