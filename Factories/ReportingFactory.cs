using System;
using BotFactory.Models;
using BotFactory.Interface;

namespace BotFactory.Factories
{
    public class ReportingFactory : IReportingFactory
    {
        /// <summary>
        /// Evenement pour gérer le statut d'une usine
        /// </summary>
        public event EventHandler FactoryProgress;


        /// <summary>
        /// Mise à jours du statut de l'usine
        /// </summary>
        /// <param name="statuts"></param>
        public virtual void OnStatusChangedFactory(EventArgs statuts)
        {
            if (FactoryProgress != null)
            {
                FactoryProgress(this, statuts);
            }

        }

    }
}

