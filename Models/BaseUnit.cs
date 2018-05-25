using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotFactory.Common.Tools;
using BotFactory.Interface;

namespace BotFactory.Models
{

 
    public abstract class BaseUnit : ReportingUnit , IBaseUnit
    {

        /// <summary>
        /// Vitesse par défault du robot 1/secondes
        /// </summary>
        private const int _speedDefault = 1;
    
        /// <summary>
        /// Nom par défault du robot "No One"
        /// </summary>
        private const string _defaultName = "No One";

        /// <summary>
        /// Le nom du robot
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// La vitesse du robot
        /// </summary>
        public double Speed { get; set; } 

        /// <summary>
        /// Les coordonées courantes du robot
        /// </summary>
        public Coordinates CurrentPos { get; set; } 

        /// <summary>
        /// Constructeur BaseUnit par défaut
        /// </summary>
        public BaseUnit()
        {
            Name = _defaultName;
            Speed = _speedDefault;
            CurrentPos  = new Coordinates(0, 0);
             
        }

        /// <summary>
        /// Constructeur BaseUnit
        /// </summary>
        /// <param name="name">Le nom du robot</param>
        /// <param name="speed">La vitesse du robot</param>
        public BaseUnit(string name, int speed)
        {
            Name = name;
            Speed = speed;
            CurrentPos = new Coordinates(0, 0);
        }

        /// <summary>
        /// Déplacement d'un robot depuis ces coordonées courantes
        /// </summary>
        /// <param name="x">Nouvelle coordonée X</param>
        /// <param name="y">Nouvelle coordonée Y</param>
        /// <returns></returns>
        public virtual async Task<bool> Move(double x, double y)
        {

            Coordinates newPos = new Coordinates(x, y);

            Vector vectorMove = Vector.FromCoordinates(CurrentPos, newPos);

            double lengthVector = vectorMove.Length();

            double travelTime = lengthVector / Speed;

            await Task.Delay(Convert.ToInt32(Math.Ceiling(travelTime)) * 1000);

            CurrentPos = newPos;

            return true;
        }


    }
}
