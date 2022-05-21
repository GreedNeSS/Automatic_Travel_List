using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automatic_Sheet_DAL;

namespace Automatic_Sheet_BL
{
    public interface IPriceListGenerator
    {
        string GetPriceListString(List<TripEntity> priceList, int ticketPrice);
        List<string> GetPriceList(List<TripEntity> priceList, int ticketPrice);
    }
}
