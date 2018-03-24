using System;
using System.Collections.Generic;

namespace Version_1_C
{
    [Serializable()] 
    public class clsWorksList : List<clsWork>
    {
        private byte sortOrder;
        private static clsNameComparer _NameComparer = new clsNameComparer();
        private static clsDateComparer _DateComparer = new clsDateComparer();

        public byte SortOrder { get => sortOrder; set => sortOrder = value; }

        public void AddWork(char lcReply)
        {
            //char lcReply;
            //InputBox inputBox = new InputBox("Enter P for Painting, S for Sculpture and H for Photograph");
            ////inputBox.ShowDialog();
            ////if (inputBox.getAction() == true)
            //if (inputBox.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            
                clsWork lcWork = clsWork.CheckWork(lcReply);
                if (lcWork != null)
                {
                    Add(lcWork);
                }
            //}
            //else
            //{
            //    inputBox.Close();
            //}
            
        }
       

        public void DeleteWork(int prIndex)
        {
            if (prIndex >= 0 && prIndex < this.Count)
            {
               
                    this.RemoveAt(prIndex);
                
            }
        }
        
        public void EditWork(int prIndex)
        {
            if (prIndex >= 0 && prIndex < this.Count)
            {
                clsWork lcWork = (clsWork)this[prIndex];
                lcWork.EditDetails();
            }
          
        }

        public decimal GetTotalValue()
        {
            decimal lcTotal = 0;
            foreach (clsWork lcWork in this)
            {
                lcTotal += lcWork.Value;
            }
            return lcTotal;
        }

         public void SortByName()
         {
             Sort(_NameComparer);
         }
    
        public void SortByDate()
        {
            Sort(_DateComparer);
        }
    }
}
