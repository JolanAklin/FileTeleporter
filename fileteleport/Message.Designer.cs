namespace fileteleport
{
    partial class Message
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblYes = new System.Windows.Forms.Label();
            this.lblText = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lblYes, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 133);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(327, 32);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // lblYes
            // 
            this.lblYes.AutoSize = true;
            this.lblYes.BackColor = System.Drawing.Color.Black;
            this.lblYes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblYes.ForeColor = System.Drawing.Color.White;
            this.lblYes.Location = new System.Drawing.Point(3, 3);
            this.lblYes.Margin = new System.Windows.Forms.Padding(3);
            this.lblYes.Name = "lblYes";
            this.lblYes.Size = new System.Drawing.Size(321, 26);
            this.lblYes.TabIndex = 1;
            this.lblYes.Text = "Yes";
            this.lblYes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblYes.Click += new System.EventHandler(this.LblYes_Click);
            this.lblYes.MouseEnter += new System.EventHandler(this.LblYes_MouseEnter);
            this.lblYes.MouseLeave += new System.EventHandler(this.LblYes_MouseLeave);
            // 
            // lblText
            // 
            this.lblText.BackColor = System.Drawing.Color.Gray;
            this.lblText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblText.ForeColor = System.Drawing.Color.White;
            this.lblText.Location = new System.Drawing.Point(0, 0);
            this.lblText.Name = "lblText";
            this.lblText.Padding = new System.Windows.Forms.Padding(10);
            this.lblText.Size = new System.Drawing.Size(327, 133);
            this.lblText.TabIndex = 5;
            this.lblText.Text = "label1";
            this.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Message
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(327, 165);
            this.ControlBox = false;
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Message";
            this.Text = "Message";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblYes;
        private System.Windows.Forms.Label lblText;
    }
}