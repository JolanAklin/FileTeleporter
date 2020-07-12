namespace fileteleport.dialogs
{
    partial class ProgressDialogue
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgressDialogue));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pBar = new fileteleport.classes.CustomProgressBar();
            this.lblInfoProgress = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.pBar, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 133);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(327, 32);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // pBar
            // 
            this.pBar.BackColor = System.Drawing.Color.Black;
            this.pBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pBar.ForeColor = System.Drawing.Color.Black;
            this.pBar.Location = new System.Drawing.Point(3, 3);
            this.pBar.Name = "pBar";
            this.pBar.Size = new System.Drawing.Size(321, 26);
            this.pBar.Step = 1;
            this.pBar.TabIndex = 0;
            this.pBar.Value = 50;
            // 
            // lblInfoProgress
            // 
            this.lblInfoProgress.BackColor = System.Drawing.Color.Gray;
            this.lblInfoProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInfoProgress.ForeColor = System.Drawing.Color.White;
            this.lblInfoProgress.Location = new System.Drawing.Point(0, 0);
            this.lblInfoProgress.Name = "lblInfoProgress";
            this.lblInfoProgress.Padding = new System.Windows.Forms.Padding(10);
            this.lblInfoProgress.Size = new System.Drawing.Size(327, 133);
            this.lblInfoProgress.TabIndex = 6;
            this.lblInfoProgress.Text = "label1";
            this.lblInfoProgress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ProgressDialogue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(327, 165);
            this.ControlBox = false;
            this.Controls.Add(this.lblInfoProgress);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProgressDialogue";
            this.Text = "Progress";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblInfoProgress;
        private classes.CustomProgressBar pBar;
    }
}