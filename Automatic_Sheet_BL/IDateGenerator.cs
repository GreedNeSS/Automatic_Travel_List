using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatic_Sheet_BL
{
    public interface IDateGenerator
    {
        DateTime GetWeekday();
        List<string> CreateTravelDates(DateTime date);
        List<string> CreateTravelList(int rowCount, DateTime date);
        string GetDateListString(List<string> travelDateList);
    }
}
