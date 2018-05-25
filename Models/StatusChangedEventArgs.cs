using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotFactory.Interface;

namespace BotFactory.Models
{
    public class StatusChangedEventArgs : EventArgs , IStatusChangedEventArgs
    {

        /// <summary>
        /// Statut du robot
        /// </summary>
        public string NewStatus { get; set; }

        /// <summary>
        /// Mise à jours du statuts
        /// </summary>
        /// <param name="ch">La chaine à afficher</param>
        public StatusChangedEventArgs(string ch)
        {
            NewStatus = ch;
        }

    }
}
