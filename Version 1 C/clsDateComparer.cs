using System;
using System.Collections.Generic;

namespace Version_1_C
{
    class clsDateComparer : IComparer<clsWork>
    {
        public int Compare(clsWork X, clsWork Y)
        {
            //clsWork lcWorkX = (clsWork)x;
            //clsWork lcWorkY = (clsWork)y;
            DateTime lcDateX = X.Date;
            DateTime lcDateY = Y.Date;

            return lcDateX.CompareTo(lcDateY);
        }
    }
}
