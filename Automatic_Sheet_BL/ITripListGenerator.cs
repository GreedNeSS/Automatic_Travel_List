using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automatic_Sheet_DAL;

namespace Automatic_Sheet_BL
{
    public interface ITripListGenerator
    {
        TripEntity GetTrip(int vehicleCount);
        List<TripEntity> GetTripList(int rowCount, int ticketCount);
        string GetTripsString(List<TripEntity> trips);
    }
}
