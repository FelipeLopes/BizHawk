﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eto.Forms;
using Eto;
using Eto.Drawing;
using BizHawk.Client.Common;
using BizHawk.Emulation.Common;
using System.Threading;
using System.Runtime.InteropServices;
using System.IO;
using System.Reflection;
using EtoHawk.Config;

/* This file is generated by hand and you should feel free to modify it. */

namespace BizHawk.Client.EtoHawk
{
    public partial class MainForm : Form
    {
        private void InitializeWindow()
        {
            ClientSize = new Size(640, 480);
            Title = "BizHawk";
            
            _viewport = new Drawable();
            _viewport.Paint += viewport_Paint;
            Content = _viewport;
            this.Closed += MainForm_Closed;

            _mnuConfigControllers = new ButtonMenuItem() { Text = "Controllers..." };
            _mnuConfigControllers.Click += (sender, e) => {
                _suspended = true;
                using(ControllerConfig cc = new ControllerConfig (Global.Emulator.ControllerDefinition))
                {
                    if (cc.ShowModal(this))
                    {
                        InitControls ();
                        InputManager.SyncControls ();
                    }
                }
                _suspended = false;
            };
			_mnuConfigFirmwares = new ButtonMenuItem () { Text = "Firmwares..." };
			_mnuConfigFirmwares.Click += (sender, e) => {
				_suspended = true;
				using(FirmwaresConfig cc = new FirmwaresConfig())
				{
					cc.ShowModal(this);
				}
				_suspended = false;
			};

            Menu = new MenuBar
            {
                Items =
				{
					new ButtonMenuItem
					{ 
						Text = "&File",
						Items =
						{
							new Command((sender, e)=>OpenRom()){
                                MenuText = "Open ROM...", 
                                Shortcut = Application.Instance.CommonModifier | Keys.O
                            }
						}
					},
                    new ButtonMenuItem{
                        Text="Emulation",
                        Items = {
                            new ButtonMenuItem { Text = "Pause" },
                            new ButtonMenuItem { Text = "Reboot Core", Shortcut=Application.Instance.CommonModifier | Keys.R}
                        }
                    },
                    new ButtonMenuItem{
                        Text="Config",
                        Items = {
                            _mnuConfigControllers,
							_mnuConfigFirmwares
                        }
                    }
				},
                // quit item (goes in Application menu on OS X, File menu for others)
                QuitItem = new Command((sender, e) => { Shutdown(); })
                {
                    MenuText = "Quit",
                    Shortcut = Application.Instance.CommonModifier | Keys.Q
                },
                // about command (goes in Application menu on OS X, Help menu for others)
                AboutItem = new Command((sender, e) => new Dialog { Content = new Label { Text = "About BizHawk..." }, ClientSize = new Size(200, 200) }.ShowModal(this))
                {
                    MenuText = "About BizHawk"
                }
            };
            EnableControls();
        }

        private void EnableControls()
        {
            _mnuConfigControllers.Enabled = !(Global.Emulator is NullEmulator);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            e.Handled = true;
            //OS X will beep any time you press a key if it thinks we aren't handling it.
            //Since OpenTK is going to handle the input, we need to let the UI know we took care of it.
        }

        private ButtonMenuItem _mnuConfigControllers;
		private ButtonMenuItem _mnuConfigFirmwares;
        private Drawable _viewport;
    }
}
