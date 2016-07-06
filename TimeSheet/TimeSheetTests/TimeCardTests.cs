using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeSheet;

namespace TimeSheetTests
{
    [TestClass]
    public class TimeCardTests
    {
        private Day _classUnderTest;

        [TestInitialize]
        public void SetUp()
        {
            var date = new DateTime(2016, 7, 4);
            _classUnderTest = new Day(date);
            
        }

        [TestCleanup]
        public void CleanUp()
        {
            
        }

        [TestMethod]
        public void Init_Creates_Two_Week_Of_Consecutive_Days()
        {
            //Arrange
            DateTime s = new DateTime(2016, 1, 1);
            DateTime e = new DateTime(2016, 1, 14);
            TimeCard t = new TimeCard(s,e);
            var expected = 13;

            //ACT
            var startDay = t.GetStartDay();
            var lastDay = t.GetLastDay();
            var actual =    (lastDay.GetDaysDate() - startDay.GetDaysDate()).Days;
            //Assert
            Assert.AreEqual(expected, actual);
        }


    }
}
