using System;
using System.Collections.Generic;
using System.Text;

namespace QueryBuilder.Client.Models
{
    public enum OperatorType
    {
        Contains=1,
        StartWith=2,
        EndWith=4,
        Equal=8,
        Diff=16,
        GreaterThan=32,
        GreaterThanEqual=64,
        SmallerThan=128,
        SmallerThanEqual=256,
    }
}
