using Common.Interfaces.GraphComponents;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.BusinessLogic.GraphComponents
{
	public class SortedDataWithDateTime<TData>
	{
		public IEnumerable<IDataWithDateTime<TData>> DataWithDateTime { get; }

		public SortedDataWithDateTime(IEnumerable<IDataWithDateTime<TData>> dataWithDateTime)
		{
			if (dataWithDateTime is null)
				throw new ArgumentNullException(nameof(dataWithDateTime));

			if (dataWithDateTime.Any(x => x is null))
				throw new ArgumentNullException(nameof(dataWithDateTime), "Перечисление не может содержать Null значение");

			bool containsSomething = dataWithDateTime.Any();
			if (containsSomething == false)
				throw new ArgumentException(nameof(dataWithDateTime), "Не содержит элементов");

			DataWithDateTime = dataWithDateTime.OrderBy(x => x.Date);
		}
	}
}
