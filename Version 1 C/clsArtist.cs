using System;

namespace Version_1_C
{
    [Serializable()] 
    public class clsArtist
    {
        private string name;
        private string speciality;
        private string phone;
        
        private decimal _TotalValue;

        private clsWorksList _WorksList;
        private clsArtistList _ArtistList;
        
        private static frmArtist artistDialog = new frmArtist();

        public string Name { get => name; set => name = value; }
        public string Speciality { get => speciality; set => speciality = value; }
        public string Phone { get => phone; set => phone = value; }
        public decimal TotalValue { get => _TotalValue; set => _TotalValue = value; }
        public clsWorksList WorksList { get => _WorksList; set => _WorksList = value; }
        public clsArtistList ArtistList { get => _ArtistList; set => _ArtistList = value; }

        public clsArtist(clsArtistList prArtistList)
        {
            WorksList = new clsWorksList();
            ArtistList = prArtistList;
            EditDetails();
        }
        
        public void EditDetails()
        {
            artistDialog.SetDetails(this);
            TotalValue = WorksList.GetTotalValue();
            
        }

        public bool IsDuplicate(string prArtistName)
        {
            return _ArtistList.ContainsKey(prArtistName);
        }

        //public string GetKey()
        //{
        //    return name;
        //}

        //public decimal GetWorksValue()
        //{
        //    return TotalValue;
        //}
    }
}
