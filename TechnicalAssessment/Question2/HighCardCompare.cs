using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Question2
{
    public class HighCardCompare : IComparer<Card>
    {
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        #region Implement IComparer
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        //=====================================================================
        public int Compare([AllowNull] Card x, [AllowNull] Card y)
        {
            if (x.IsWildCard && y.IsWildCard)
                return 0;
            else if (x.IsWildCard)
                return -1;
            else if (y.IsWildCard)
                return 1;

            if (x.Number > y.Number)
                return -1;
            else if (x.Number < y.Number)
                return 1;
            else
            {
                if (!m_allowSite)
                    return 0;

                if (x.Suit < y.Suit)
                    return -1;
                
                if (x.Suit > y.Suit)
                    return 1;
            }

            return 0;                      
        }

        #endregion
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        #region Public
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        //=====================================================================
        public HighCardCompare(bool allowSite)
        {
            m_allowSite = allowSite;
        }

        #endregion
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        #region Fields
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        bool m_allowSite;

        #endregion
    }
}
