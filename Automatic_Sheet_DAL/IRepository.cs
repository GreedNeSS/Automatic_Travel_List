﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatic_Sheet_DAL
{
    internal interface IRepository
    {
        TripEntity GetRandomUniqTrip(int vehicleCount);
    }
}
