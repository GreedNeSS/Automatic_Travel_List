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
        public string GetPriceListString(List<TripEntity> tripList, int ticketPrice)
        {
            string priceListString = string.Empty;

            tripList.ForEach(trip =>
            {
                priceListString += (ticketPrice * trip.VehicleCount).ToString() + "\n";
                priceListString += (ticketPrice * trip.VehicleCount).ToString() + "\n";
            });

            return priceListString;
        }
        public List<string> GetPriceList(List<TripEntity> tripList, int ticketPrice)
        {
            List<string> priceList = new List<string>();

            tripList.ForEach(trip =>
            {
                priceList.Add((ticketPrice * trip.VehicleCount).ToString());
                priceList.Add((ticketPrice * trip.VehicleCount).ToString());
            });

            return priceList;
        }
    }
}
