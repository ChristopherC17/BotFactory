using BotFactory.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFactory.Models
{
    public class Wall_E : WorkingUnit, ITestingUnit 
    {

        /// <summary>
        /// Modèle du robot "WallE"
        /// </summary>
        private const string _modelName = "Wall_E";

        /// <summary>
        /// Vitesse d'un robot Wall E par défaut 2coordonée/secondes
        /// </summary>
        private const double _speedDefault = 2;

        /// <summary>
        /// Temps de construction d'un robot Wall E par défaut 4 secondes
        /// </summary>
        private const double _buildTimeDefault = 4;


        /// <summary>
        /// Constructeur d'un robot Wall E
        /// </summary>
        public Wall_E()
        {
            Name = "Wall_E";
            Speed = _speedDefault;
            BuildTime = _buildTimeDefault;
        }
    }
}
