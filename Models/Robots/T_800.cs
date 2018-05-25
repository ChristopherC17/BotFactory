using BotFactory.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFactory.Models
{
    public class T_800 : WorkingUnit, ITestingUnit 
    {
        /// <summary>
        /// Modèle du robot "T800"
        /// </summary>
        private const string _modelName = "T_800";

        /// <summary>
        /// Vitesse d'un robot T800 par défaut 2coordonée/secondes
        /// </summary>
        private const double _speedDefault = 3;

        /// <summary>
        /// Temps de construction d'un robot T800 par défaut 4 secondes
        /// </summary>
        private const double _buildTimeDefault = 10;


        /// <summary>
        /// Constructeur d'un robot T800
        /// </summary>
        public T_800()
        {
            Name = _modelName;
            Speed = _speedDefault;
            BuildTime = _buildTimeDefault;
        }
    }
}
