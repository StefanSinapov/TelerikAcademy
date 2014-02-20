using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class InvalidRangeException<T> : Exception
{
	public T Min { get; private set; }
	public T Max { get; private set; }

	public InvalidRangeException(string message,T min,T max)
		:base(message)
	{
		this.Min = min;
		this.Max = max;
	}

}

