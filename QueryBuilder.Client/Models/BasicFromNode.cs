using System;
using System.Collections.Generic;
using System.Text;
using QueryBuilder.Client.Models.Interfaces;
namespace QueryBuilder.Client.Models
{
    class BasicFromNode:IFromNode
    {
        public ITableNode Table { get; set; }
        public BasicFromNode(ITableNode table)
        {
            Table = table;
        }
        public override string ToString()
        {
            return $"FROM {Table}";
        }


    }
}
