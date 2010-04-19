using System;
using System.Windows.Forms;
using com.jds.PathEditor.classes.gui;

namespace com.jds.PathEditor.classes.forms
{
	partial class EditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditForm));
            this._listView = new System.Windows.Forms.ListView();
            this._propertyGid = new System.Windows.Forms.PropertyGrid();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.searchColumn = new System.Windows.Forms.ComboBox();
            this.searchText = new System.Windows.Forms.TextBox();
            this._removeBtn = new JButton();
            this._saveBtn = new JButton();
            this._addBtn = new JButton();
            this.searchBtn = new JButton();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _listView
            // 
            this._listView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this._listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._listView.FullRowSelect = true;
            this._listView.HideSelection = false;
            this._listView.LabelWrap = false;
            this._listView.Location = new System.Drawing.Point(0, 0);
            this._listView.MultiSelect = false;
            this._listView.Name = "_listView";
            this._listView.Size = new System.Drawing.Size(379, 472);
            this._listView.TabIndex = 1;
            this._listView.UseCompatibleStateImageBehavior = false;
            this._listView.View = System.Windows.Forms.View.Details;
            this._listView.VirtualMode = true;
            // 
            // _propertyGid
            // 
            this._propertyGid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._propertyGid.Location = new System.Drawing.Point(0, 0);
            this._propertyGid.Name = "_propertyGid";
            this._propertyGid.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this._propertyGid.Size = new System.Drawing.Size(360, 472);
            this._propertyGid.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this._listView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this._propertyGid);
            this.splitContainer1.Size = new System.Drawing.Size(743, 472);
            this.splitContainer1.SplitterDistance = 379;
            this.splitContainer1.TabIndex = 3;
            // 
            // searchColumn
            // 
            this.searchColumn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | AnchorStyles.Right)));
            this.searchColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.searchColumn.FormattingEnabled = true;
            this.searchColumn.Location = new System.Drawing.Point(244, 524);
            this.searchColumn.Name = "searchColumn";
            this.searchColumn.Size = new System.Drawing.Size(227, 21);
            this.searchColumn.TabIndex = 5;
            // 
            // searchText
            // 
            this.searchText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | AnchorStyles.Right)));
            this.searchText.Location = new System.Drawing.Point(244, 492);
            this.searchText.Name = "searchText";
            this.searchText.Size = new System.Drawing.Size(227, 20);
            this.searchText.TabIndex = 1;
            // 
            // _removeBtn
            // 
            this._removeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._removeBtn.DescriptionText = "";
            this._removeBtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._removeBtn.HeaderText = "Remove";
            this._removeBtn.Location = new System.Drawing.Point(106, 495);
            this._removeBtn.Name = "_removeBtn";
            this._removeBtn.Size = new System.Drawing.Size(83, 50);
            this._removeBtn.TabIndex = 6;
            this._removeBtn.ImageScalingSize = new System.Drawing.Size(16, 16); 
            this._removeBtn.Image = Resources.remove;
            this._removeBtn.Click += new System.EventHandler(this.removeBtn_Click);
            // 
            // _saveBtn
            // 
            this._saveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._saveBtn.DescriptionText = "";
            this._saveBtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._saveBtn.HeaderText = "Save";
            this._saveBtn.Location = new System.Drawing.Point(625, 495);
            this._saveBtn.Name = "_saveBtn";
            this._saveBtn.Size = new System.Drawing.Size(106, 50);
            this._saveBtn.TabIndex = 7;
            this._saveBtn.ImageScalingSize = new System.Drawing.Size(16, 16); 
            this._saveBtn.Image = Resources.SAVE;
            this._saveBtn.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // _addBtn
            // 
            this._addBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._addBtn.DescriptionText = "";
            this._addBtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._addBtn.HeaderText = "Add";
            this._addBtn.Location = new System.Drawing.Point(12, 495);
            this._addBtn.Name = "_addBtn";
            this._addBtn.Size = new System.Drawing.Size(83, 50);
            this._addBtn.TabIndex = 8;
            this._addBtn.ImageScalingSize = new System.Drawing.Size(16, 16); 
            this._addBtn.Image = Resources.add;
            this._addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // searchBtn
            // 
            this.searchBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.searchBtn.DescriptionText = "";
            this.searchBtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.searchBtn.HeaderText = "Search";
            this.searchBtn.Location = new System.Drawing.Point(513, 495);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(106, 50);
            this.searchBtn.TabIndex = 9;
            this.searchBtn.Image = Resources.find;
            this.searchBtn.ImageScalingSize = new System.Drawing.Size(16, 16); 
            this.searchBtn.Click += new EventHandler(_seatchBtn_Click);
            this.searchBtn.Enabled = false;
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 554);
            this.Controls.Add(this.searchBtn);
            this.Controls.Add(this._addBtn);
            this.Controls.Add(this.searchColumn);
            this.Controls.Add(this._saveBtn);
            this.Controls.Add(this.searchText);
            this.Controls.Add(this._removeBtn);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "EditForm";
            this.Text = "Edit Form";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.ListView _listView;
        private System.Windows.Forms.SplitContainer splitContainer1;
        public System.Windows.Forms.PropertyGrid _propertyGid;
        private System.Windows.Forms.TextBox searchText;
        private System.Windows.Forms.ComboBox searchColumn;
        private JButton _removeBtn;
        private JButton _saveBtn;
        private JButton _addBtn;
        private JButton searchBtn;
	}
}