using System;
using System.Windows.Forms;

namespace BizHawk.Common
{
	public partial class SafeForm : Form
	{
		public void Show ()
		{
			lock (XLock.GetLock ()) {
				base.Show ();
			}
		}

		public DialogResult ShowDialog ()
		{
			DialogResult result;
			lock (XLock.GetLock ()) {
				result = base.ShowDialog ();
			}
			return result;
		}
	}
}