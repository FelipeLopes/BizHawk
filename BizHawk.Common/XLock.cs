using System;

namespace BizHawk.Common
{
	public static class XLock
	{
		private static readonly Object xLock = new object ();

		public static Object GetLock ()
		{
			return xLock;
		}
	}
}

