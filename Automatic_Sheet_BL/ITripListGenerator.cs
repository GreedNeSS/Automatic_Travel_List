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
        List<TripEntity> GetTripList(int rowCount, int ticketCount, IRepository repository);
        string GetTripsString(List<TripEntity> trips);
    }
}
