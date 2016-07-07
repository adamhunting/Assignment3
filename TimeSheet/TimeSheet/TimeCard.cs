using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet;

namespace TimeSheet
{
    public class TimeCard
    {
        private readonly Day[] _days;

        public TimeCard(DateTime startDate, DateTime endDate )
        {
            DateTime _startDate = startDate;
          _days = new Day[14];
          for (int x =0; x < 14; x++)
            {  
                Day day = new Day(_startDate.AddDays(x));
                _days[x] = day;               
            }
        }
        public Day[] GetDays()
        {
            return _days.ToArray();
        }
        public Day GetStartDay()
        {
            return _days[0];
        }

        public Day GetLastDay()
        {
            return _days[13];
        }
    }
}
