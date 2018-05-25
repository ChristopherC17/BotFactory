using BotFactory.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFactory.Models
{
    public class R2D2 : WorkingUnit, ITestingUnit 
    {
        /// <summary>
        /// Modèle du robot "T800"
        /// </summary>
        private const string _modelName = "R2D2";

        /// <summary>
        /// Vitesse d'un robot T800 par défaut 2coordonée/secondes
        /// </summary>
        private const double _speedDefault = 1.5;

        /// <summary>
        /// Temps de construction d'un robot T800 par défaut 4 secondes
        /// </summary>
        private const double _buildTimeDefault = 5.5;


        /// <summary>
        /// Constructeur d'un robot R2D2
        /// </summary>
        public R2D2()
        {
            Name = _modelName;
            Speed = _speedDefault;
            BuildTime = _buildTimeDefault;
        }
    }
}
