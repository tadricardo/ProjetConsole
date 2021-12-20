using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.DesignPatterns.Comportement.ChainOfResponsability
{
    public class ResponsablePedago : StaffMember
    {
        public ResponsablePedago(string name, StaffMember successor) : base(name, successor)
        {
        }

        public override void HandleComplaint(ComplaintRequest request)
        {
            //Ne peut traiter que les requ^étes de type 2
            if (request.ComplaintType == 2)
            {
                Console.WriteLine("Traitée par le Responsable pédagogique......");
                request.State = ComplaintRequest.ComplaintState.CLOSED;
            }
            else if(Successor != null)
            {
                Console.WriteLine("Le Responsable pedago à remonter la demande à son Directeur......");
                Successor.HandleComplaint(request);
            }
        }
    }
}
