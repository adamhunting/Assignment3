using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeSheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet.Tests
{
    [TestClass()]
    public class EmployeeTests
    {
        [TestMethod()]
        public void TestTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AnotherTestTest()
        {
            //Arrange
            Employee e = new Employee()
            {
                FirstName = "Matt",
                LastName = "Warner",
                Age = 23
            };
            int expected = 23;
            //Act
            e.Age = 23;

            //Assert
            Assert.AreEqual(expected, e.Age);
            Assert.Fail();
        }
    }
}