namespace com.jds.patheditor.classes.forms
{
    partial class EnterNameForm
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
            this._okButton = new System.Windows.Forms.Button();
            this._profileName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // _okButton
            // 
            this._okButton.Location = new System.Drawing.Point(230, 11);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(41, 23);
            this._okButton.TabIndex = 0;
            this._okButton.Text = "OK";
            this._okButton.UseVisualStyleBackColor = true;
            this._okButton.Click += new System.EventHandler(this._okButton_Click);
            // 
            // _profileName
            // 
            this._profileName.Location = new System.Drawing.Point(12, 14);
            this._profileName.Name = "_profileName";
            this._profileName.Size = new System.Drawing.Size(212, 20);
            this._profileName.TabIndex = 1;
            // 
            // EnterNameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 46);
            this.Controls.Add(this._profileName);
            this.Controls.Add(this._okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EnterNameForm";
            this.Text = "Enter Name";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.TextBox _profileName;
    }
}