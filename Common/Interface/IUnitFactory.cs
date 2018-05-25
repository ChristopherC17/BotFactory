using BotFactory.Common.Tools;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFactory.Interface
{
    public interface IUnitFactory 
    {
        void AddWorkableUnitToQueue(Type modeleName, string unitName, Coordinates parkingPos, Coordinates workingPos);

        int QueueCapacity { get; }

        int StorageCapacity { get;}

        List<IFactoryQueueElement> Queue { get;  }

        List<ITestingUnit> Storage { get;  }

        event EventHandler FactoryProgress;

        int QueueFreeSlots { get;  }

         int StorageFreeSlots { get;  }

        TimeSpan QueueTime { get; set; }

    }
}
