using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Version_1_C
{
    public sealed partial class frmSculpture : Version_1_C.frmWork
    {
        public static readonly frmSculpture Instance = new frmSculpture();


        private frmSculpture()
        {
            InitializeComponent();
        }

        protected override void updateForm()
        {
            base.updateForm();
            clsSculpture lcWork = (clsSculpture)_Work;
            txtMaterial.Text = lcWork.Material;
            txtWeight.Text = Convert.ToString(lcWork.Weight);
        }
        protected override void pushData()
        {
            base.pushData();
            clsSculpture lcWork = (clsSculpture)_Work;
            lcWork.Material = txtMaterial.Text;
            lcWork.Weight = Single.Parse(txtWeight.Text);
        }

    }
}

