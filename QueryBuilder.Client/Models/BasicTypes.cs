using System;
using System.Collections.Generic;
using System.Text;

namespace QueryBuilder.Client.Models
{
    public enum BasicTypes
    {
        NOTDEFINED = 1,
        BIGINT = 2,
        INT = 4,
        INTEGER = 8,
        FLOAT = 16,
        DOUBLE = 32,
        VARCHAR = 64,
        TEXT = 128,
        DATE = 256,
        TIME = 512,
        NUMERIC_TYPE = BIGINT | INT | FLOAT | DOUBLE | INTEGER,
        TEXT_TYPE = VARCHAR | TEXT,
        DATE_TYPE = DATE | TIME,

    }
}
