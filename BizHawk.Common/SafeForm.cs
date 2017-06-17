using System;
using System.Windows.Forms;

namespace BizHawk.Common
{
	public partial class SafeForm : Form
	{
		public new void Show ()
		{
			lock (XLock.GetLock ()) {
				base.Show ();
			}
		}

		public new DialogResult ShowDialog ()
		{
			DialogResult result;
			lock (XLock.GetLock ()) {
				result = base.ShowDialog ();
			}
			return result;
		}

        public new void Close ()
        {
            lock (XLock.GetLock ()) {
                base.Close ();
            }
        }
	}
}