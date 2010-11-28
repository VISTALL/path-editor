namespace com.jds.PathEditor.classes.forms
{
    partial class MergeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MergeForm));
            this._fieldNames = new System.Windows.Forms.ComboBox();
            this._keyParameter = new System.Windows.Forms.Label();
            this._updateFieldNames = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this._updateButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this._statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this._secondKey = new System.Windows.Forms.CheckBox();
            this._secondKeyList = new System.Windows.Forms.ComboBox();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _fieldNames
            // 
            this._fieldNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._fieldNames.FormattingEnabled = true;
            this._fieldNames.Location = new System.Drawing.Point(107, 8);
            this._fieldNames.Name = "_fieldNames";
            this._fieldNames.Size = new System.Drawing.Size(220, 21);
            this._fieldNames.TabIndex = 0;
            // 
            // _keyParameter
            // 
            this._keyParameter.AutoSize = true;
            this._keyParameter.Location = new System.Drawing.Point(21, 11);
            this._keyParameter.Name = "_keyParameter";
            this._keyParameter.Size = new System.Drawing.Size(78, 13);
            this._keyParameter.TabIndex = 1;
            this._keyParameter.Text = "Key parameter:";
            // 
            // _updateFieldNames
            // 
            this._updateFieldNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._updateFieldNames.FormattingEnabled = true;
            this._updateFieldNames.Location = new System.Drawing.Point(107, 93);
            this._updateFieldNames.Name = "_updateFieldNames";
            this._updateFieldNames.Size = new System.Drawing.Size(220, 21);
            this._updateFieldNames.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Update parameter:";
            // 
            // _updateButton
            // 
            this._updateButton.Location = new System.Drawing.Point(333, 8);
            this._updateButton.Name = "_updateButton";
            this._updateButton.Size = new System.Drawing.Size(105, 44);
            this._updateButton.TabIndex = 5;
            this._updateButton.Text = "Update";
            this._updateButton.UseVisualStyleBackColor = true;
            this._updateButton.Click += new System.EventHandler(this._updateButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._statusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 139);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(446, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // _statusLabel
            // 
            this._statusLabel.Name = "_statusLabel";
            this._statusLabel.Size = new System.Drawing.Size(0, 17);
            this._statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _secondKey
            // 
            this._secondKey.AutoSize = true;
            this._secondKey.Location = new System.Drawing.Point(24, 35);
            this._secondKey.Name = "_secondKey";
            this._secondKey.Size = new System.Drawing.Size(123, 17);
            this._secondKey.TabIndex = 7;
            this._secondKey.Text = "Enable second key?";
            this._secondKey.UseVisualStyleBackColor = true;
            this._secondKey.CheckedChanged += new System.EventHandler(this._secondKey_CheckedChanged);
            // 
            // _secondKeyList
            // 
            this._secondKeyList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._secondKeyList.Enabled = false;
            this._secondKeyList.FormattingEnabled = true;
            this._secondKeyList.Location = new System.Drawing.Point(107, 58);
            this._secondKeyList.Name = "_secondKeyList";
            this._secondKeyList.Size = new System.Drawing.Size(220, 21);
            this._secondKeyList.TabIndex = 8;
            // 
            // MergeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 161);
            this.Controls.Add(this._secondKeyList);
            this.Controls.Add(this._secondKey);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this._updateButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._updateFieldNames);
            this.Controls.Add(this._keyParameter);
            this.Controls.Add(this._fieldNames);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MergeForm";
            this.Text = "MergeForm";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox _fieldNames;
        private System.Windows.Forms.Label _keyParameter;
        private System.Windows.Forms.ComboBox _updateFieldNames;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button _updateButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel _statusLabel;
        private System.Windows.Forms.CheckBox _secondKey;
        private System.Windows.Forms.ComboBox _secondKeyList;
    }
}