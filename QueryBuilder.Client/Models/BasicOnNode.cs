using System;
using System.Collections.Generic;
using System.Text;
using QueryBuilder.Client.Models.Interfaces;
namespace QueryBuilder.SQLModel.Models
{
    public class BasicOnNode:IOnNode
    {

        string field1 { get; set; }
        string field2 { get; set; }
        public BasicOnNode(string field1, string field2)
        {
            this.field1 = field1;
            this.field2 = field2;
        }

        public override string ToString()
        {
            return $"ON {field1} = {field2}";
        }
    }
}
