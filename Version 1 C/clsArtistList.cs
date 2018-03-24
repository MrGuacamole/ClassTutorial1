using System;
using System.Collections.Generic;


namespace Version_1_C
{
    [Serializable()] 

    public class clsArtistList : SortedList<string, clsArtist>
    {
        private const string fileName = "save2.xml";
        public void EditArtist(string prKey)
        {
            clsArtist lcArtist;
            lcArtist = this[prKey];
            if (lcArtist != null)
                lcArtist.EditDetails();
            else
                throw new Exception("Sorry no artist by this name");
               
        }

        public void NewArtist()
        {
            clsArtist lcArtist = new clsArtist(this);

            if (lcArtist.Name != "")
            {
                try {
                    Add(lcArtist.Name, lcArtist);
                }
                catch
                {
                    throw new Exception("Duplicate Key!");
                }

            }


            else {
                throw new Exception("Artist Name empty");
            }
        }
        
        public decimal GetTotalValue()
        {
            decimal lcTotal = 0;
            foreach (clsArtist lcArtist in Values)
            {
                lcTotal += lcArtist.TotalValue;
            }
            return lcTotal;
        }

        public void Save()
        {
            try
            {
                System.IO.FileStream lcFileStream = new System.IO.FileStream(fileName, System.IO.FileMode.Create);
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter lcFormatter =
                    new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                lcFormatter.Serialize(lcFileStream, this);
                lcFileStream.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "File Retrieve Error");
            }
        }

        public static clsArtistList Retrieve()
        {
            clsArtistList lcArtistList;

            try
            {

                System.IO.FileStream lcFileStream = new System.IO.FileStream(fileName, System.IO.FileMode.Open);
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter lcFormatter =
                    new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                lcArtistList = (clsArtistList)lcFormatter.Deserialize(lcFileStream);
                lcFileStream.Close();
            }

            catch(Exception ex)
            {
                lcArtistList = new clsArtistList();
                throw new Exception(ex.Message + "File Retrieve Error");
                
            }

            return lcArtistList;
        }
    }
}
