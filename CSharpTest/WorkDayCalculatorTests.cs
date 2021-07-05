using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CSharpTest
{
    [TestClass]
    public class WorkDayCalculatorTests
    {

        [TestMethod]
        public void TestNoWeekEnd()
        {
            DateTime startDate = new DateTime(2020, 12, 1);
            int count = 10;

            DateTime result = new WorkDayCalculator().Calculate(startDate, count, null);

            Assert.AreEqual(startDate.AddDays(count - 1), result);
        }

        [TestMethod]
        public void TestNormalPath()
        {
            DateTime startDate = new DateTime(2021, 4, 21);
            int count = 5;
            WeekEnd[] weekends = new WeekEnd[1]
            {
                new WeekEnd(new DateTime(2021, 4, 23), new DateTime(2021, 4, 25))
            }; 

            DateTime result = new WorkDayCalculator().Calculate(startDate, count, weekends);

            Assert.IsTrue(result.Equals(new DateTime(2021, 4, 28)));
        }

        [TestMethod]
        public void TestWeekendAfterEnd()
        {
            DateTime startDate = new DateTime(2021, 4, 21);
            int count = 5;
            WeekEnd[] weekends = new WeekEnd[2]
            {
                new WeekEnd(new DateTime(2021, 4, 23), new DateTime(2021, 4, 25)),
                new WeekEnd(new DateTime(2021, 4, 29), new DateTime(2021, 4, 29))
            };
            
            DateTime result = new WorkDayCalculator().Calculate(startDate, count, weekends);

            Assert.IsTrue(result.Equals(new DateTime(2021, 4, 28)));
        }

        [TestMethod]
        public void TestOneDayWeekEnd()
        {
            DateTime startDate = new DateTime(2021, 10, 10);
            int count = 9;
            WeekEnd[] weekends = new WeekEnd[1]
            {
                new WeekEnd(new DateTime(2021, 10, 12), new DateTime(2021, 10, 12))
            };

            DateTime result = new WorkDayCalculator().Calculate(startDate, count, weekends);

            Assert.AreEqual(new DateTime(2021, 10, 19), result);
        }

        [TestMethod]
        public void TestWeekEndsOnTheFirsDay()
        {
            DateTime startDate = new DateTime(2021, 10, 10);
            int count = 1;
            WeekEnd[] weekends = new WeekEnd[1]
            {
                new WeekEnd(new DateTime(2021, 10, 10), new DateTime(2021, 10, 13))
            };

            DateTime result = new WorkDayCalculator().Calculate(startDate, count, weekends);

            Assert.AreEqual(new DateTime(2021, 10, 14), result);
        }

        [TestMethod]
        public void TestWeekEndsStartAtLastWorkDay()
        {
            DateTime startDate = new DateTime(2021, 10, 10);
            int count = 2;
            WeekEnd[] weekends = new WeekEnd[1]
            {
                new WeekEnd(new DateTime(2021, 10, 11), new DateTime(2021, 10, 13))
            };

            DateTime result = new WorkDayCalculator().Calculate(startDate, count, weekends);

            Assert.AreEqual(new DateTime(2021, 10, 14), result);
        }

        [TestMethod]
        public void TestOnWeekend1()
        {
            DateTime startDate = new DateTime(2021, 4, 22);
            int count = 5;
            WeekEnd[] weekends = new WeekEnd[3]
            {
                new WeekEnd(new DateTime(2021, 4, 21), new DateTime(2021, 4, 23)),
                new WeekEnd(new DateTime(2021, 4, 26), new DateTime(2021, 4, 27)),
                new WeekEnd(new DateTime(2021, 5, 1), new DateTime(2021, 5, 3))
            };

            DateTime result = new WorkDayCalculator().Calculate(startDate, count, weekends);

            Assert.IsTrue(result.Equals(new DateTime(2021, 4, 30)));
        }

        [TestMethod]
        public void TestOnWeekend2()
        {
            DateTime startDate = new DateTime(2021, 4, 23);
            int count = 5;
            WeekEnd[] weekends = new WeekEnd[2]
            {
                new WeekEnd(new DateTime(2021, 4, 21), new DateTime(2021, 4, 23)),
                new WeekEnd(new DateTime(2021, 4, 26), new DateTime(2021, 4, 27)),
            };

            DateTime result = new WorkDayCalculator().Calculate(startDate, count, weekends);

            Assert.IsTrue(result.Equals(new DateTime(2021, 4, 30)));
        }

        [TestMethod]
        public void TestCase4()
        {
            DateTime startDate = new DateTime(2021, 4, 21);
            int count = 5;
            WeekEnd[] weekends = new WeekEnd[2]
            {
                new WeekEnd(new DateTime(2021, 4, 15), new DateTime(2021, 4, 16)),
                new WeekEnd(new DateTime(2021, 4, 19), new DateTime(2021, 4, 22)),
            };

            DateTime result = new WorkDayCalculator().Calculate(startDate, count, weekends);

            Assert.IsTrue(result.Equals(new DateTime(2021, 4, 27)));
        }

        [TestMethod]
        public void FinalTestCase()
        {
            DateTime startDate = new DateTime(2021, 4, 21);
            int count = 5;
            WeekEnd[] weekends = new WeekEnd[5]
            {
                new WeekEnd(new DateTime(2021, 4, 15), new DateTime(2021, 4, 16)),
                new WeekEnd(new DateTime(2021, 4, 19), new DateTime(2021, 4, 22)),
                new WeekEnd(new DateTime(2021, 4, 24), new DateTime(2021, 4, 25)),
                new WeekEnd(new DateTime(2021, 4, 28), new DateTime(2021, 4, 29)),
                new WeekEnd(new DateTime(2021, 5, 19), new DateTime(2021, 5, 22)),
            };

            DateTime result = new WorkDayCalculator().Calculate(startDate, count, weekends);

            Assert.IsTrue(result.Equals(new DateTime(2021, 5, 1)));
        }
    }
}
