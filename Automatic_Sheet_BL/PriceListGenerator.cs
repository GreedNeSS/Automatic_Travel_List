using Automatic_Sheet_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatic_Sheet_BL
{
    public class PriceListGenerator : IPriceListGenerator
    {
        public string GetPriceList(List<TripEntity> tripList, int ticketPrice)
        {
            string priceListString = string.Empty;

            tripList.ForEach(trip =>
            {
                priceListString += (ticketPrice * trip.VehicleCount).ToString();
            });

            return priceListString;
        }
    }
}
