using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.DesignPatterns.Comportement.ChainOfResponsability
{
    public abstract class StaffMember
    {
        public string Name { get; set; }
        public StaffMember Successor { get; set; }

        protected StaffMember(string name, StaffMember successor)
        {
            Name = name;
            Successor = successor;
        }

        public abstract void HandleComplaint(ComplaintRequest request);
    }
}
