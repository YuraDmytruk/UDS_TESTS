using System;
using System.Linq;

namespace CSharpTest
{ 
    public class WorkDayCalculator : IWorkDayCalculator
    {
        public DateTime Calculate(DateTime startDate, int dayCount, WeekEnd[] weekEnds)
        {
            DateTime endDate = startDate.AddDays(dayCount - 1);

            if (weekEnds != null)
            {
                foreach (WeekEnd weekEnd in weekEnds)
                {
                    if(weekEnd.StartDate <= endDate && weekEnd.EndDate >= startDate)
                    {
                        if(weekEnd.StartDate < startDate)
                        {
                           endDate = endDate.AddDays((weekEnd.EndDate - startDate).Days + 1);
                        }
                        else
                        {
                            endDate = endDate.AddDays((weekEnd.EndDate - weekEnd.StartDate).Days + 1);
                        }
                    }
                }
            }

            return endDate;
        }
    }
}
