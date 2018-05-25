using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotFactory.Interface;
using BotFactory.Common.Tools;
using BotFactory.Models;
using System.Threading;
using System.Windows;

namespace BotFactory.Factories
{
    public class UnitFactory : ReportingFactory, IUnitFactory
    {

        /// <summary>
        /// Objet permettant de verrouiller la création d'un robot à une seule unité
        /// </summary>
        static readonly object _lockBuildingUnit = new object();

        /// <summary>
        /// Le nombre de place disponnible dans la file d'attente
        /// </summary>
        public int QueueFreeSlots { get { return QueueCapacity - _queue.Count(); } }

        /// <summary>
        /// Le nombre de place disponnible dans l'entrepot
        /// </summary>
        public int StorageFreeSlots { get { return StorageCapacity - _storage.Count(); } }

        /// <summary>
        /// Le nombre de robot maximum dans la file d'attente
        /// </summary>
        public int QueueCapacity { get; }

        /// <summary>
        /// Le nombre de robot maximum dans l'entrepot
        /// </summary>
        public int StorageCapacity { get;  }

        /// <summary>
        /// La durée de la file d'attente
        /// </summary>
        public TimeSpan QueueTime { get; set; }

        private Queue<IFactoryQueueElement> _queue;

        /// <summary>
        /// La liste des robots dans la file d'attente
        /// </summary>
        public Queue<IFactoryQueueElement> Queue {
            get
            {
                return _queue;
            }
        }

        private List<ITestingUnit> _storage;

        /// <summary>
        /// La liste des robots dans l'entrepot
        /// </summary>
        public List<ITestingUnit> Storage
        {
            get
            {
                return _storage.ToList();
            }
        }

        /// <summary>
        /// Constructeur d'une usine
        /// </summary>
        /// <param name="queueCapacity">Le nombre maximum de robot dans la file d'attente</param>
        /// <param name="storageCapacity">Le nombre maximum de robot dans l'entrepot</param>
        public UnitFactory(int queueCapacity, int storageCapacity)
        {
            QueueCapacity = queueCapacity;
            StorageCapacity = storageCapacity;
            _storage = new List<ITestingUnit>();
            _queue = new Queue<IFactoryQueueElement>();
        }

        /// <summary>
        /// On ajoute une nouveau robot dans la file d'attente
        /// </summary>
        /// <param name="modeleName">Le modèle du robot à ajouter</param>
        /// <param name="unitName">Le nom du robot</param>
        /// <param name="parkingPos">La position de station du robot</param>
        /// <param name="workingPos">La position de travail du robot</param>
        public void AddWorkableUnitToQueue(Type modeleName, string unitName, Coordinates parkingPos, Coordinates workingPos)
        {
            // On vérifie si il reste de la place dans la file d'attente et dans l'entrepot
            if ((_queue.Count() < QueueCapacity) && (_storage.Count() + _queue.Count  < StorageCapacity ))
            {

                // On ajoute un élément dans la file d'attente
                FactoryQueueElement queueElement = new FactoryQueueElement(modeleName, unitName, parkingPos, workingPos);
                _queue.Enqueue(queueElement);



                //On ajoute du temps dans la file d'attente
                ITestingUnit recupTime = Activator.CreateInstance(queueElement.Model, new object[] { }) as ITestingUnit;
                QueueTime = QueueTime.Add(new TimeSpan(0,0,Convert.ToInt32(recupTime.BuildTime)));

                //Création d'un thread permettant de construire un robot (un seul robot est créé à la fois)
                Thread threadBuildUnit = new Thread(() =>
                {
                    lock (_lockBuildingUnit)
                    {

                        FactoryQueueElement nextQueueElement = (FactoryQueueElement)_queue.Peek();
                        // On récupére par reflexion les informations sur un robot
                        ITestingUnit newUnit = Activator.CreateInstance(nextQueueElement.Model, new object[] { }) as ITestingUnit;
                        newUnit.Model = nextQueueElement.Name;
                        newUnit.ParkingPos = nextQueueElement.ParkingPos;
                        newUnit.WorkingPos = nextQueueElement.WorkingPos;
                        BuildingUnit(newUnit);
                    }
                });

               threadBuildUnit.Start();

            }
            else
            {
                if(_queue.Count() >= QueueCapacity)
                {
                    MessageBox.Show("Max unit in queue");
                }
                else
                {
                    MessageBox.Show("Max unit in factory");
                }
                
            }

        }

        /// <summary>
        /// Construction d'un robot
        /// </summary>
        /// <param name="newUnit">Le robot à construire</param>
        private void BuildingUnit(ITestingUnit newUnit)
        {
            OnStatusChangedFactory(new StatusChangedEventArgs(string.Format("Start build unit {0} : {1}", newUnit.Model, newUnit.Name)));
            Thread.Sleep(Convert.ToInt32(newUnit.BuildTime) * 1000);
            _storage.Add(newUnit);
            _queue.Dequeue();
            QueueTime = QueueTime.Add(new TimeSpan(0, 0, Convert.ToInt32(-newUnit.BuildTime)));
            OnStatusChangedFactory(new StatusChangedEventArgs(string.Format("End build unit {0} : {1}", newUnit.Model, newUnit.Name)));
        }

      
    }
}
