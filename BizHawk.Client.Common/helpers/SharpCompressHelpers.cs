using System;
using SharpCompress.Archives;
using SharpCompress.Archives.Zip;

namespace BizHawk.Client.Common
{
	public static class SharpCompressHelpers
	{
		public static IArchiveEntry GetEntry(this IArchive arch, string name){
			foreach (var entry in arch.Entries) {
				if (entry.Key.Equals (name, StringComparison.Ordinal)) {
					return entry;
				}
			}
			return null;
		}

		public static IArchiveEntry GetEntry(this IArchive arch, int index){
			int i = -1;
			foreach (var entry in arch.Entries) {
				i++;
				if (i == index) {
					return entry;
				}
			}
			return null;
		}
	}
}

