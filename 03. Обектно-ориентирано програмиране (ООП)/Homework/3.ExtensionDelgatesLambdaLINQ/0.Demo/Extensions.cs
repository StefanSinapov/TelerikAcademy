using System;
namespace AlotOfFeatures.Extensions
{
	public static class Extensions
	{
		public static int WordCount(this string str)
		{
			return str.Split(new char[] { ' ', '.', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
		}
	}
}
