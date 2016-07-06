using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet;

namespace TimeSheet
{
    class TimeCard
    {
        private readonly Day[] _days;

        public TimeCard( )
        {
            _days = new Day[14];
        }
        public Day[] GetDays()
        {
            return _days.ToArray();
        }
    }
}
