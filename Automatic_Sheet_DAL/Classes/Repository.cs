using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatic_Sheet_DAL
{
    public class Repository : IRepository
    {
        private List<TripEntity> NonStopTrips { get; set; } = new List<TripEntity>();
        private List<TripEntity> UsedNonStopTrips { get; set; } = new List<TripEntity>();
        private List<TripEntity> TransferTrips { get; set; } = new List<TripEntity>();
        private List<TripEntity> UsedTransferTrips { get; set; } = new List<TripEntity>();


        public Repository()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                List<TripEntity> tripEntities = db.Trips.ToList();
                foreach (TripEntity tripEntity in tripEntities)
                {
                    if (tripEntity.VehicleCount == 2)
                    {
                        TransferTrips.Add(tripEntity);
                    }
                    else
                    {
                        NonStopTrips.Add(tripEntity);
                    }
                }
            }
        }

        public TripEntity GetRandomUniqTrip(int vehicleCount)
        {
            var random = new Random();
            TripEntity randomTrip;

            if (vehicleCount == 2)
            {
                if (TransferTrips.Count == 0)
                {
                    Reboot(2);
                }

                int i = random.Next(TransferTrips.Count);
                randomTrip = TransferTrips[i];
                TransferTrips.Remove(randomTrip);
                UsedTransferTrips.Add(randomTrip);
            }
            else
            {
                if (NonStopTrips.Count == 0)
                {
                    Reboot(1);
                }

                int i = random.Next(NonStopTrips.Count);
                randomTrip = NonStopTrips[i];
                NonStopTrips.Remove(randomTrip);
                UsedNonStopTrips.Add(randomTrip);
            }

            return randomTrip;
        }

        private void Reboot(int vehicleCount)
        {
            switch (vehicleCount)
            {
                case 2:
                    {
                        TransferTrips.AddRange(UsedTransferTrips);
                        UsedTransferTrips.Clear();
                    }
                    break;
                case 1:
                    {
                        NonStopTrips.AddRange(UsedNonStopTrips);
                        UsedNonStopTrips.Clear();
                    }
                    break;
            }
        }
    }
}
