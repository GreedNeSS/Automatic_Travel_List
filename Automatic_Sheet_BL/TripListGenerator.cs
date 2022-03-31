using Automatic_Sheet_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatic_Sheet_BL
{
    public class TripListGenerator : ITripListGenerator
    {
        private TripEntity GetTrip(int vehicleCount, IRepository repository)
        {
            return repository.GetRandomUniqTrip(vehicleCount);
        }

        public string GetTripsString(List<TripEntity> trips)
        {
            return string.Join("\n", trips);
        }

        private void ValidateInitData(int rowCount, int ticketCount)
        {
            if (ticketCount < rowCount)
            {
                throw new Exception("Недостаточно билетов для такого количества строк!");
            }

            if (ticketCount / 2 > rowCount)
            {
                throw new Exception("Слишком много билетов для такого количества строк!");
            }

            if (ticketCount % 2 == 0)
            {
                throw new Exception("Количество биллетов должно быть чётным!");
            }
        }

        public List<TripEntity> GetTripList(int rowCount, int ticketCount, IRepository repository)
        {
            List<TripEntity> tripEntities = new List<TripEntity>();
            ValidateInitData(rowCount, ticketCount);
            int usedTicketCount = 0;
            Random random = new Random();

            while (rowCount <= usedTicketCount)
            {
                tripEntities.Add(GetTrip(1, repository));
                usedTicketCount += 2;
            }

            while (usedTicketCount < ticketCount)
            {
                while (true)
                {
                    int i = random.Next(rowCount);
                    if (tripEntities[i].VehicleCount == 1)
                    {
                        tripEntities[i] = GetTrip(2, repository);
                        break;
                    }
                }
                usedTicketCount += 2;
            }

            return tripEntities;
        }

        public IRepository GetRepository()
        {
            IRepository repository = new Repository();
            return repository;
        }
    }
}
