using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.DesignPatterns.Comportement.ChainOfResponsability
{
    public class Directeur : StaffMember
    {
        public Directeur(string name, StaffMember successor) : base(name, successor)
        {
        }

        public override void HandleComplaint(ComplaintRequest request)
        {
            Console.WriteLine("Traitée par le Directeur...........");
            request.State = ComplaintRequest.ComplaintState.CLOSED;
        }
    }
}
