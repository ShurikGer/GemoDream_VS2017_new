using System;

namespace CMStrategy
{
	/// <summary>
	/// Summary description for CMStrategyFactory.
	/// </summary>
	public class CMStrategyFactory
	{
		public static CMStrategy CreateCMStrategy(int code)
		{
			if (code > 2)
			{
				return new CMAccessStrategy(code);
			}
			else
			{
				return new CMAlertStrategy(code);
			}
		}
	}
}
