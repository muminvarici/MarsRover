using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover.Core
{
	public class StringOperations
	{
		/// <summary>
		/// Returns an array of values splitted by the seperator character
		/// </summary>
		/// <param name="value">The value of string contains seperator character</param>
		/// <param name="seperator">The seperator character. Default value is 'space' character</param>
		/// <returns></returns>
		public static IEnumerable<T> GetSplittedArray<T>(string value)
		{
			var values = value.ToCharArray().Where(w => w != ' ').Select(w => Convert.ToString(w));
			if (typeof(T) == typeof(int))
			{
				return values.Select(w => Convert.ToInt32(w)) as IEnumerable<T>;
			}
			else if (typeof(T).IsEnum)
			{
				var enumValues = (T[])Enum.GetValues(typeof(T));
				return values.Select(s => enumValues.FirstOrDefault(w => w.ToString().StartsWith(s)));
			}
			return values as T[];
		}
	}
}
