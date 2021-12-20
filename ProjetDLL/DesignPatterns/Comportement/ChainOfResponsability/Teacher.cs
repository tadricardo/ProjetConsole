using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.DesignPatterns.Comportement.ChainOfResponsability
{
    public class Teacher : StaffMember
    {
        public Teacher(string name, StaffMember successor) : base(name, successor)
        {
        }

        public override void HandleComplaint(ComplaintRequest request)
        {
            //Ne peut traiter que les requêtes de type 1
            if (request.ComplaintType == 1)
            {
                Console.WriteLine("Taritée par le prof.........");
                request.State = ComplaintRequest.ComplaintState.CLOSED;
            }
            else if(Successor != null)
            {
                Console.WriteLine("Prof à remonter la demande à son Directeur pédagogique....");
                Successor.HandleComplaint(request);
            }
        }
    }
}
