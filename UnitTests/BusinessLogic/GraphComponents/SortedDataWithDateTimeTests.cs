using Common.BusinessLogic.GraphComponents;
using Common.Interfaces.GraphComponents;
using Moq;
using NUnit.Framework;
using System;
using System.Linq;

namespace UnitTests.BusinessLogic.GraphComponents
{
	internal class SortedDataWithDateTimeTests
	{
		[Test]
		public void Constructor_WithNullParameters_ThrowsArgumentNullException()
		{
			Assert.Throws<ArgumentNullException>(() => new SortedDataWithDateTime<object>(null));
		}

		[Test]
		public void Constructor_WithEnumerableWithNullValue_ThrowsArgumentNullException()
		{
			var enumerableWithNullItem = new IDataWithDateTime<object>[] { null };

			Assert.Throws<ArgumentNullException>(() => new SortedDataWithDateTime<object>(enumerableWithNullItem));
		}

		[Test]
		public void Constructor_WithEmptyEnumerable_CreatesValidInstance()
		{
			var enumerableWithNullItem = new IDataWithDateTime<object>[] { };

			Assert.Throws(Is.TypeOf<ArgumentException>().And
				.Message.EqualTo("dataWithDateTime (Parameter 'Не содержит элементов')"),
				() => new SortedDataWithDateTime<object>(enumerableWithNullItem));
		}

		[Test]
		public void DataWithDateTime_IsNotNull()
		{
			DateTime firstDay = DateTime.Now;
			DateTime secondDay = firstDay.AddDays(1);

			var enumerableWithCorrectItems = new IDataWithDateTime<object>[]
			{
					GetObjectGeneratedUsingMock(secondDay),
					GetObjectGeneratedUsingMock(firstDay)
			};

			var sortedDataWithDateTime = new SortedDataWithDateTime<object>(enumerableWithCorrectItems);

			Assert.IsNotNull(sortedDataWithDateTime.DataWithDateTime);
		}

		[Test]
		public void DataWithDateTime_ReturnsSortedEnumerable()
		{
			const int size = 2;

			DateTime firstDay = DateTime.Now;
			DateTime secondDay = firstDay.AddDays(1);

			var enumerableWithCorrectItems = new IDataWithDateTime<object>[size]
			{
					GetObjectGeneratedUsingMock(secondDay),
					GetObjectGeneratedUsingMock(firstDay)
			};

			var sortedDataWithDateTime = new SortedDataWithDateTime<object>(enumerableWithCorrectItems);

			var autoSortedDataWithDateTime = sortedDataWithDateTime.DataWithDateTime;
			var manuallySortedDataWithDateTime = enumerableWithCorrectItems.OrderBy(x => x.Date);

			bool twoSequenceEqual = Enumerable.SequenceEqual(autoSortedDataWithDateTime, manuallySortedDataWithDateTime);

			Assert.IsTrue(twoSequenceEqual);
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
