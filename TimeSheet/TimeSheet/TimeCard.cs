using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet;

namespace TimeSheet
{
    public class TimeCardSummary
    {
        public float RegularHours { get; set; }
        public float SickHours { get; set; }
        public float VacationHours { get; set; }
    }

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

        public IEnumerable<Day>  WeekOne
        {
            get
            {
                return _days.Take(7);
            }
        }

        public IEnumerable<Day> WeekTwo
        {
            get
            {
                return _days.Skip(7).Take(7);
            }
        }

        public float GetOverTimeWeekOne()
        {
            var weekOne = WeekOne;
            var OvertimeHours = 0f;


            var totalWeekOneRegularHours = weekOne.Sum(
                d => d.AllEntries.Where(e => e.Type == TimeEntryTypes.REGULAR).Sum(e => e.Hours)
            );
            OvertimeHours += (totalWeekOneRegularHours % 40);
            return OvertimeHours;
        }


        public float GetOverTimeWeekTwo()
        {
            var weekTwo = WeekTwo;
            var OvertimeHours = 0f;
          

            var totalWeekTwoRegularHours = weekTwo.Sum(
                d => d.AllEntries.Where(e => e.Type == TimeEntryTypes.REGULAR).Sum(e => e.Hours)
            );
            OvertimeHours += (totalWeekTwoRegularHours % 40);
            return OvertimeHours ;
        }

        public TimeCardSummary GetTimeCardSummary()
        {
            return new TimeCardSummary
            {
                RegularHours = _days.Sum(d => d.AllEntries.Where(e => e.Type == TimeEntryTypes.REGULAR).Sum(e => e.Hours)),
                SickHours = _days.Sum(d => d.AllEntries.Where(e => e.Type == TimeEntryTypes.SICK).Sum(e => e.Hours)),
                VacationHours = _days.Sum(d => d.AllEntries.Where(e => e.Type == TimeEntryTypes.VACATION).Sum(e => e.Hours))
            };
        }
    }
}
