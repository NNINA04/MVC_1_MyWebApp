using System;

namespace Common.Interfaces.GraphComponents
{
	public interface IDataWithDateTime<TData>
	{
		DateTime Date { get; set; }

		TData GetData();
	}
}
