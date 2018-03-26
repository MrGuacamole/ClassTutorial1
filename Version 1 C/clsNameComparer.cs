using System;
using System.Collections.Generic;

namespace Version_1_C
{
    
        
        sealed class clsNameComparer : IComparer<clsWork>
        {
        public static readonly clsNameComparer Instance = new clsNameComparer();
        public int Compare(clsWork X, clsWork Y)
            {
                //clsWork workClassX = (clsWork)x;
                //clsWork workClassY = (clsWork)y;
                string lcNameX = X.Name;
                string lcNameY = Y.Name;

                return lcNameX.CompareTo(lcNameY);
            }
        }
    
  
}
