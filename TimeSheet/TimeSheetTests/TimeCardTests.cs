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
           // var expeceted = 14;

            //ACT
           // var actual =


            //Assert
        }


    }
}
