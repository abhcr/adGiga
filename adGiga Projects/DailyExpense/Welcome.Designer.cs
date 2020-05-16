namespace ShopKeeper
{
    partial class Welcome
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Welcome));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ok = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.dataSelect = new System.Windows.Forms.LinkLabel();
            this.helpTips = new System.Windows.Forms.ToolTip(this.components);
            this.message = new System.Windows.Forms.Label();
            this.cancel = new System.Windows.Forms.Button();
            this.versionInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(97, 14);
            this.textBox1.MaxLength = 20;
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '*';
            this.textBox1.Size = new System.Drawing.Size(329, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.UseSystemPasswordChar = true;
            // 
            // ok
            // 
            this.ok.Location = new System.Drawing.Point(270, 100);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(75, 23);
            this.ok.TabIndex = 1;
            this.ok.Text = "O&k";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Enter Password:";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "*.mdb";
            this.openFileDialog.Filter = "MDB Data Files|*.mdb";
            this.openFileDialog.RestoreDirectory = true;
            this.openFileDialog.Title = "Select a data file";
            // 
            // dataSelect
            // 
            this.dataSelect.AutoSize = true;
            this.dataSelect.Location = new System.Drawing.Point(16, 57);
            this.dataSelect.Name = "dataSelect";
            this.dataSelect.Size = new System.Drawing.Size(86, 13);
            this.dataSelect.TabIndex = 3;
            this.dataSelect.TabStop = true;
            this.dataSelect.Text = "Select a data file";
            this.helpTips.SetToolTip(this.dataSelect, "Click here for selecting a new data file");
            this.dataSelect.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.dataSelect_LinkClicked);
            // 
            // helpTips
            // 
            this.helpTips.IsBalloon = true;
            this.helpTips.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.helpTips.ToolTipTitle = "Tip:";
            // 
            // message
            // 
            this.message.AutoSize = true;
            this.message.ForeColor = System.Drawing.Color.DarkRed;
            this.message.Location = new System.Drawing.Point(16, 74);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(0, 13);
            this.message.TabIndex = 6;
            this.helpTips.SetToolTip(this.message, "Please check if network is Ok.\r\n-OR-\r\nWas the data file moved from the above loca" +
                    "tion?");
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(351, 100);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 4;
            this.cancel.Text = "&Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // versionInfo
            // 
            this.versionInfo.AutoSize = true;
            this.versionInfo.Location = new System.Drawing.Point(13, 110);
            this.versionInfo.Name = "versionInfo";
            this.versionInfo.Size = new System.Drawing.Size(35, 13);
            this.versionInfo.TabIndex = 5;
            this.versionInfo.Text = "label2";
            // 
            // Welcome
            // 
            this.AcceptButton = this.ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 134);
            this.ControlBox = false;
            this.Controls.Add(this.message);
            this.Controls.Add(this.versionInfo);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.dataSelect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Welcome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Welcome";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.LinkLabel dataSelect;
        private System.Windows.Forms.ToolTip helpTips;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Label versionInfo;
        private System.Windows.Forms.Label message;
    }
}