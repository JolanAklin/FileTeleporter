
//Copyright 2019,2020 Jolan Aklin and Yohan Zbinden


//This file is part of FileTeleporter.

//FileTeleporter is free software: you can redistribute it and/or modify
//it under the terms of the GNU General Public License as published by
//the Free Software Foundation, version 3 of the License.

//FileTeleporter is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//GNU General Public License for more details.

//You should have received a copy of the GNU General Public License
//along with FileTeleporter.  If not, see<https://www.gnu.org/licenses/>.


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Theming;

namespace fileteleport.dialogs
{
    public partial class Settings : Form
    {
        private Form mainForm;
        private bool whiteTheme;

        public Settings(Form mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            this.BackColor = Theme.backColor1;
            lblClose.BackColor = Theme.backColor2;
            lblSave.BackColor = Theme.backColor2;
            tlpWhiteTheme.BackColor = Theme.backColor2;
            lblClose.ForeColor = Theme.textColor;
            lblSave.ForeColor = Theme.textColor;
            lblwhiteTheme.ForeColor = Theme.textColor;
            lblRestart.ForeColor = Theme.textColor;
            whiteTheme = Properties.Settings.Default.WhiteTheme;
            if (whiteTheme)
                cbxWhiteTheme.Checked = true;
        }

        private void Mouse_Enter(object sender, EventArgs e)
        {
            Label lblSender = sender as Label;
            lblSender.BackColor = Theme.hoverColor;
        }

        private void Mouse_Leave(object sender, EventArgs e)
        {
            Label lblSender = sender as Label;
            lblSender.BackColor = Theme.backColor2;
        }

        private void Click_Close(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Click_Save(object sender, EventArgs e)
        {
            Properties.Settings.Default.WhiteTheme = whiteTheme;
            Properties.Settings.Default.Save();
            this.Close();
            Application.Restart();
        }

        private void cbxWhiteTheme_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cbx = sender as CheckBox;
            whiteTheme = cbx.Checked;
        }
    }
}
