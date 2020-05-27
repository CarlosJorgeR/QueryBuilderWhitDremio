using System;
using System.Collections.Generic;
using System.Text;
using QueryBuilder.Client.Models.Interfaces;
using System.Linq;
using QueryBuilder.Client.Models;
namespace QueryBuilder.Client.Models
{
    class BasicWhereNode:IWhereNode
    {
        public IEnumerable<string> Conditions { get; set; }
        public string OperatorType { get; set; }

        public BasicWhereNode(IEnumerable<string> conditions,string operatorType)
        {
            Conditions = conditions;
            OperatorType = operatorType;
        }

        public override string ToString()
        {
            if (Conditions.Count() == 0)
                return string.Empty;
            return $"WHERE {Conditions.Aggregate((s1, s2) => $"{s1} {OperatorType} {s2}")}";
        }

    }
}
