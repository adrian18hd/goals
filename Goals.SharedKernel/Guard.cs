using System;

namespace Goals.SharedKernel
{
	public static class Guard
	{
		public static void ForNullOrEmpty(string value, string parameterName)
		{
			if (String.IsNullOrWhiteSpace(value))
			{
				throw new ArgumentOutOfRangeException(parameterName);
			}
		}

		public static void ForEmpty(Guid value, string parameterName)
		{
			if (value == Guid.Empty)
			{
				throw new ArgumentOutOfRangeException(parameterName);
			}
		}

		public static void ForZeroOrLess(decimal value, string parameterName)
		{
			if (value <= 0)
			{
				throw new ArgumentOutOfRangeException(parameterName);
			}
		}

		public static void ForNull(object value, string parameterName)
		{
			if (value == null)
				throw new ArgumentOutOfRangeException(parameterName);
		}
	}
}