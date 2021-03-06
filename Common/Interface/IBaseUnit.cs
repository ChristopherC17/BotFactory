﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotFactory.Common.Tools;

namespace BotFactory.Interface
{
    public interface IBaseUnit : IReportingUnit
    {      
         string Name { get; set; }

         double Speed { get; set; }

         Coordinates CurrentPos { get; set; }

         Task<bool> Move(double x, double y);

    }
}
