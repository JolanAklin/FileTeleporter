using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Windows.Forms;
using System.Drawing;
using Theming;

namespace fileteleport
{
    public class Machine : Label
    {
        private string Mname = "";
        private IPAddress Mip;
        private Form1 mainForm;

        public Machine(string name, IPAddress ip, Form1 mainForm)
        {
            Mname = name;
            Mip = ip;
            this.mainForm = mainForm;
            this.Text = Mname;
            this.Dock = DockStyle.Fill;
            this.ForeColor = Color.White;
            this.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Bold);
            this.TextAlign = ContentAlignment.MiddleLeft;
            this.Margin = new Padding(3);
            this.BackColor = Theme.backColor1;
            this.MouseEnter += new EventHandler(machineHoverEnter);
            this.MouseLeave += new EventHandler(machineHoverLeave);
            this.Click += new EventHandler(machineClick);
            ForeColor = Theme.textColor;
        }

        public string getName()
        {
            return Mname;
        }

        public string getIp()
        {
            return Mip.ToString();
        }

        private void machineHoverEnter(object sender, EventArgs e)
        {
            Label tlpSender = sender as Label;
            tlpSender.BackColor = Theme.hoverColor;
        }
        private void machineHoverLeave(object sender, EventArgs e)
        {
            Label tlpSender = sender as Label;
            tlpSender.BackColor = Theme.backColor1;
        }
        private void machineClick(object sender, EventArgs e)
        {
            mainForm.OpenSendFileDialog(this);
        }
    }
}
