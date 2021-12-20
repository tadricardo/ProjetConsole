using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.DesignPatterns.Comportement.Memento
{
    public class EditeurState
    {
        public string Content { get; set; }

        public EditeurState(string content)
        {
            Content = content;
        }
    }
}
