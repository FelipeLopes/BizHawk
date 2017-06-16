using System;
using System.Windows.Forms;

using BizHawk.Common;

namespace BizHawk.Client.EmuHawk
{
	public partial class NameStateForm : SafeForm
	{
		public string Result;
		public bool OK;

		public NameStateForm()
		{
			InitializeComponent();
			AcceptButton = saveButton;
			CancelButton = cancelButton;
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void saveButton_Click(object sender, EventArgs e)
		{
			if (stateLabelTextBox.Text.Length != 0)
			{
				Result = stateLabelTextBox.Text;
				OK = true;
				Close();
			}
		}

		private void NameStateForm_Shown(object sender, EventArgs e)
		{
			stateLabelTextBox.Focus();
		}
	}
}
