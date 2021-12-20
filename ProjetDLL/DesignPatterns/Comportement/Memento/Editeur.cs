using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.DesignPatterns.Comportement.Memento
{
    public class Editeur
    {
        public string Content { get; set; }

        public EditeurState CreateState()
        {
            return new EditeurState(Content);
        }

        public void Restore(EditeurState state)
        {
            Content = state.Content;
        }
    }
}
