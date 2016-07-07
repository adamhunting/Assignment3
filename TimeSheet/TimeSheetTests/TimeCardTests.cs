using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeSheet;

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
            //Arrange
           // DateTime s = new DateTime(2016, 1, 1);
           // DateTime e = new DateTime(2016, 1, 14);
           //TimeCard t = new TimeCard(s,e);
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

    }
}
