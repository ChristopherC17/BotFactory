using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotFactory.Interface;


namespace BotFactory.Models
{
    public abstract class ReportingUnit : BuildableUnit , IReportingUnit
    {
        /// <summary>
        /// Evenement pour gérer le statut du robot
        /// </summary>
        public event EventHandler<IStatusChangedEventArgs> UnitStatusChanged;

        /// <summary>
        /// Construteur du suivi d'un robot
        /// </summary>
        /// <param name="Time">Temps de construction</param>
        public ReportingUnit(double Time) : base(Time) { }

        /// <summary>
        /// Constructeur par défaut du suivi d'un robot
        /// </summary>
        public ReportingUnit() { }

        /// <summary>
        /// Mise à jours du statut du robot
        /// </summary>
        /// <param name="statuts"></param>
        public virtual void OnStatusChanged(StatusChangedEventArgs statuts)
        {
            if (UnitStatusChanged != null)
            {
                UnitStatusChanged(this, statuts);
            }
        }

    }
}
