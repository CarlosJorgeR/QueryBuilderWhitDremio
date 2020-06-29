using System;
using System.Collections.Generic;
using System.Text;

namespace QueryBuilder.Client.Models.Interfaces
{
    public interface IQueryResult
    {
        IEnumerable<IField> fields { get; set; }
        IEnumerable<IRow> Rows { get; set; }
    }
    public interface IField
    {
        string name { get; set; }
        BasicTypes type { get; set; }
    }
    public interface IRow
    {
        //Los valores están dispuestos en el orden de los campos
        IEnumerable<object> values { get; set; }
    }
}
