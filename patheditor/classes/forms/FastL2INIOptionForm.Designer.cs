namespace com.jds.PathEditor.classes.forms
{
    partial class FastL2INIOptionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FastL2INIOptionForm));
            this.HostText = new System.Windows.Forms.TextBox();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.L2Edit = new System.Windows.Forms.RichTextBox();
            this.REfBtn = new System.Windows.Forms.Button();
            this.PortText = new System.Windows.Forms.TextBox();
            this.Host = new System.Windows.Forms.Label();
            this.InetGrop = new System.Windows.Forms.GroupBox();
            this.NetLog = new System.Windows.Forms.CheckBox();
            this.Port = new System.Windows.Forms.Label();
            this.OtherGroup = new System.Windows.Forms.GroupBox();
            this.SeccondWind = new System.Windows.Forms.CheckBox();
            this.TestServer = new System.Windows.Forms.CheckBox();
            this.InetGrop.SuspendLayout();
            this.OtherGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // HostText
            // 
            this.HostText.Location = new System.Drawing.Point(76, 20);
            this.HostText.Name = "HostText";
            this.HostText.Size = new System.Drawing.Size(247, 20);
            this.HostText.TabIndex = 0;
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(11, 679);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(344, 38);
            this.SaveBtn.TabIndex = 1;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // L2Edit
            // 
            this.L2Edit.Location = new System.Drawing.Point(11, 349);
            this.L2Edit.Name = "L2Edit";
            this.L2Edit.ReadOnly = true;
            this.L2Edit.Size = new System.Drawing.Size(345, 308);
            this.L2Edit.TabIndex = 2;
            this.L2Edit.Text = "";
            // 
            // REfBtn
            // 
            this.REfBtn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.REfBtn.Location = new System.Drawing.Point(13, 307);
            this.REfBtn.Name = "REfBtn";
            this.REfBtn.Size = new System.Drawing.Size(343, 27);
            this.REfBtn.TabIndex = 3;
            this.REfBtn.Text = "Refresh";
            this.REfBtn.UseVisualStyleBackColor = true;
            this.REfBtn.Click += new System.EventHandler(this.REfBtn_Click);
            // 
            // PortText
            // 
            this.PortText.Location = new System.Drawing.Point(76, 63);
            this.PortText.Name = "PortText";
            this.PortText.Size = new System.Drawing.Size(247, 20);
            this.PortText.TabIndex = 4;
            // 
            // Host
            // 
            this.Host.AutoSize = true;
            this.Host.Location = new System.Drawing.Point(12, 27);
            this.Host.Name = "Host";
            this.Host.Size = new System.Drawing.Size(32, 13);
            this.Host.TabIndex = 5;
            this.Host.Text = "Host:";
            // 
            // InetGrop
            // 
            this.InetGrop.Controls.Add(this.NetLog);
            this.InetGrop.Controls.Add(this.Port);
            this.InetGrop.Controls.Add(this.Host);
            this.InetGrop.Controls.Add(this.PortText);
            this.InetGrop.Controls.Add(this.HostText);
            this.InetGrop.Location = new System.Drawing.Point(11, 26);
            this.InetGrop.Name = "InetGrop";
            this.InetGrop.Size = new System.Drawing.Size(345, 133);
            this.InetGrop.TabIndex = 6;
            this.InetGrop.TabStop = false;
            this.InetGrop.Text = "Internet settings";
            // 
            // NetLog
            // 
            this.NetLog.AutoSize = true;
            this.NetLog.Location = new System.Drawing.Point(15, 101);
            this.NetLog.Name = "NetLog";
            this.NetLog.Size = new System.Drawing.Size(189, 17);
            this.NetLog.TabIndex = 8;
            this.NetLog.Text = "Use Network Log in Network.log ?";
            this.NetLog.UseVisualStyleBackColor = true;
            // 
            // Port
            // 
            this.Port.AutoSize = true;
            this.Port.Location = new System.Drawing.Point(12, 70);
            this.Port.Name = "Port";
            this.Port.Size = new System.Drawing.Size(29, 13);
            this.Port.TabIndex = 6;
            this.Port.Text = "Port:";
            // 
            // OtherGroup
            // 
            this.OtherGroup.Controls.Add(this.SeccondWind);
            this.OtherGroup.Controls.Add(this.TestServer);
            this.OtherGroup.Location = new System.Drawing.Point(11, 194);
            this.OtherGroup.Name = "OtherGroup";
            this.OtherGroup.Size = new System.Drawing.Size(345, 100);
            this.OtherGroup.TabIndex = 7;
            this.OtherGroup.TabStop = false;
            this.OtherGroup.Text = "Other";
            // 
            // SeccondWind
            // 
            this.SeccondWind.AutoSize = true;
            this.SeccondWind.Location = new System.Drawing.Point(14, 65);
            this.SeccondWind.Name = "SeccondWind";
            this.SeccondWind.Size = new System.Drawing.Size(110, 17);
            this.SeccondWind.TabIndex = 1;
            this.SeccondWind.Text = "Allow two window";
            this.SeccondWind.UseVisualStyleBackColor = true;
            // 
            // TestServer
            // 
            this.TestServer.AutoSize = true;
            this.TestServer.Location = new System.Drawing.Point(15, 30);
            this.TestServer.Name = "TestServer";
            this.TestServer.Size = new System.Drawing.Size(81, 17);
            this.TestServer.TabIndex = 0;
            this.TestServer.Text = "Test Server";
            this.TestServer.UseVisualStyleBackColor = true;
            // 
            // FastL2INIOptionForm
            // 
            this.AcceptButton = this.SaveBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 729);
            this.Controls.Add(this.OtherGroup);
            this.Controls.Add(this.InetGrop);
            this.Controls.Add(this.REfBtn);
            this.Controls.Add(this.L2Edit);
            this.Controls.Add(this.SaveBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FastL2INIOptionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fast l2.ini Option";
            this.Load += new System.EventHandler(this.FastL2INIOptionForm_Load);
            this.InetGrop.ResumeLayout(false);
            this.InetGrop.PerformLayout();
            this.OtherGroup.ResumeLayout(false);
            this.OtherGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox HostText;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.RichTextBox L2Edit;
        private System.Windows.Forms.Button REfBtn;
        private System.Windows.Forms.TextBox PortText;
        private System.Windows.Forms.Label Host;
        private System.Windows.Forms.GroupBox InetGrop;
        private System.Windows.Forms.Label Port;
        private System.Windows.Forms.CheckBox NetLog;
        private System.Windows.Forms.GroupBox OtherGroup;
        private System.Windows.Forms.CheckBox TestServer;
        private System.Windows.Forms.CheckBox SeccondWind;
    }
}