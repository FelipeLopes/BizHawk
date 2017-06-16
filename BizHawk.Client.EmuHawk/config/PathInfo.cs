using System;
using System.Windows.Forms;

using BizHawk.Common;

namespace BizHawk.Client.EmuHawk
{
	public partial class PathInfo : SafeForm
	{
		public PathInfo()
		{
			InitializeComponent();
		}

		private void Ok_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
