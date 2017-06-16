using System;
using System.Windows.Forms;

using BizHawk.Common;

namespace BizHawk.Client.EmuHawk
{
	public partial class FramesPrompt : SafeForm
	{
		public FramesPrompt()
		{
			InitializeComponent();
		}

		public int Frames => NumFramesBox.ToRawInt() ?? 0;

		private void FramesPrompt_Load(object sender, EventArgs e)
		{
			NumFramesBox.Select();
		}

		private void OkBtn_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}

		private void CancelBtn_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
	}
}
