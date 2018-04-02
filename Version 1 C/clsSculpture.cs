using System;
using System.Windows.Forms;

namespace Version_1_C
{
    [Serializable()] 
    public class clsSculpture : clsWork
    {
        public delegate void LoadSculptureFormDelegate(clsSculpture prSculpture);
        public static LoadSculptureFormDelegate LoadSculptureForm;

        private static frmSculpture _SculptureDialog;
        private float _Weight;
        private string _Material;

        public float Weight { get => _Weight; set => _Weight = value; }
        public string Material { get => _Material; set => _Material = value; }

        public override void EditDetails()
        {
            LoadSculptureForm(this);
            //if (_SculptureDialog == null)
            //    _SculptureDialog = frmSculpture.Instance;
            //_SculptureDialog.SetDetails(this);
        }
    }
}
