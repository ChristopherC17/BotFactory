using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotFactory.Interface;

namespace BotFactory.Models
{

    public abstract class BuildableUnit :   IBuildableUnit
    {

        /// <summary>
        /// Temps de construction par défault d'un robot
        /// </summary>
        private const int _buildTimeDefault = 5;

        /// <summary>
        /// Le temps de construction du robot
        /// </summary>
        public double BuildTime { get; set; }

        /// <summary>
        /// Le nom du modèle du robot
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Constructeur BuildableUnit par défaut avec un temps de construction du robot à 5 secondes
        /// </summary>
        public BuildableUnit()
        {
            BuildTime = _buildTimeDefault;
        }

        /// <summary>
        /// Constructeur BuildableUnit
        /// </summary>
        /// <param name="buildTime">Le temps de construction du robot</param>
        public BuildableUnit(double buildTime)
        {
            BuildTime = buildTime;
        }

    }
}
