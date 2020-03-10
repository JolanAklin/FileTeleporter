
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

namespace fileteleport
{
    public partial class Message : Form
    {
        public Message(string text, string title)
        {
            InitializeComponent();
            this.Text = title;
            this.BackColor = Theme.backColor1;
            lblYes.BackColor = Theme.backColor2;
            lblText.BackColor = Theme.backColor1;
            tableLayoutPanel1.BackColor = Theme.backColor1;
            lblText.Text = text;
        }

        private void LblYes_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LblYes_MouseEnter(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            lbl.BackColor = Theme.hoverColor;
        }

        private void LblYes_MouseLeave(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            lbl.BackColor = Theme.backColor2;
        }
    }
}
