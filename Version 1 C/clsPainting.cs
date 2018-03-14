using System;
using System.Windows.Forms;

namespace Version_1_C
{
    [Serializable()] 
    public class clsPainting : clsWork
    {
        private float _Width;
        private float _Height;
        private string _Type;

        [NonSerialized()]
        private static frmPainting _PaintDialog;

        public float Width { get => _Width; set => _Width = value; }
        public float Height { get => _Height; set => _Height = value; }
        public string Type { get => _Type; set => _Type = value; }

        //public override void EditDetails()
        //{
            //if (paintDialog == null)
            //{
            //    paintDialog = new frmPainting();
            //}
            //paintDialog.SetDetails(_Name, _Date, _Value, _Width, _Height, _Type);
            //if(paintDialog.ShowDialog() == DialogResult.OK)
            //{
            //   paintDialog.GetDetails(ref _Name, ref _Date, ref _Value, ref _Width, ref _Height, ref _Type);
            //}

             public override void EditDetails()
        {
            if (_PaintDialog == null)
                _PaintDialog = new frmPainting();
            _PaintDialog.SetDetails(this);
        }

    }
    
}
