using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.DesignPatterns.Structure.Proxy
{
    public class UserMessage : IMessage
    {
        private string content;

        public UserMessage(string content)
        {
            this.content = content;
        }

        public string GetContent()
        {
            return content;
        }
    }
}
