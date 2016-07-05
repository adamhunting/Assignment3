using System.Collections.Generic;

namespace TimeSheet
{
    public class HourIncrement
    {
        private float _value;
        public static HourIncrement Zero = new HourIncrement(0f);
        public static HourIncrement Quarter = new HourIncrement(.25f);
        public static HourIncrement Half = new HourIncrement(.50f);
        public static HourIncrement ThreeQuarters = new HourIncrement(.75f);

        public static List<HourIncrement> Options { get; }
        public float Value { get { return _value; } }

        private HourIncrement( HourIncrement increment)
        {
            Options.Add(increment);
        }
        private HourIncrement( float value)
        {
            _value = value;
        }
    }
}