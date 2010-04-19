namespace engine.classes.forms
{
    partial class ProfileSelector
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
            this._profilesList = new System.Windows.Forms.ListView();
            this._addButton = new System.Windows.Forms.Button();
            this._removeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _profilesList
            // 
            this._profilesList.Location = new System.Drawing.Point(12, 40);
            this._profilesList.Name = "_profilesList";
            this._profilesList.Size = new System.Drawing.Size(231, 383);
            this._profilesList.TabIndex = 0;
            this._profilesList.UseCompatibleStateImageBehavior = false;
            this._profilesList.VirtualMode = true;
            this._profilesList.SelectedIndexChanged += new System.EventHandler(this._profilesList_SelectedIndexChanged);
            // 
            // _addButton
            // 
            this._addButton.Location = new System.Drawing.Point(12, 11);
            this._addButton.Name = "_addButton";
            this._addButton.Size = new System.Drawing.Size(114, 23);
            this._addButton.TabIndex = 1;
            this._addButton.Text = "Add";
            this._addButton.UseVisualStyleBackColor = true;
            this._addButton.Click += new System.EventHandler(this._addButton_Click);
            // 
            // _removeButton
            // 
            this._removeButton.Location = new System.Drawing.Point(132, 12);
            this._removeButton.Name = "_removeButton";
            this._removeButton.Size = new System.Drawing.Size(114, 23);
            this._removeButton.TabIndex = 2;
            this._removeButton.Text = "Remove";
            this._removeButton.UseVisualStyleBackColor = true;
            // 
            // ProfileSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 435);
            this.Controls.Add(this._removeButton);
            this.Controls.Add(this._addButton);
            this.Controls.Add(this._profilesList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ProfileSelector";
            this.Text = "Profile Selector";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView _profilesList;
        private System.Windows.Forms.Button _addButton;
        private System.Windows.Forms.Button _removeButton;
    }
}