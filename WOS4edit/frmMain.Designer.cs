namespace WOS4edit
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnOpen = new System.Windows.Forms.Button();
            this.OFD = new System.Windows.Forms.OpenFileDialog();
            this.cbSetting = new System.Windows.Forms.ComboBox();
            this.lblType = new System.Windows.Forms.Label();
            this.tbValue = new System.Windows.Forms.TextBox();
            this.btnSet = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblHelp = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(12, 12);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "&Open...";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // OFD
            // 
            this.OFD.DefaultExt = "save";
            this.OFD.Filter = "WOS4 Savegame|*.save|All files|*.*";
            this.OFD.Title = "Select savegame";
            // 
            // cbSetting
            // 
            this.cbSetting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSetting.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSetting.FormattingEnabled = true;
            this.cbSetting.Location = new System.Drawing.Point(12, 41);
            this.cbSetting.Name = "cbSetting";
            this.cbSetting.Size = new System.Drawing.Size(428, 23);
            this.cbSetting.TabIndex = 1;
            this.cbSetting.SelectedIndexChanged += new System.EventHandler(this.cbSetting_SelectedIndexChanged);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(9, 79);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(102, 15);
            this.lblType.TabIndex = 2;
            this.lblType.Text = "- Please open file -";
            // 
            // tbValue
            // 
            this.tbValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbValue.Location = new System.Drawing.Point(12, 107);
            this.tbValue.Name = "tbValue";
            this.tbValue.Size = new System.Drawing.Size(374, 23);
            this.tbValue.TabIndex = 3;
            // 
            // btnSet
            // 
            this.btnSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSet.Location = new System.Drawing.Point(392, 107);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(48, 23);
            this.btnSet.TabIndex = 4;
            this.btnSet.Text = "&Set";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblHelp);
            this.groupBox1.Location = new System.Drawing.Point(12, 136);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(428, 125);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Setting Help";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(365, 270);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "S&ave";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblHelp
            // 
            this.lblHelp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHelp.Location = new System.Drawing.Point(3, 19);
            this.lblHelp.Name = "lblHelp";
            this.lblHelp.Size = new System.Drawing.Size(422, 103);
            this.lblHelp.TabIndex = 6;
            this.lblHelp.Text = "If help.txt is present, this shows some information regarding the currently selec" +
                "ted setting";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 305);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSet);
            this.Controls.Add(this.tbValue);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.cbSetting);
            this.Controls.Add(this.btnOpen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "WOS4 savegame editor";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.OpenFileDialog OFD;
        private System.Windows.Forms.ComboBox cbSetting;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.TextBox tbValue;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblHelp;
    }
}