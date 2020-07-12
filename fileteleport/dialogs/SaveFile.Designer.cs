namespace fileteleport
{
    partial class SaveFile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaveFile));
            this.sfd1 = new System.Windows.Forms.SaveFileDialog();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblCancel = new System.Windows.Forms.Label();
            this.lblYes = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tlpFichier = new System.Windows.Forms.TableLayoutPanel();
            this.lblFichier = new System.Windows.Forms.Label();
            this.lblSize = new System.Windows.Forms.Label();
            this.tlpPc = new System.Windows.Forms.TableLayoutPanel();
            this.lblPc = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tlpFichier.SuspendLayout();
            this.tlpPc.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lblCancel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblYes, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 133);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(327, 32);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // lblCancel
            // 
            this.lblCancel.AutoSize = true;
            this.lblCancel.BackColor = System.Drawing.Color.Black;
            this.lblCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCancel.ForeColor = System.Drawing.Color.White;
            this.lblCancel.Location = new System.Drawing.Point(3, 3);
            this.lblCancel.Margin = new System.Windows.Forms.Padding(3);
            this.lblCancel.Name = "lblCancel";
            this.lblCancel.Size = new System.Drawing.Size(157, 26);
            this.lblCancel.TabIndex = 0;
            this.lblCancel.Text = "No";
            this.lblCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCancel.Click += new System.EventHandler(this.lblNo_Click);
            this.lblCancel.MouseEnter += new System.EventHandler(this.lblYes_MouseEnter);
            this.lblCancel.MouseLeave += new System.EventHandler(this.lblYes_MouseLeave);
            // 
            // lblYes
            // 
            this.lblYes.AutoSize = true;
            this.lblYes.BackColor = System.Drawing.Color.Black;
            this.lblYes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblYes.ForeColor = System.Drawing.Color.White;
            this.lblYes.Location = new System.Drawing.Point(166, 3);
            this.lblYes.Margin = new System.Windows.Forms.Padding(3);
            this.lblYes.Name = "lblYes";
            this.lblYes.Size = new System.Drawing.Size(158, 26);
            this.lblYes.TabIndex = 1;
            this.lblYes.Text = "Yes";
            this.lblYes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblYes.Click += new System.EventHandler(this.lblYes_Click);
            this.lblYes.MouseEnter += new System.EventHandler(this.lblYes_MouseEnter);
            this.lblYes.MouseLeave += new System.EventHandler(this.lblYes_MouseLeave);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.tlpFichier, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.tlpPc, 0, 3);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 5;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(327, 133);
            this.tableLayoutPanel3.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(10, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(314, 22);
            this.label1.TabIndex = 6;
            this.label1.Text = "Save this file :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(10, 59);
            this.label2.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(314, 22);
            this.label2.TabIndex = 7;
            this.label2.Text = "From :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tlpFichier
            // 
            this.tlpFichier.ColumnCount = 2;
            this.tlpFichier.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFichier.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFichier.Controls.Add(this.lblFichier, 0, 0);
            this.tlpFichier.Controls.Add(this.lblSize, 1, 0);
            this.tlpFichier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpFichier.Location = new System.Drawing.Point(15, 31);
            this.tlpFichier.Margin = new System.Windows.Forms.Padding(15, 3, 15, 3);
            this.tlpFichier.Name = "tlpFichier";
            this.tlpFichier.RowCount = 1;
            this.tlpFichier.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFichier.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFichier.Size = new System.Drawing.Size(297, 22);
            this.tlpFichier.TabIndex = 8;
            // 
            // lblFichier
            // 
            this.lblFichier.AutoSize = true;
            this.lblFichier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFichier.ForeColor = System.Drawing.Color.White;
            this.lblFichier.Location = new System.Drawing.Point(3, 3);
            this.lblFichier.Margin = new System.Windows.Forms.Padding(3);
            this.lblFichier.Name = "lblFichier";
            this.lblFichier.Size = new System.Drawing.Size(142, 16);
            this.lblFichier.TabIndex = 6;
            this.lblFichier.Text = "lblFichier";
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSize.ForeColor = System.Drawing.Color.White;
            this.lblSize.Location = new System.Drawing.Point(151, 3);
            this.lblSize.Margin = new System.Windows.Forms.Padding(3);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(143, 16);
            this.lblSize.TabIndex = 7;
            this.lblSize.Text = "lblSize";
            // 
            // tlpPc
            // 
            this.tlpPc.ColumnCount = 1;
            this.tlpPc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPc.Controls.Add(this.lblPc, 0, 0);
            this.tlpPc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPc.Location = new System.Drawing.Point(15, 87);
            this.tlpPc.Margin = new System.Windows.Forms.Padding(15, 3, 15, 3);
            this.tlpPc.Name = "tlpPc";
            this.tlpPc.RowCount = 1;
            this.tlpPc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPc.Size = new System.Drawing.Size(297, 22);
            this.tlpPc.TabIndex = 9;
            // 
            // lblPc
            // 
            this.lblPc.AutoSize = true;
            this.lblPc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPc.ForeColor = System.Drawing.Color.White;
            this.lblPc.Location = new System.Drawing.Point(3, 3);
            this.lblPc.Margin = new System.Windows.Forms.Padding(3);
            this.lblPc.Name = "lblPc";
            this.lblPc.Size = new System.Drawing.Size(291, 16);
            this.lblPc.TabIndex = 3;
            this.lblPc.Text = "lblPc";
            // 
            // SaveFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(327, 165);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SaveFile";
            this.Text = "Save this file ?";
            this.Load += new System.EventHandler(this.SaveFile_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tlpFichier.ResumeLayout(false);
            this.tlpFichier.PerformLayout();
            this.tlpPc.ResumeLayout(false);
            this.tlpPc.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SaveFileDialog sfd1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblCancel;
        private System.Windows.Forms.Label lblYes;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tlpFichier;
        private System.Windows.Forms.Label lblFichier;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.TableLayoutPanel tlpPc;
        private System.Windows.Forms.Label lblPc;
    }
}