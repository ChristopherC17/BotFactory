using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotFactory.Common.Tools;
using BotFactory.Interface;

namespace BotFactory.Models
{
    public class WorkingUnit : BaseUnit , IWorkingUnit
    {

        /// <summary>
        /// Position de stationement du robot
        /// </summary>
        public Coordinates ParkingPos { get; set; }

        /// <summary>
        /// Position de travail du robot
        /// </summary>
        public Coordinates WorkingPos { get; set; }

        /// <summary>
        /// Booleen permettant de vérifier si le robot est en train de travailler
        /// </summary>
        public bool IsWorking { get; set; }

        /// <summary>
        /// Déplacement du robot vers sa position de travail
        /// </summary>
        /// <returns>
        ///     true : si la position a été atteinte
        ///     sinon false
        /// </returns>
        public virtual async Task<bool> WorkBegins()
        {
            OnStatusChanged(new StatusChangedEventArgs("Move Parking Position => Working Position"));
            await Move(WorkingPos.X, WorkingPos.Y);
            
            if (CurrentPos.Equals(WorkingPos))
            {
                IsWorking = true;
                OnStatusChanged(new StatusChangedEventArgs("Work Position"));
                return true;
            }        
            else
            {
                return false;
            }
                
        }

        /// <summary>
        /// Déplacement du robot vers sa position de stationnement
        /// </summary>
        /// <returns>
        ///     true : si la position a été atteinte
        ///     sinon false
        /// </returns>
        public virtual async Task<bool> WorkEnds()
        {
            OnStatusChanged(new StatusChangedEventArgs("Move Parking Position => Working Position"));
            await Move(ParkingPos.X, ParkingPos.Y);
            IsWorking = false;
            if (CurrentPos.Equals(ParkingPos))
            {
                OnStatusChanged(new StatusChangedEventArgs("Park Position"));
                return true;
            }
            else
            {
                return false;
            }
                
        }



    }
}