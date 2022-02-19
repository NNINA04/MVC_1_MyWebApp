using System;
using Common.BusinessLogic;
using NUnit.Framework;

namespace UnitTests.BusinessLogic
{
    public class SQLVisitInfoTests
    {
        static readonly SQLVisitInfo _sqlVisitInfo = new SQLVisitInfo();

        [Test]
        public void Constructor_WithoutParameters_CreatesValidInstance()
        {
            Assert.DoesNotThrow(() => new SQLVisitInfo());
        }

        [Test]
        public void Visitor_IsNotNull()
        {
            Assert.NotNull(_sqlVisitInfo.Visitor);
        }

        //[Test] // Тут значение должно браться из базы данных
        //public void UserId_IncrementsOnInstantiation([Range(1, 5)] int expectedId)
        //{
        //    Assert.AreEqual(expectedId, new SQLVisitInfo().Visitor.Id);
        //}

        [Test]
        public void Date_EqualsCurrentTime()
        {
            DateTime currentDate = DateTime.Now;
            DateTime sqlVisitInfoDate = _sqlVisitInfo.Date;

            string expected = $"{currentDate.Year}:{currentDate.Month}:{currentDate.DayOfWeek}:{currentDate.Day}:" +
                $"{currentDate.Hour}:{currentDate.Minute}:{currentDate.Second}";

            var actual = $"{sqlVisitInfoDate.Year}:{sqlVisitInfoDate.Month}:{sqlVisitInfoDate.DayOfWeek}:" +
                $"{sqlVisitInfoDate.Day}:{sqlVisitInfoDate.Hour}:{sqlVisitInfoDate.Minute}:{sqlVisitInfoDate.Second}";

            // This difficulty because different milliseconds on creating two instances

            Assert.AreEqual(expected, actual);
        }
    }
}
