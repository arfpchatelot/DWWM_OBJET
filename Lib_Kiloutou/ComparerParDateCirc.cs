using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace lib_kiloutou
{
    public class ComparerParDateCirc : IComparer<Voiture>
    {
        public int Compare( Voiture x, Voiture y)
        {
            return x.DateCirculation.CompareTo(y.DateCirculation);
        }
    }
}
