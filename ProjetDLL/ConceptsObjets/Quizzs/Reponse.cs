namespace ProjetDLL.ConceptsObjets.Quizzs
{
    public class Reponse
    {
        public int Id { get; set; }
        public string RepText { get; set; }
        public bool IsCorrect { get; set; }

        public Reponse(string repText, bool isCorrect)
        {
            RepText = repText;
            IsCorrect = isCorrect;
        }
    }
}