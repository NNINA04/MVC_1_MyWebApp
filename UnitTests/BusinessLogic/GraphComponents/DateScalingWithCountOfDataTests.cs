using Common.BusinessLogic.GraphComponents;
using Common.Interfaces.GraphComponents;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests.BusinessLogic.GraphComponents
{
	internal class DateScalingWithCountOfDataTests
	{
		[Test]
		public void Constructor_WithNullParameters_ThrowsArgumentNullException()
		{
			Assert.Throws<ArgumentNullException>(() => new DateScalingWithCountOfData<object>(null));
		}

		[Test]
		public void GraphData_ReturnsCorrectScaledData()
		{
			DateTime firstDay = DateTime.Now;
			DateTime secondDay = firstDay.AddDays(1);
			DateTime thirdDay = secondDay.AddDays(1);

			var enumerableWithCorrectItems = new IDataWithDateTime<object>[]
			{
				GetObjectGeneratedUsingMock(thirdDay),
				GetObjectGeneratedUsingMock(firstDay)
			};

			var sortedDataWithDateTime = new SortedDataWithDateTime<object>(enumerableWithCorrectItems);

			Dictionary<DateTime, int> scaledDateWithCountOfData =
				new DateScalingWithCountOfData<object>(sortedDataWithDateTime).GraphData;

			Assert.AreEqual(firstDay, scaledDateWithCountOfData.Keys.ElementAt(0));
			Assert.AreEqual(secondDay, scaledDateWithCountOfData.Keys.ElementAt(1));
			Assert.AreEqual(thirdDay, scaledDateWithCountOfData.Keys.ElementAt(2));

			Assert.AreEqual(1, scaledDateWithCountOfData[firstDay]);
			Assert.AreEqual(0, scaledDateWithCountOfData[secondDay]);
			Assert.AreEqual(1, scaledDateWithCountOfData[thirdDay]);
		}

		private IDataWithDateTime<object> GetObjectGeneratedUsingMock(DateTime date)
		{
			Mock<IDataWithDateTime<object>> mock = new Mock<IDataWithDateTime<object>>();

			mock.Setup(x => x.Date).Returns(date);
			mock.Setup(x => x.GetData()).Returns(It.IsAny<object>());

			return mock.Object;
		}
	}
}
