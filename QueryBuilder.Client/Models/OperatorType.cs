using System;
using System.Collections.Generic;
using System.Text;

namespace QueryBuilder.Client.Models
{

    public enum OperatorType
    {
        Contains=1,
        StartWith= 1 << 1,
        EndWith= 1 << 2,
        Equal= 1 << 3,
        Diff= 1 << 4,
        GreaterThan= 1 << 5,
        GreaterThanEqual= 1 << 6,
        SmallerThan= 1 << 7,
        SmallerThanEqual= 1 << 8,
        Between= 1 << 9,
    }
    
    public enum OperatorTypeBin
    {
        Contains = OperatorType.Contains,
        StartWith = OperatorType.StartWith,
        EndWith = OperatorType.EndWith,
        Equal = OperatorType.Equal,
        Diff = OperatorType.Diff,
        GreaterThan = OperatorType.GreaterThan,
        GreaterThanEqual = OperatorType.GreaterThanEqual,
        SmallerThan = OperatorType.SmallerThan,
        SmallerThanEqual = OperatorType.SmallerThanEqual,
    }

    

}
