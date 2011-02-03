using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.jds.PathEditor.classes.client;
using com.jds.PathEditor.classes.gui;
using com.jds.PathEditor.classes.services;

namespace com.jds.PathEditor.classes.forms
{
    public partial class SelectDialog : Form
    {
        public const int DIFF = 10;

        public const int WIDTH_BUTTON = 200;
        public const int HEIGHT_BUTTON = 50;

        public SelectDialog()
        {
            InitializeComponent();
            Array a = Enum.GetValues(typeof(DatVersion));

            int point = DIFF;
            for(int i = 0; i < a.Length; i++)
            {
                DatVersion f = (DatVersion)a.GetValue(i);

                JButton b = new JButton();
                b.DescriptionText = "";
                b.Font = new Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                b.HeaderText = Enum.GetName(typeof(DatVersion), f).Replace("__", "/").Replace("_", " ");
                b.ImageScalingSize = new System.Drawing.Size(16, 16);

                b.Location = new System.Drawing.Point(DIFF, point);
                point += HEIGHT_BUTTON + DIFF;
                b.Size = new Size(WIDTH_BUTTON, HEIGHT_BUTTON);
                b.TabIndex = i;
                b.Tag = f;
                b.Click += new EventHandler(b_Click);
                Controls.Add(b);
              
            }
            point += DIFF * 2;

            Size = new Size(WIDTH_BUTTON + DIFF * 2, point);
        }

        void b_Click(object sender, EventArgs e)
        {
            JButton b = (JButton)sender;
            RConfig.Instance.DatVersionAsEnum = (DatVersion)b.Tag;
            Close();
        }
    }
}
