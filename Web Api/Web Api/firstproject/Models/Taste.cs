using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace firstproject.Models
{
    [Flags]
    public enum Taste
    {
        Sweetness = 1,
        Sourness = 2,
        Saltiness = 4,
        Bitterness = 8,
        Savoriness = 16
    }
}