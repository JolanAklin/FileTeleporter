namespace fileteleport.dialogs
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblClose = new System.Windows.Forms.Label();
            this.lblSave = new System.Windows.Forms.Label();
            this.tlpContainer = new System.Windows.Forms.TableLayoutPanel();
            this.lblRestart = new System.Windows.Forms.Label();
            this.tlpWhiteTheme = new System.Windows.Forms.TableLayoutPanel();
            this.lblwhiteTheme = new System.Windows.Forms.Label();
            this.cbxWhiteTheme = new System.Windows.Forms.CheckBox();
            this.lblAppareance = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tlpContainer.SuspendLayout();
            this.tlpWhiteTheme.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.lblClose, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblSave, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 133);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(327, 32);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblClose
            // 
            this.lblClose.AutoSize = true;
            this.lblClose.BackColor = System.Drawing.Color.Black;
            this.lblClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblClose.ForeColor = System.Drawing.Color.White;
            this.lblClose.Location = new System.Drawing.Point(3, 3);
            this.lblClose.Margin = new System.Windows.Forms.Padding(3);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(157, 26);
            this.lblClose.TabIndex = 2;
            this.lblClose.Text = "Close";
            this.lblClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblClose.Click += new System.EventHandler(this.Click_Close);
            this.lblClose.MouseEnter += new System.EventHandler(this.Mouse_Enter);
            this.lblClose.MouseLeave += new System.EventHandler(this.Mouse_Leave);
            // 
            // lblSave
            // 
            this.lblSave.AutoSize = true;
            this.lblSave.BackColor = System.Drawing.Color.Black;
            this.lblSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSave.ForeColor = System.Drawing.Color.White;
            this.lblSave.Location = new System.Drawing.Point(166, 3);
            this.lblSave.Margin = new System.Windows.Forms.Padding(3);
            this.lblSave.Name = "lblSave";
            this.lblSave.Size = new System.Drawing.Size(158, 26);
            this.lblSave.TabIndex = 3;
            this.lblSave.Text = "Save and restart";
            this.lblSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSave.Click += new System.EventHandler(this.Click_Save);
            this.lblSave.MouseEnter += new System.EventHandler(this.Mouse_Enter);
            this.lblSave.MouseLeave += new System.EventHandler(this.Mouse_Leave);
            // 
            // tlpContainer
            // 
            this.tlpContainer.ColumnCount = 1;
            this.tlpContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpContainer.Controls.Add(this.lblRestart, 0, 2);
            this.tlpContainer.Controls.Add(this.tlpWhiteTheme, 0, 1);
            this.tlpContainer.Controls.Add(this.lblAppareance, 0, 0);
            this.tlpContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpContainer.Location = new System.Drawing.Point(0, 0);
            this.tlpContainer.Name = "tlpContainer";
            this.tlpContainer.RowCount = 3;
            this.tlpContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlpContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlpContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlpContainer.Size = new System.Drawing.Size(327, 84);
            this.tlpContainer.TabIndex = 1;
            // 
            // lblRestart
            // 
            this.lblRestart.AutoSize = true;
            this.lblRestart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRestart.ForeColor = System.Drawing.Color.White;
            this.lblRestart.Location = new System.Drawing.Point(15, 59);
            this.lblRestart.Margin = new System.Windows.Forms.Padding(15, 3, 3, 3);
            this.lblRestart.Name = "lblRestart";
            this.lblRestart.Size = new System.Drawing.Size(309, 22);
            this.lblRestart.TabIndex = 11;
            this.lblRestart.Text = "The app needs to be restarted after changes";
            this.lblRestart.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tlpWhiteTheme
            // 
            this.tlpWhiteTheme.ColumnCount = 2;
            this.tlpWhiteTheme.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpWhiteTheme.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpWhiteTheme.Controls.Add(this.lblwhiteTheme, 0, 0);
            this.tlpWhiteTheme.Controls.Add(this.cbxWhiteTheme, 1, 0);
            this.tlpWhiteTheme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpWhiteTheme.Location = new System.Drawing.Point(15, 31);
            this.tlpWhiteTheme.Margin = new System.Windows.Forms.Padding(15, 3, 15, 3);
            this.tlpWhiteTheme.Name = "tlpWhiteTheme";
            this.tlpWhiteTheme.RowCount = 1;
            this.tlpWhiteTheme.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpWhiteTheme.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpWhiteTheme.Size = new System.Drawing.Size(297, 22);
            this.tlpWhiteTheme.TabIndex = 9;
            // 
            // lblwhiteTheme
            // 
            this.lblwhiteTheme.AutoSize = true;
            this.lblwhiteTheme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblwhiteTheme.ForeColor = System.Drawing.Color.White;
            this.lblwhiteTheme.Location = new System.Drawing.Point(3, 3);
            this.lblwhiteTheme.Margin = new System.Windows.Forms.Padding(3);
            this.lblwhiteTheme.Name = "lblwhiteTheme";
            this.lblwhiteTheme.Size = new System.Drawing.Size(142, 16);
            this.lblwhiteTheme.TabIndex = 6;
            this.lblwhiteTheme.Text = "White theme";
            // 
            // cbxWhiteTheme
            // 
            this.cbxWhiteTheme.AutoSize = true;
            this.cbxWhiteTheme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxWhiteTheme.Location = new System.Drawing.Point(151, 3);
            this.cbxWhiteTheme.Name = "cbxWhiteTheme";
            this.cbxWhiteTheme.Size = new System.Drawing.Size(143, 16);
            this.cbxWhiteTheme.TabIndex = 7;
            this.cbxWhiteTheme.UseVisualStyleBackColor = true;
            this.cbxWhiteTheme.CheckedChanged += new System.EventHandler(this.cbxWhiteTheme_CheckedChanged);
            // 
            // lblAppareance
            // 
            this.lblAppareance.AutoSize = true;
            this.lblAppareance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAppareance.ForeColor = System.Drawing.Color.White;
            this.lblAppareance.Location = new System.Drawing.Point(10, 3);
            this.lblAppareance.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.lblAppareance.Name = "lblAppareance";
            this.lblAppareance.Size = new System.Drawing.Size(314, 22);
            this.lblAppareance.TabIndex = 10;
            this.lblAppareance.Text = "Appearance";
            this.lblAppareance.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(327, 165);
            this.ControlBox = false;
            this.Controls.Add(this.tlpContainer);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Settings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tlpContainer.ResumeLayout(false);
            this.tlpContainer.PerformLayout();
            this.tlpWhiteTheme.ResumeLayout(false);
            this.tlpWhiteTheme.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tlpContainer;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.Label lblSave;
        private System.Windows.Forms.TableLayoutPanel tlpWhiteTheme;
        private System.Windows.Forms.Label lblwhiteTheme;
        private System.Windows.Forms.CheckBox cbxWhiteTheme;
        private System.Windows.Forms.Label lblAppareance;
        private System.Windows.Forms.Label lblRestart;
    }
}