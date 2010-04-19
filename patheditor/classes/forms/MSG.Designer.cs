namespace com.jds.PathEditor.classes.forms

{
    partial class MSG
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
            this.TextError = new System.Windows.Forms.RichTextBox();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TextError
            // 
            this.TextError.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.TextError.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextError.Location = new System.Drawing.Point(8, 12);
            this.TextError.Name = "TextError";
            this.TextError.Size = new System.Drawing.Size(124, 38);
            this.TextError.TabIndex = 0;
            this.TextError.Text = "";
            // 
            // CloseBtn
            // 
            this.CloseBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.CloseBtn.Location = new System.Drawing.Point(8, 58);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(124, 28);
            this.CloseBtn.TabIndex = 1;
            this.CloseBtn.Text = "Close";
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // MSG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(139, 93);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.TextError);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MSG";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Error";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox TextError;
        private System.Windows.Forms.Button CloseBtn;
    }
}