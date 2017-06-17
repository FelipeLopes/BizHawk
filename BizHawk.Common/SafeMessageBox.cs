using System;
using System.Windows.Forms;

namespace BizHawk.Common
{
	public class SafeMessageBox
	{
		public static DialogResult Show (string text)
		{
			DialogResult result;
			lock(XLock.GetLock()) {
				result = MessageBox.Show (text);
			}
			return result;
		}

		public static DialogResult Show (string text, string caption)
		{
			DialogResult result;
			lock (XLock.GetLock ()) {
				result = MessageBox.Show (text,caption);
			}
			return result;
		}

		public static DialogResult Show (string text, string caption,
										 MessageBoxButtons buttons)
		{
			DialogResult result;
			lock (XLock.GetLock ()) {
				result = MessageBox.Show (text, caption, buttons);
			}
			return result;
		}

		public static DialogResult Show (string text, string caption,
		                                 MessageBoxButtons buttons,
		                                 MessageBoxIcon icon)
		{
			DialogResult result;
			lock (XLock.GetLock ()) {
				result = MessageBox.Show (text,caption,buttons,icon);
			}
			return result;
		}

		public static DialogResult Show (string text, string caption,
										 MessageBoxButtons buttons,
										 MessageBoxIcon icon,
		                                 MessageBoxDefaultButton defaultButton)
		{
			DialogResult result;
			lock (XLock.GetLock ()) {
				result = MessageBox.Show (text, caption, buttons, icon,
				                          defaultButton);
			}
			return result;
		}

		public static DialogResult Show (IWin32Window owner, string text)
		{
			DialogResult result;
			lock (XLock.GetLock ()) {
				result = MessageBox.Show (owner,text);
			}
			return result;
		}

		public static DialogResult Show (IWin32Window owner, string text,
		                                string caption)
		{
			DialogResult result;
			lock (XLock.GetLock ()) {
				result = MessageBox.Show (owner,text,caption);
			}
			return result;
		}

		public static DialogResult Show (IWin32Window owner, string text,
		                                 string caption, MessageBoxButtons buttons,
										 MessageBoxIcon icon)
		{
			DialogResult result;
			lock (XLock.GetLock ()) {
				result = MessageBox.Show (owner, text, caption, buttons, icon);
			}
			return result;
		}

		public static DialogResult Show (IWin32Window owner, string text,
										 string caption, MessageBoxButtons buttons)
		{
			DialogResult result;
			lock (XLock.GetLock ()) {
				result = MessageBox.Show (owner, text, caption, buttons);
			}
			return result;
		}
	}
}

