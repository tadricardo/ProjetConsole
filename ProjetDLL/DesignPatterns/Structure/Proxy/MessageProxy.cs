using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.DesignPatterns.Structure.Proxy
{
    public class MessageProxy : IMessage
    {

        private IMessage proxifiedMessage;

        public MessageProxy(IMessage proxifiedMessage)
        {
            this.proxifiedMessage = proxifiedMessage;
        }



        //Cette classe joue le rôle d'un proxy - intercepte le message original - effectuer des traitements dessus - transmet le 
        //message au destinataire final
        public string GetContent()
        {
            string initialContent = proxifiedMessage.GetContent();

            //Appliquer des traitements sur le message original
            string finalMessage = initialContent.ToUpper();

            return finalMessage;
        }
    }
}
