using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatic_Sheet_BL
{
    public class DateGenerator : IDateGenerator
    {
        public List<DateTime> Dates { get; set; } = new List<DateTime>();
        public List<DateTime> UsedDates { get; set; } = new List<DateTime>();

        public DateGenerator(int month, List<int>? vacation = null)
        {
            int year = DateTime.Today.Year;
            DateTime date = new DateTime(year, month, 1);
            DateValidation(month, vacation);

            if (vacation is null)
            {
                Init(date);
            }

            Init(date, vacation);
        }

        private void Init(DateTime initDate, List<int>? vacation = null)
        {
            int year = initDate.Year;
            int month = initDate.Month;
            int daysCount = DateTime.DaysInMonth(year, month);

            for (int day = 1; day <= daysCount; day++)
            {
                if (vacation is not null && vacation.Contains(day))
                {
                    continue;
                }

                DateTime date = new DateTime(year, month, day);

                if (date.DayOfWeek == DayOfWeek.Sunday || date.DayOfWeek == DayOfWeek.Saturday)
                    continue;

                Dates.Add(date);
            }
        }

        public List<string> CreateTravelDates(DateTime date)
        {
            List<string> travelDates = new List<string>();
            travelDates.Add(date.ToString("dd.MM"));
            travelDates.Add(date.ToString("dd.MM"));
            return travelDates;
        }

        public List<string> CreateTravelList(int rowCount)
        {
            List<string> travelList = new List<string>();

            for (int i = 0; i < rowCount/2; i++)
            {
                if (Dates.Count <= 0)
                {
                    Dates.AddRange(UsedDates);
                    UsedDates = new List<DateTime>();
                }

                DateTime day = Dates.First();
                travelList.AddRange(CreateTravelDates(day));
                UsedDates.Add(day);
                Dates.Remove(day);
            }

            return travelList;
        }

        public string GetDateListString(List<string> travelDateList)
        {
            travelDateList.Sort();
            return String.Join("\n", travelDateList.ToArray());
        }

        public void DateValidation(int month, List<int>? vacation = null)
        {
            if (month > 12 || month < 1)
            {
                throw new Exception("Неправильно введен месяц!");
            }

            if (vacation != null)
            {
                int year = DateTime.Today.Year;
                int days = DateTime.DaysInMonth(year, month);

                foreach (int numb in vacation)
                {
                    if (numb > days || numb < 1)
                    {
                        throw new Exception("Неправильно введены числа нерабочих дней!");
                    }
                }
            }
        }
    }
}
