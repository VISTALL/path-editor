namespace com.jds.PathEditor.classes.forms
{
    partial class EditTextForm
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this._saveBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(744, 472);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // _saveBtn
            // 
            this._saveBtn.Location = new System.Drawing.Point(681, 490);
            this._saveBtn.Name = "_saveBtn";
            this._saveBtn.Size = new System.Drawing.Size(75, 23);
            this._saveBtn.TabIndex = 1;
            this._saveBtn.Text = "Save";
            this._saveBtn.UseVisualStyleBackColor = true;
            this._saveBtn.Click += new System.EventHandler(this._saveBtn_Click);
            // 
            // EditTextForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 525);
            this.Controls.Add(this._saveBtn);
            this.Controls.Add(this.richTextBox1);
            this.Name = "EditTextForm";
            this.Text = "Edit Text";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button _saveBtn;
    }
}