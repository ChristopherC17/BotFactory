using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BotFactory.Common.Tools
{
    public class Coordinates
    {

        /// <summary>
        /// Coordonnée axe X
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Coordonée axe Y
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// Constructeur de coordonnée
        /// </summary>
        /// <param name="x">Coordonée en X</param>
        /// <param name="y">Coordonnée en Y</param>
        public Coordinates(double x, double y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Vérifie l'égalité entre deux coordonées
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Coordinates compare = (Coordinates)obj;

            if (X == compare.X && Y == compare.Y)
                return true;
            else
                return false;
        }


        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}