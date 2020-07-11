
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
    public partial class ProgressDialogue : Form
    {
        public ProgressDialogue(string text, string title)
        {
            InitializeComponent();
            this.Text = title;
            this.BackColor = Theme.backColor1;
            lblInfoProgress.BackColor = Theme.backColor1;
            tableLayoutPanel1.BackColor = Theme.backColor1;
            lblInfoProgress.Text = text;
        }

        /// <summary>
        /// Change where the progress bar is between 0 and 100
        /// </summary>
        /// <param name="pos">position for the progress bar to be at</param>
        public void SetProgress (int pos)
        {
            if(pos <= pBar.Maximum && pos >= pBar.Minimum)
            {
                pBar.Value = pos;
            }
        }

        /// <summary>
        /// Add the specified number to the progress bar current position
        /// </summary>
        /// <param name="increment">increment to be added to the progress bar position</param>
        public void MoveProgress (int increment)
        {
            if(pBar.Value + increment > pBar.Maximum)
            {
                pBar.Value = pBar.Maximum;
            }
            else if (pBar.Minimum + increment < pBar.Minimum)
            {
                pBar.Value = pBar.Minimum;
            }
            else
            {
                pBar.Value += increment;
            }
        }

        /// <summary>
        /// Return the current postion of the bar
        /// </summary>
        /// <returns>Position as int</returns>
        public int getProgressPosition ()
        {
            int progress = pBar.Value;
            return progress;
        }

        /// <summary>
        /// Change the current text
        /// </summary>
        /// <param name="text">New text</param>
        public void ChangeText (string text)
        {
            lblInfoProgress.Text = text;
        }

        public string getText ()
        {
            string text = lblInfoProgress.Text;
            return text;
        }

        public void CloseForm ()
        {
            this.Close();
        }
    }
}
