using BotFactory.Common.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotFactory.Interface;
using BotFactory.Models;

namespace BotFactory.Factories
{
    public class FactoryQueueElement : IFactoryQueueElement
    {

        /// <summary>
        /// Le nom du robot
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Le modèle de robot
        /// </summary>
        public Type Model { get; set; }

        /// <summary>
        /// Les coordonées de stationement du robot
        /// </summary>
        public Coordinates ParkingPos { get; set; }

        /// <summary>
        /// Les coordonées de travail du robot
        /// </summary>
        public Coordinates WorkingPos { get; set; }

        /// <summary>
        /// Constructeur d'une file d'attente de construction de robot dans une usine
        /// </summary>
        /// <param name="modeleName">Type de modele</param>
        /// <param name="unitName">Nom du robot</param>
        /// <param name="parkingPos">Coordonées de stationement</param>
        /// <param name="workingPos">Coordonées de travail</param>
        public FactoryQueueElement(Type modeleName, string unitName, Coordinates parkingPos, Coordinates workingPos)
        {
            Model = modeleName;
            Name = unitName;
            ParkingPos = parkingPos;
            WorkingPos = workingPos;    
        }
  

    }
}
