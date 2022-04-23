using System;
using System.Collections.Generic;
using System.Globalization;

namespace CountWorkingDays
{
    internal class Program
    {
        static void Main()
        {
            var inputStartDate = Console.ReadLine();
            var inputEndDate = Console.ReadLine();

            var startDate = DateTime.ParseExact(inputStartDate, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            var endDate = DateTime.ParseExact(inputEndDate, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            List<DateTime> holidays = AddHolidays();

            var workingDays = 0;
            for (DateTime currentDate = startDate; currentDate <= endDate; currentDate = currentDate.AddDays(1))
            {
                var newDate = new DateTime(2016, currentDate.Month, currentDate.Day);
                if (!holidays.Contains(newDate)
                    && currentDate.DayOfWeek != DayOfWeek.Saturday
                    && currentDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    workingDays++;
                }
            }
            Console.WriteLine(workingDays);
        }

        private static List<DateTime> AddHolidays()
        {
            var holidays = new List<DateTime>();
            holidays.Add(DateTime.ParseExact("01-01-2016", "dd-MM-yyyy", CultureInfo.InvariantCulture));
            holidays.Add(DateTime.ParseExact("03-03-2016", "dd-MM-yyyy", CultureInfo.InvariantCulture));
            holidays.Add(DateTime.ParseExact("01-05-2016", "dd-MM-yyyy", CultureInfo.InvariantCulture));
            holidays.Add(DateTime.ParseExact("06-05-2016", "dd-MM-yyyy", CultureInfo.InvariantCulture));
            holidays.Add(DateTime.ParseExact("24-05-2016", "dd-MM-yyyy", CultureInfo.InvariantCulture));
            holidays.Add(DateTime.ParseExact("06-09-2016", "dd-MM-yyyy", CultureInfo.InvariantCulture));
            holidays.Add(DateTime.ParseExact("22-09-2016", "dd-MM-yyyy", CultureInfo.InvariantCulture));
            holidays.Add(DateTime.ParseExact("01-11-2016", "dd-MM-yyyy", CultureInfo.InvariantCulture));
            holidays.Add(DateTime.ParseExact("24-12-2016", "dd-MM-yyyy", CultureInfo.InvariantCulture));
            holidays.Add(DateTime.ParseExact("25-12-2016", "dd-MM-yyyy", CultureInfo.InvariantCulture));
            holidays.Add(DateTime.ParseExact("26-12-2016", "dd-MM-yyyy", CultureInfo.InvariantCulture));
            return holidays;
        }
    }
}
