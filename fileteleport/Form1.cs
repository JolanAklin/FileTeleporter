﻿
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
using System.Net;
using System.Threading;
using Theming;
using System.Net;
using System.Net.Sockets;
using fileteleport.dialogs;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace fileteleport
{
    public partial class Form1 : Form
    {
        private List<Machine> pcs;
        public String pcName = System.Environment.MachineName;
        public ProgressDialogue pDialogue;

        private int row = 1;
        public sendFile sendfile = new sendFile();

        //UDP sockets
        int PORT = 53584;
        UdpClient udpClient = new UdpClient();
        Thread tRecieveInfo;
        public Form1()
        {
            InitializeComponent();
            LoadTheme();
            udpClient.Client.Bind(new IPEndPoint(IPAddress.Any.Address, PORT));
            IPEndPoint from = new IPEndPoint(0, 0);
            //Thread tSendInfo = new Thread(() => SendWhoIAm.sendWhoIam(udpClient,PORT,from));
            //tSendInfo.Start();
            tRecieveInfo = new Thread(() => MachineDiscoverer.send(udpClient, PORT, from, this));
            tRecieveInfo.IsBackground = true;
            tRecieveInfo.Start();
            pcs = new List<Machine>();
            pDialogue = new ProgressDialogue("transfer", "transfer", 0);
            lblCredits.ForeColor = Theme.textColor;
            lblSettings.ForeColor = Theme.textColor;

        }

        public void LoadTheme()
        {
            Theme.Initialize(Properties.Settings.Default.WhiteTheme);
            if (Properties.Settings.Default.WhiteTheme)
                panel1.BackgroundImage = Properties.Resources.FileTeleporterHeaderLogoWhiteTheme;
            else
                panel1.BackgroundImage = Properties.Resources.FileTeleporterHeaderLogo;
        }

        public void ShowPcInvoke(Machine pc)
        {
            Invoke(new Action(() =>
            {
                ShowPc(pc);
            }));
        }
        public void ShowPc(Machine pc)
        {
            pcs.Add(pc);
            ShowMachine(pcs[pcs.Count - 1]);
        }
        public void invokeDeleteMachine(string pcName)
        {
            Invoke(new Action(() =>
            {
                deleteMachine(pcName);
            }));
        }
        public void deleteMachine(string pcName)
        {
            foreach (Machine item in tlpMachine.Controls)
            {
                if (item.getName() == pcName)
                {
                    pcs.Remove(item);
                    break;
                }
            }
            RefreshMachineList(pcs.ToArray());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //initialise le sendFile
            ofd1.InitialDirectory = "c:\\";
            ofd1.Filter = "All files (*.*)|*.*";
            ofd1.FilterIndex = 2;
            ofd1.Title = "Send a file";

            this.BackColor = Theme.backColor1;
            pnlScroll.BackColor = Theme.backColor2;
            Machine pc1;
            pc1 = new Machine("Loopback", IPAddress.Parse("127.0.0.1"), this);
            ShowPc(pc1);

            //start the receving server
            sendfile.Initialize(this);
        }


        #region afficheur de machine
        private void ShowMachine(Machine machineToShow)
        {
            tlpMachine.Controls.Add(machineToShow, 0, row - 1);
            tlpMachine.RowStyles.Add(new RowStyle());
            tlpMachine.RowStyles[row - 1].SizeType = SizeType.Absolute;
            tlpMachine.RowStyles[row - 1].Height = 50;
            row++;
        }
        private void RefreshMachineList(Machine[] machinesToShow)
        {
            tlpMachine.Controls.Clear();
            row = 1;
            foreach (Machine pc in machinesToShow)
            {
                tlpMachine.Controls.Add(pc, 0, row - 1);
                tlpMachine.RowStyles.Add(new RowStyle());
                tlpMachine.RowStyles[row - 1].SizeType = SizeType.Absolute;
                tlpMachine.RowStyles[row - 1].Height = 50;
                row++;
            }
        }
        #endregion

        public void OpenSendFileDialog(Machine sender)
        {
            if (ofd1.ShowDialog() == DialogResult.OK)
            {
                string filePath = ofd1.FileName;
                sendConfirmation sendConf = new sendConfirmation(sender.getName(), sender.getIp(), filePath, sendfile, this);
                sendConf.ShowDialog();
            }
        }

        #region savefiledialog
        public void ShowSaveDialogue(string[] fileNameExtension, string size, string pcName)
        {
            Invoke(new Action(() =>
            {
                saveFile(fileNameExtension, size, pcName);
                //Thread threadProgress;
                //threadProgress = new Thread(() => saveFile(fileNameExtension, size, pcName));
                //threadProgress.IsBackground = true;
                //threadProgress.Start();
            }));
        }

        private void saveFile(string[] fileNameExtension, string size, string pcName)
        {
            SaveFile savefileDialog = new SaveFile(this, fileNameExtension, size, pcName);
            savefileDialog.ShowDialog();
        }
        public void AsToSaveFile(string path)
        {
            Thread writefile;
            writefile = new Thread(() => sendfile.WriteFile(path));
            writefile.IsBackground = true;
            writefile.Start();
        }
        public void AsToNotSaveFile()
        {
            sendfile.NotSaveFile();
        }
        #endregion

        private void Label1_Click(object sender, EventArgs e)
        {
            Message msg = new Message("Made by Jolan Aklin and Yohan Zbinden\n\nCopyright 2019 Jolan Aklin and Yohan Zbinden\nThis software is ditributed under the terms of the GNU General Public License as published by the Free Software Foundation. You should have received a copy of the GNU General Public License along with FileTeleporter.  If not, see<https://www.gnu.org/licenses/>.", "Credits");
            msg.Show();
        }

        private void Label1_MouseEnter(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            lbl.ForeColor = Theme.hoverColor;
        }

        private void Label1_MouseLeave(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            lbl.ForeColor = Theme.textColor;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            MachineDiscoverer.disconnect();
        }
        public void ShowError(string error)
        {
            Invoke(new Action(() =>
            {
                Message msg = new Message(error, "Error");
                msg.Show();
            }));
        }

        private void Form1_Link_Mouse_Enter(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            lbl.ForeColor = Theme.hoverColor;
        }

        private void From1_Link_Mouse_Leave(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            lbl.ForeColor = Theme.textColor;
        }

        private void Click_Credits(object sender, EventArgs e)
        {
            Message msg = new Message("Made by Jolan Aklin and Yohan Zbinden\n\nCopyright 2019 Jolan Aklin and Yohan Zbinden\nThis software is ditributed under the terms of the GNU General Public License as published by the Free Software Foundation. You should have received a copy of the GNU General Public License along with FileTeleporter.  If not, see<https://www.gnu.org/licenses/>.", "Credits");
            msg.Show();
        }

        private void Click_Settings(object sender, EventArgs e)
        {
            Settings settings = new Settings(this);
            settings.Show();
        }
        public void FormClose()
        {
            this.Close();
        }
    }
}
