using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatic_Sheet_BL
{
    public interface IDateGenerator
    {
        List<string> CreateTravelDates(DateTime date);
        List<string> CreateTravelList(int rowCount);
        string GetDateListString(List<string> travelDateList);
        void DateValidation(int month, List<int>? vacation = null);
    }
}
