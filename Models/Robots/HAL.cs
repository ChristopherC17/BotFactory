using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotFactory.Interface;

namespace BotFactory.Models
{
    public class HAL : WorkingUnit , ITestingUnit 
    {
        /// <summary>
        /// Modèle du robot "T800"
        /// </summary>
        private const string _modelName = "HAL";

        /// <summary>
        /// Vitesse d'un robot T800 par défaut 2coordonée/secondes
        /// </summary>
        private const double _speedDefault = 0.5;

        /// <summary>
        /// Temps de construction d'un robot T800 par défaut 4 secondes
        /// </summary>
        private const double _buildTimeDefault = 7;


        /// <summary>
        /// Constructeur d'un robot HAL
        /// </summary>
        public HAL()
        {
            Name = _modelName;
            Speed = _speedDefault;
            BuildTime = _buildTimeDefault;
        }
    }
}
