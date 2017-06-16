﻿using System.Collections.Generic;
using System.Windows.Forms;

using BizHawk.Common;

namespace BizHawk.Client.EmuHawk
{
	public class InputConfigBase : SafeForm
	{
		public void CheckDups()
		{
			Dictionary<string,bool> dups = new Dictionary<string,bool>();
			foreach (Control c in Controls)
			{
				SmartTextBoxControl stbc = c as SmartTextBoxControl;
				if (stbc == null) continue;
				if (dups.ContainsKey(stbc.Text))
				{
					SafeMessageBox.Show("DUP!");
					return;
				}
				dups[stbc.Text] = true;
			}
		}
		
	}
}