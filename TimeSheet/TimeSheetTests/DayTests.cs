using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeSheet;

namespace TimeSheetTests
{
    [TestClass]
    public class TestDay
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
        public void RecordTime_Allows_Regular_Catagory_Time_Entries()
        {
            //Arrange
            var expected = new TimeEntry()
            {
                Type = TimeEntryTypes.REGULAR
            };
            //ACT
            var id = _classUnderTest.RecordTime(TimeEntryTypes.REGULAR, 4, HourIncrement.Half);
            var actual = _classUnderTest.GetTimeEntry(id);
            //Assert
            Assert.AreEqual(expected.Type, actual.Type, "Time Entry Types Don't Match");
        }

        [TestMethod]
        public void RecordTime_Allows_Sick_Catagory_Time_Entries()
        {
            //Arrange
            var expected = new TimeEntry()
            {
                Type = TimeEntryTypes.SICK
            };
            //ACT
            var id = _classUnderTest.RecordTime(TimeEntryTypes.SICK, 4, HourIncrement.Half);
            var actual = _classUnderTest.GetTimeEntry(id);
            //Assert
            Assert.AreEqual(expected.Type, actual.Type, "Time Entry Types Don't Match");
        }

        [TestMethod]
        public void RecordTime_Allows_Vacation_Catagory_Time_Entries()
        {
            //Arrange
            var expected = new TimeEntry()
            {
                Type = TimeEntryTypes.VACATION
            };
            //ACT
            var id = _classUnderTest.RecordTime(TimeEntryTypes.VACATION, 4, HourIncrement.Half);
            var actual = _classUnderTest.GetTimeEntry(id);
            //Assert
            Assert.AreEqual(expected.Type, actual.Type, "Time Entry Types Don't Match");
        }

        [TestMethod]
        public void RecordTime_Hours_Returns_Negative_Value_When_Total_Hours_Grater_Than_24()
        {
            //Arragnge
            int expected = -1;
            int hours = 24;

            //Act
            int actual = _classUnderTest.RecordTime(TimeEntryTypes.VACATION, hours, HourIncrement.Quarter);

            //Assert
            Assert.AreEqual(expected, actual, "Expected Time ID To Be Negative");
        }

        //[TestMethod]
        //public void TestDayRegular()
        //{
        //    /*
        //     * 
        //     */

        //    //arrange
        //    Day d = new Day(new DateTime(2016, 5, 28));

        //    //act
        //    d.Add(Day.type.REGULAR, 8);

        //    //assert
        //    Assert.IsTrue(d.Validate());
        //}

        //[TestMethod]
        //public void TestDaySick()
        //{
        //    //arrange
        //    Day d = new Day(new DateTime(2016, 5, 28));

        //    //act
        //    d.Add(Day.type.SICK, 24);

        //    //assert
        //    Assert.IsTrue(d.Validate());
        //}

        //[TestMethod]
        //public void TestDayOver25()
        //{
        //    //arrange
        //    Day d = new Day(new DateTime(2016, 6, 28));

        //    //act
        //    d.Add(Day.type.REGULAR, 21);
        //    d.Add(Day.type.SICK, 5);

        //    //assert
        //    Assert.IsFalse(d.Validate());
        //}


        //[TestMethod]
        //public void TestBelow0()
        //{
        //    //arrange
        //    Day d = new Day(new DateTime(2016, 6, 28));

        //    //act
        //    try
        //    {
        //        d.Add(Day.type.REGULAR, -1);
        //    }
        //    catch (ArgumentOutOfRangeException e)
        //    {
        //        Assert.IsInstanceOfType(e, typeof(ArgumentOutOfRangeException));
        //    }

        //    //assert
        //    Assert.IsTrue(d.Validate());
        //}

        //[TestMethod]
        //public void Test0()
        //{
        //    //arrange
        //    Day d = new Day(new DateTime(2016, 6, 28));

        //    //act
        //    d.Add(Day.type.REGULAR, 0);

        //    //assert
        //    Assert.IsTrue(d.Validate());
        //}
    }
}
