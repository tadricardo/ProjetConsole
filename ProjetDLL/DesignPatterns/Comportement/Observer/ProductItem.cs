using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.DesignPatterns.Comportement.Observer
{
    public class ProductItem : ISujet
    {
        public int Id { get; set; }
        public string Description { get; set; }
        private double _price;

        public double Price
        {
            get { return _price; }
            set { _price = value; Notify(this); }
        }

        public List<IObserver> Observers { get; set; }

        public ProductItem()
        {
            Observers = new List<IObserver>();
        }

        public void Attach(IObserver obs)
        {
            if (!Observers.Contains(obs))
            {
                Observers.Add(obs);

            }
        }

        public void Detach(IObserver obs)
        {
            Observers.Remove(obs);
        }

        public void Notify(ISujet sujet)
        {
            foreach (var obs in Observers)
            {
                obs.Update(sujet);
            }
        }
    }
}
