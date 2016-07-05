using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet
{
    //TODO: Handle Editing Hours
    public enum TimeEntryTypes { SICK, VACATION, REGULAR }
    public struct TimeEntry
    {
      public TimeEntryTypes Type;

        public float Hours { get;  set; }
    }

    public class Day
    {
        //public float TotalHours = 0;
        //public float RegHours = 0;
        //public float SickHours = 0;
        //public float VacHours = 0;
        //public DateTime Date { get; set; }
        //public float HoursWorked { get; set; }
        //public string HoursType { get; set; }
        //public float hours = 8;
        //public type value = type.REGULAR;
        private DateTime _dateTime;
        private List<TimeEntry> _entries;
        private int _index = 0;
        private readonly int HoursPerDay = 24;
        private readonly int InvaildId = -1;
        public Day(DateTime dateTime)
        {
            _entries = new List<TimeEntry>();
            _dateTime = dateTime;
        }

        public TimeEntry GetTimeEntry(int id)
        {
            return _entries[id];
        }

        public int RecordTime(TimeEntryTypes type, int hours, HourIncrement increment)
        {
            var timeEntry = new TimeEntry {
                Type = type,
                Hours = hours + increment.Value
            };
            var sumOfHours = _entries.Sum(x => x.Hours)+timeEntry.Hours;
            if(sumOfHours > HoursPerDay)
            {
                return InvaildId;
            }

            //TODO: Add equality methods to TimeEntry
            _entries.Insert(_index, timeEntry);
            return _index++;
        }

        //public type TypeTest()
        //{
        //    return value;
        //}
        //public float HoursTest()
        //{
        //    return hours;
        //}

        //public void Add(type TypeChoice, float hours)
        //{
        //    if (hours > 0)
        //    {
        //        TotalHours += hours;
        //        if (TypeChoice == type.REGULAR)
        //        {
        //            RegHours += hours;
        //        }
        //        else if (TypeChoice == type.SICK)
        //        {
        //            SickHours += hours;
        //        }
        //        else if (TypeChoice == type.VACATION)
        //        {
        //            VacHours += hours;
        //        }
        //    }
        //    else
        //    {
        //        throw new ArgumentOutOfRangeException("hours", "Hours must be > Zero");
        //    }
        //}
        //public bool Validate()
        //{
        //    if (TotalHours <= 24 && TotalHours > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
    }
}
