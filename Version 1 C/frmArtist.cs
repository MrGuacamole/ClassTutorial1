using System;
//using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Version_1_C
{
    public partial class frmArtist : Form
    {
        public frmArtist()
        {
            InitializeComponent();
        }

        private clsArtist _Artist;
        //private clsArtistList _ArtistList;
        private clsWorksList _WorksList;
        //private byte sortOrder; // 0 = Name, 1 = Date

        private void updateForm()
        {
            txtName.Text = _Artist.Name;
            txtSpeciality.Text = _Artist.Speciality;
            txtPhone.Text = _Artist.Phone;
          //  _ArtistList = _Artist.ArtistList;
            _WorksList = _Artist.WorksList;
            //sortOrder = _WorksList.SortOrder;
        }
        private void pushData()
        {
            _Artist.Name = txtName.Text;
            _Artist.Speciality = txtSpeciality.Text;
            _Artist.Phone = txtPhone.Text;
           // _WorksList.SortOrder = sortOrder;
        }


        private void UpdateDisplay()
        {
            txtName.Enabled = txtName.Text == "";
            if (_WorksList.SortOrder == 0)
            {
                _WorksList.SortByName();
                rbByName.Checked = true;
            }
            else
            {
                _WorksList.SortByDate();
                rbByDate.Checked = true;
            }

            lstWorks.DataSource = null;
            lstWorks.DataSource = _WorksList;
            lblTotal.Text = Convert.ToString(_WorksList.GetTotalValue());
        }

        public void SetDetails(clsArtist prArtist)
        {

            _Artist = prArtist;
            updateForm();
            UpdateDisplay();
            ShowDialog();
        }

        //public void GetDetails(ref string prName, ref string prSpeciality, ref string prPhone)
        //{
        //    prName = txtName.Text;
        //    prSpeciality = txtSpeciality.Text;
        //    prPhone = txtPhone.Text;
        //    _WorksList.SortOrder = sortOrder;
        //}

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstWorks.SelectedIndex > -1)
            {
                DialogResult result = MessageBox.Show("Are you sure?", "Deleting work", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    _WorksList.DeleteWork(lstWorks.SelectedIndex);
                    UpdateDisplay();
                }
               
            }
            else
            {
                MessageBox.Show("Unable to Delete, No Work Selected");
            }

            
           
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
           
                char lcReply;
                InputBox inputBox = new InputBox("Enter P for Painting, S for Sculpture and H for Photograph");
                //inputBox.ShowDialog();
                //if (inputBox.getAction() == true)
                if (inputBox.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    lcReply = Convert.ToChar(inputBox.getAnswer());
                    _WorksList.AddWork(lcReply);
                    UpdateDisplay();
                }
                
                else
                {
                    inputBox.Close();
                }

            }
            
            
        

        private void btnClose_Click(object sender, EventArgs e)
        {
            pushData();

            if (isValid())
            {
                DialogResult = DialogResult.OK;
            }
        }

        public virtual Boolean isValid()
        {
            if (txtName.Enabled && txtName.Text != "")
                if (_Artist.IsDuplicate(txtName.Text))
                {
                    MessageBox.Show("Artist with that name already exists!");
                    return false;
                }
                else
                    return true;
            else
                return true;
        }

        private void lstWorks_DoubleClick(object sender, EventArgs e)
        {
            int lcIndex = lstWorks.SelectedIndex;
            if (lcIndex > -1)
            {
                _WorksList.EditWork(lcIndex);
                UpdateDisplay();
            }
            else
            {
                MessageBox.Show("Sorry no work selected");
            }
        }

        private void rbByDate_CheckedChanged(object sender, EventArgs e)
        {
            _WorksList.SortOrder = Convert.ToByte(rbByDate.Checked);
            UpdateDisplay();
        }

    }
}