
//Copyright 2019 Jolan Aklin and Yohan Zbinden


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
using System.Threading;
using Theming;

namespace fileteleport
{
    public partial class sendConfirmation : Form
    {

        private string destIP;
        private string fileToSend;
        private sendFile sendFile;
        private Form1 mainForm;

        public sendConfirmation(string nomPc, string ip, string fichier, sendFile sendff, Form1 mainForm)
        {
            InitializeComponent();

            destIP = ip;
            lblPc.Text = nomPc;
            string[] fileName = fichier.Split('\\');
            lblFichier.Text = fileName[fileName.Length - 1];
            fileToSend = fichier;
            lblSize.Text = (Math.Round(new System.IO.FileInfo(fichier).Length / (double)1024)).ToString() + "Ko";
            sendFile = sendff;
            this.mainForm = mainForm;
        }

        private void sendConfirmation_Load(object sender, EventArgs e)
        {
            this.BackColor = Theme.backColor1;
            lblCancel.BackColor = Theme.backColor2;
            lblYes.BackColor = Theme.backColor2;
            tlpFichier.BackColor = Theme.backColor2;
            tlpPc.BackColor = Theme.backColor2;
        }

        private void LabelHoverOut(object sender, EventArgs e)
        {
            Label lblSender = sender as Label;
            lblSender.BackColor = Theme.backColor2;
        }

        private void LabelHoverIn(object sender, EventArgs e)
        {
            Label lblSender = sender as Label;
            lblSender.BackColor = Theme.hoverColor;
        }

        private void lblCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblYes_Click(object sender, EventArgs e)
        {
            sendFile.Send(destIP, fileToSend);
            this.Close();
        }
    }
}
