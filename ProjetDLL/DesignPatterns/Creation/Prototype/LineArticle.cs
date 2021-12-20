using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.DesignPatterns.Creation.Prototype
{
    public class LineArticle : ICloneable
    {
        public Article Article { get; set; }
        public int Qty { get; set; }

        public object Clone()
        {
            //Cette classe contient une propriété complèxe (Article) qu'on doit cloner aussi
            LineArticle line = (LineArticle)this.MemberwiseClone();
            line.Article = (Article)this.Article.Clone();
            return line;
        }

        public override string ToString()
        {
            return "LineArticle: " + Article.ToString() + " Quantité: " + Qty;
        }
    }
}
