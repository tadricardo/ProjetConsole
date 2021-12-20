using System.Collections.Generic;

namespace ProjetDLL.ConceptsObjets.Quizzs
{
    public class Question
    {
        public int Id { get; set; }
        public string QstText { get; set; }
        public bool IsMultiple { get; set; }
        public int NumOrder { get; set; }
        public List<Reponse> Reponses { get; set; }

        public Question(string qstText, bool isMultiple, int numOrder)
        {
            QstText = qstText;
            IsMultiple = isMultiple;
            NumOrder = numOrder;
            Reponses = new List<Reponse>();
        }
    }
}