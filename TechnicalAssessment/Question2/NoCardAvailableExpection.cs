using System;
using System.Collections.Generic;
using System.Text;

namespace Question2
{
    public class NoCardAvailableExpection : Exception
    {
        public NoCardAvailableExpection() : base("No card Availbale") { }
    }
}
