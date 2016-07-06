using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet
{
    
    public enum TimeEntryTypes { SICK, VACATION, REGULAR,
        UNDEFINDED
    }
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
        public static readonly TimeEntry DEFAULT = new TimeEntry
        {
            Hours = 0f,
            Type = TimeEntryTypes.UNDEFINDED
        };

        public Day(DateTime dateTime)
        {
            _entries = new List<TimeEntry>();
            _dateTime = dateTime;
        }

        public DateTime GetDaysDate()
        {
            return _dateTime ;
        }

        public TimeEntry GetTimeEntry(int id)
        {
            if(id >= _entries.Count || id < 0) 
            {
                return Day.DEFAULT;
            }
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

        public void UpdateTime(int id, TimeEntryTypes type, int hours, HourIncrement increment)
        {
            var timeEntry = new TimeEntry
            {
                Type = type,
                Hours = hours + increment.Value
            };
            var sumOfHours = _entries.Sum(x => x.Hours) + timeEntry.Hours;
            if (sumOfHours > HoursPerDay)
            {
                //TODO: Make error handling Consitant
                throw new Exception("Hours Exceeded Max For Day");
            }

            //TODO: Add equality methods to TimeEntry
            _entries.RemoveAt(id);
            _entries.Insert(id, timeEntry);
        }

        public void DeleteTime(int id)
        {
            if (id > _index || id < 0)
            {
                return;
            }
            _entries.RemoveAt(id);

        }

        public void DeleteTime(TimeEntryTypes type)
        {
            _entries.RemoveAll(x => x.Type == type);
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
