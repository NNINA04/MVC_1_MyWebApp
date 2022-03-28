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
			var graphData = new Dictionary<DateTime, int>();

			DateTime lastDate = data.First().Date;
			graphData.Add(lastDate, 0);

			foreach (var item in data)
			{
				string currentShortDateTime = item.Date.ToShortDateString();

				if (currentShortDateTime != lastDate.ToShortDateString())
				{
					do
					{
						lastDate = lastDate.AddDays(1);
						graphData.Add(lastDate, 0);
					} while (currentShortDateTime != lastDate.ToShortDateString());
				}
				graphData[item.Date]++;
			}

			return graphData;
		}
	}
}
