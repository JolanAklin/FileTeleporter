
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
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Theming;

namespace fileteleport
{
    public partial class SaveFile : Form
    {

        private Form1 mainForm;
        private string[] fileNameExtension;
        private string weight;
        private string pcName;        

        public SaveFile(Form1 mainForm,string[] fileNameExtension, string size, string pcName)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.fileNameExtension = fileNameExtension;
            weight = (Math.Round(Convert.ToDouble(size) / (double)1024)).ToString() + "Ko";
            this.pcName = pcName;            
        }

        private void SaveFile_Load(object sender, EventArgs e)
        {
            this.BackColor = Theme.backColor1;
            lblCancel.BackColor = Theme.backColor2;
            lblYes.BackColor = Theme.backColor2;
            lblFichier.Text = fileNameExtension[0] + "." + fileNameExtension[1];
            lblSize.Text = weight;
            lblPc.Text = pcName;
            tlpFichier.BackColor = Theme.backColor2;
            tlpPc.BackColor = Theme.backColor2;
        }

        private void lblNo_Click(object sender, EventArgs e)
        {
            mainForm.AsToNotSaveFile();
            this.Close();
        }

        private void lblYes_MouseEnter(object sender, EventArgs e)
        {
            Label lblSender = sender as Label;
            lblSender.BackColor = Theme.hoverColor;
        }

        private void lblYes_MouseLeave(object sender, EventArgs e)
        {
            Label lblSender = sender as Label;
            lblSender.BackColor = Theme.backColor2;
        }

        private void lblYes_Click(object sender, EventArgs e)
        {
            sfd1.Title = "Save the received file";
            sfd1.Filter = fileNameExtension[fileNameExtension.Length -1] + " files (*." + fileNameExtension[fileNameExtension.Length - 1] + ")|*." + fileNameExtension[fileNameExtension.Length - 1];
            string filename = "";
            for(int i = 0;i < fileNameExtension.Length;i++)
            {
                if (i == 0)
                    filename += fileNameExtension[i];
                else
                    filename += "." + fileNameExtension[i];
            }
            sfd1.FileName = filename;
            if (sfd1.ShowDialog() == DialogResult.OK)
            {
                this.Close();
                mainForm.AsToSaveFile(sfd1.FileName);
            }
        }
    }
}
