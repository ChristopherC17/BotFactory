using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFactory.Common.Tools
{
    public class Vector
    {
        public double X { get; set; }

        public double Y { get; set; }

        public static Vector FromCoordinates(Coordinates begin, Coordinates end)
        {
            Vector vecteur = new Vector();
            vecteur.X = end.X - begin.X;
            vecteur.Y = end.Y - begin.Y;
            return vecteur;
        }

        public Vector() {
            X = 0;
            Y = 0;
        }

        public double Length()
        {
            return Math.Sqrt((X * X) + (Y * Y));
        }
    }
}
