﻿using QlyBaiGuiXe.GUI.BaiXe;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QlyBaiGuiXe.GUI
{
    public partial class ucBaiXe : UserControl
    {
        public ucBaiXe()
        {
            InitializeComponent();
        }

        private void btnBTTTve_Click(object sender, EventArgs e)
        {
            //neu chon trong dgv

            //neu ko chon
            Panel mainPanel = this.Parent as Panel;
            mainUI mainForm = mainPanel.Parent as mainUI;

            mainForm.showBlur();
            fBTTTve newForm = new fBTTTve();
            newForm.ShowDialog();

            mainForm.closeBlur();
        }
    }
}
