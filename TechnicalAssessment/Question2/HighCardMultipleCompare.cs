using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Question2
{
    public class HighCardMultipleCompare : IComparer<Card[]>
    {
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        #region Implement IComparer
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        //=====================================================================
        public int Compare([AllowNull] Card[] x, [AllowNull] Card[] y)
        {
            if (x == null && y == null)
                return 0;
            else if (x == null)
                return -1;
            else if (y == null)
                return 1;

            if (x.Length > y.Length)
                return -1;
            if (x.Length < y.Length)
                return 1;

            for (int i = 0; i < x.Length; i++)
            {
                int compareResult = m_individualComparable.Compare(x[i], y[i]);

                if (compareResult < 0) return -1;
                if (compareResult > 0) return 1;
            }

            return 0;
        }

        #endregion
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        #region Public
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        //=====================================================================
        public HighCardMultipleCompare(IComparer<Card> individualComparable)
        {
            m_individualComparable = individualComparable;
        }

        #endregion
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        #region Fields
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        IComparer<Card> m_individualComparable;

        #endregion
    }
}
