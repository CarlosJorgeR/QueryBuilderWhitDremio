using System;
using System.Collections.Generic;
using System.Text;
using QueryBuilder.Client.Models.Interfaces;
namespace QueryBuilder.Client.Models
{
    public class BasedRow : IRow
    {
        public IEnumerable<object> values { get; set; }
    }
}
