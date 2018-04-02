using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Version_1_C
{
    public sealed partial class frmPainting : Version_1_C.frmWork
    {
        public static readonly frmPainting Instance = new frmPainting();

        //private static readonly frmPainting _Instance = new frmPainting();

        //public static frmPainting Instance => _Instance;

        private frmPainting()
        {
            InitializeComponent();
        }

        protected override void updateForm()
        {
            base.updateForm();
            clsPainting lcWork = (clsPainting)_Work;
            txtWidth.Text = lcWork.Width.ToString();
            txtHeight.Text = lcWork.Height.ToString();
            txtType.Text = lcWork.Type;

        }

        protected override void pushData()
        {
            base.pushData();
            clsPainting lcWork = (clsPainting)_Work;
            lcWork.Width = Single.Parse(txtWidth.Text);
            lcWork.Height = Single.Parse(txtHeight.Text);
            lcWork.Type = txtType.Text;
        }

        public static void Run(clsPainting prPainting)
        {
            Instance.SetDetails(prPainting);
        }

        //public virtual void SetDetails(string prName, DateTime prDate, decimal prValue,
        //                               float prWidth, float prHeight, string prType)
        //{
        //    base.SetDetails(prName, prDate, prValue);
        //    txtWidth.Text = Convert.ToString(prWidth);
        //    txtHeight.Text = Convert.ToString(prHeight);
        //    txtType.Text = prType;
        //}

        //public virtual void GetDetails(ref string prName, ref DateTime prDate, ref decimal prValue,
        //                               ref float prWidth, ref float prHeight, ref string prType)
        //{
        //    base.GetDetails(ref prName, ref prDate, ref prValue);
        //    prWidth = Convert.ToSingle(txtWidth.Text);
        //    prHeight = Convert.ToSingle(txtHeight.Text);
        //    prType = txtType.Text;
        //}
    }
}

