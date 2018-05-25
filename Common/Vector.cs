using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFactory.Common.Tools
{
    public class Vector
    {

        /// <summary>
        /// Coordonée X
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Coordonée Y
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// Calcul d'un vecteur
        /// </summary>
        /// <param name="begin">Coordonée de début</param>
        /// <param name="end">Coordonée de fin</param>
        /// <returns></returns>
        public static Vector FromCoordinates(Coordinates begin, Coordinates end)
        {
            Vector vecteur = new Vector();
            vecteur.X = end.X - begin.X;
            vecteur.Y = end.Y - begin.Y;
            return vecteur;
        }

        /// <summary>
        /// Initialisation d'un vecteur
        /// </summary>
        public Vector() {
            X = 0;
            Y = 0;
        }

        /// <summary>
        /// Calcul de la longueur d'un vecteur (formule de Pythagore)
        /// </summary>
        /// <returns></returns>
        public double Length()
        {
            return Math.Sqrt((X * X) + (Y * Y));
        }
    }
}
