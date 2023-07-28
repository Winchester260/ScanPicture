namespace ScanPicture
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnScan = new System.Windows.Forms.Button();
            this.txtScanErg = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lLabelOpenPicture = new System.Windows.Forms.LinkLabel();
            this.btnColor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(12, 21);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(79, 34);
            this.btnScan.TabIndex = 0;
            this.btnScan.Text = "ScanPicture";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // txtScanErg
            // 
            this.txtScanErg.Location = new System.Drawing.Point(12, 100);
            this.txtScanErg.Name = "txtScanErg";
            this.txtScanErg.Size = new System.Drawing.Size(157, 23);
            this.txtScanErg.TabIndex = 1;
            this.txtScanErg.Text = "#";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // lLabelOpenPicture
            // 
            this.lLabelOpenPicture.AutoSize = true;
            this.lLabelOpenPicture.Location = new System.Drawing.Point(55, 71);
            this.lLabelOpenPicture.Name = "lLabelOpenPicture";
            this.lLabelOpenPicture.Size = new System.Drawing.Size(73, 15);
            this.lLabelOpenPicture.TabIndex = 2;
            this.lLabelOpenPicture.TabStop = true;
            this.lLabelOpenPicture.Text = "OpenPicture";
            this.lLabelOpenPicture.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lLabelOpenPicture_LinkClicked);
            // 
            // btnColor
            // 
            this.btnColor.Location = new System.Drawing.Point(97, 21);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(79, 34);
            this.btnColor.TabIndex = 3;
            this.btnColor.Text = "ScanColor";
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(183, 145);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.lLabelOpenPicture);
            this.Controls.Add(this.txtScanErg);
            this.Controls.Add(this.btnScan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Bot";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnScan;
        private TextBox txtScanErg;
        private OpenFileDialog openFileDialog1;
        private LinkLabel linkLabel1;
        private LinkLabel lLabelOpenPicture;
        private Button btnColor;
    }
}