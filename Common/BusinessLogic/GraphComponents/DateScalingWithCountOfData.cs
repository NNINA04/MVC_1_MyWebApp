using Common.Interfaces.GraphComponents;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Common.BusinessLogic.GraphComponents
{
	public sealed class DateScalingWithCountOfData<TData>
	{
		public Dictionary<DateTime, int> GraphData { get; private set; }

		public DateScalingWithCountOfData(SortedDataWithDateTime<TData> sortedDataWithDateTime)
		{
			if (sortedDataWithDateTime is null)
				throw new ArgumentNullException(nameof(sortedDataWithDateTime));

			GraphData = ScaleDateAndCalculateData(sortedDataWithDateTime.DataWithDateTime);
		}

		Dictionary<DateTime, int> ScaleDateAndCalculateData(IEnumerable<IDataWithDateTime<TData>> data)
		{
			var graphDataArr = data.ToArray();

			var graphData = new Dictionary<DateTime, int>();

			for (int i = 0; i < graphDataArr.Length; i++)
			{
				// ДОПИСАТЬ ЭТОТ МЕТОД
			}

			return graphData;
		}
	}
}
