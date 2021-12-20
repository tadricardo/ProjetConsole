using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.DesignPatterns.Creation.Factory
{
    public class ShapeFactory
    {
        //Rôle: construction d'objets de type formes géométriques
        //Ne respecte le principe Open/Close

        public static IShape CreateShape(string shapeType)
        {
            if (shapeType == null)
            {
                return null;
            }
            switch (shapeType)
            {
                case "Rectangle":
                    return new Rectangle();
                case "Circle":
                    return new Circle();
                default:
                    break;
            }
            return null;
        }

        //Solution: mise en place du polymorphisme en utilisant la généricité

        public static T CreateShape<T>(Type type, params object[] parametres) where T : IShape
        {
            return (T)Activator.CreateInstance(type, parametres);
        }
    }
}
