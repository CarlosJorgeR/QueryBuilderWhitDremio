using System;
using System.Collections.Generic;
using System.Text;

namespace QueryBuilder.Client.Models
{
    public static class OperatorFunc
    {
        public static bool IsNumericType(this BasicTypes basicTypes)
        {
            return (BasicTypes.NUMERIC_TYPE & basicTypes) != 0;
        }
        public static bool IsTextType(this BasicTypes basicTypes)
        {
            return (BasicTypes.TEXT_TYPE & basicTypes) != 0;
        }
        public static bool IsDateType(this BasicTypes basicTypes)
        { 
            return (BasicTypes.DATE_TYPE & basicTypes) != 0;
        }
    }
}
