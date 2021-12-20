using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.DesignPatterns.Comportement.Observer
{
    public interface ISujet
    {
        void Attach(IObserver obs);
        void Detach(IObserver obs);
        void Notify(ISujet sujet);

    }
}
