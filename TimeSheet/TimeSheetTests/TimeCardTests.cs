using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeSheet;
using System.Linq;

namespace TimeSheetTests
{
    [TestClass]
    public class TimeCardTests
    {   
        private TimeCard _classUnderTest;

        [TestInitialize]
        public void SetUp()
        {
            var startDate = new DateTime(2016, 7, 3);
            var endDate = new DateTime(2016, 7, 19);
            _classUnderTest = new TimeCard(startDate, endDate);
           
        }

        [TestCleanup]
        public void CleanUp()
        {
            
        }

        [TestMethod]
        public void Init_Creates_Two_Week_Of_Consecutive_Days()
        {
            var expected = 13;

            //ACT
            var startDay = _classUnderTest.GetStartDay();
            var lastDay = _classUnderTest.GetLastDay();
            var actual =    (lastDay.GetDaysDate() - startDay.GetDaysDate()).Days;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Init_Check_Sunday_Is_Start_Of_Pay_Period()
        {
            //Arrange
            var startDay = (_classUnderTest.GetStartDay()).GetDaysDate().DayOfWeek;
            //var dayDate = (startDay.GetDaysDate()).DayOfWeek;

            //Act
            var sunday = DayOfWeek.Sunday;

            //Assert
            Assert.AreEqual(sunday, startDay, "Pay Period Doesn't Start On A Sunday");
        }

        [TestMethod]
        public void Get_Over_Time_Hours_For_Week_One_Period()
        {
            //Arrange
            var weekOne = _classUnderTest.WeekOne;
            var expected = 37;
            foreach (Day x in weekOne)
            {
                x.RecordTime(TimeEntryTypes.REGULAR, 11, HourIncrement.Zero);
            }
            //Act
            var actual = _classUnderTest.GetOverTimeWeekOne();
            //Assert
            Assert.AreEqual(expected, actual, "Over Time Hours Don't Match");
        }

        [TestMethod]
        public void Get_Over_Time_Hours_For_Week_Two_Period()
        {
            //Arrange
            var weekTwo = _classUnderTest.WeekTwo;
            var expected = 37;
            foreach (Day x in weekTwo)
            {
                x.RecordTime(TimeEntryTypes.REGULAR, 11, HourIncrement.Zero);
            }
            //Act
            var actual = _classUnderTest.GetOverTimeWeekTwo();
            
            //Assert
            Assert.AreEqual(expected, actual, "Over Time Hours Don't Match");
        }

        [TestMethod]
        public void GetTimeCardSummary()
        {
            //Arrange
            var payPeriod = _classUnderTest.GetDays();
            var expected = new TimeCardSummary
                {
                RegularHours = 10 * 14,
                SickHours = 1.5f * 14,
                VacationHours = 1.75f * 14
                };
            //Act
            foreach (Day x in payPeriod)
            {
                x.RecordTime(TimeEntryTypes.REGULAR, 10, HourIncrement.Zero);
                x.RecordTime(TimeEntryTypes.SICK, 1, HourIncrement.Half);
                x.RecordTime(TimeEntryTypes.VACATION, 1, HourIncrement.ThreeQuarters);
            }
            var actual = _classUnderTest.GetTimeCardSummary();
            //Assert
            Assert.AreEqual(expected.RegularHours, actual.RegularHours, "Regular Hours Don't Match ");
            Assert.AreEqual(expected.SickHours, actual.SickHours, "Sick Hours Dont't Match");
            Assert.AreEqual(expected.VacationHours, actual.VacationHours, "VacationHours Don't Match");
        }

    }
}
