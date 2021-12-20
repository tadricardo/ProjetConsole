namespace ProjetDLL.DesignPatterns.Comportement.ChainOfResponsability
{
    public class ComplaintRequest
    {
        public int StudentNumber { get; set; }

        //Selon le type, la plainte sera taritée par un membre: 1 pro, 2- responsable pedago, 3- Directeur
        public int ComplaintType { get; set; }
        public string Message { get; set; }

        public enum ComplaintState
        {
            OPENED,
            CLOSED
        }

        public ComplaintState State { get; set; }

        public ComplaintRequest(int studentNumber, int complaintType, string message, ComplaintState state)
        {
            StudentNumber = studentNumber;
            ComplaintType = complaintType;
            Message = message;
            State = state;
        }
    }
}