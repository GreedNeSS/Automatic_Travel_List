using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatic_Sheet_BL
{
    public interface IDateGenerator
    {
        DateTime GetTravelDate();
        List<string> CreateTravelDate(DateTime date);
        List<string> CreateTravelDateList(int rowCount, DateTime date);
        string GetDateListString(List<string> travelDateList);
    }
}
