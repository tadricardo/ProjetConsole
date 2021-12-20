using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Web.Script.Serialization;

namespace MonProjet
{
   public  class Program
    {
        static void Main(string[] args)
        {
            //JavaScriptSerializer ser= new JavaScriptSerializer();
            CompteBancaire cb = new CompteBancaire(000001,  2000);
            CompteBancaire cb1 = new CompteBancaire(000002,  200);
            CompteBancaire cb2 = new CompteBancaire(000003,  250);
     

            Console.ReadLine();
        }
    }

    class CompteBancaire
    {
        public int Id { get; set; }
        public double Solde { get; set; }

        public CompteBancaire(int id, double solde)
        {
            Id = id;
            Solde = solde;
        }
       
        
    }
}
