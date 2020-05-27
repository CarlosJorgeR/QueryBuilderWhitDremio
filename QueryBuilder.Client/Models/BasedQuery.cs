using System;
using System.Collections.Generic;
using System.Text;

namespace QueryBuilder.Client.Models
{
    public class BasedQueryEntity
    {
        public List<string> Outputs { get; set; }
        public string TableName { get; set; }
        public string Alias { get; set; }
    }
    public class Predicate
    {

    }
}
