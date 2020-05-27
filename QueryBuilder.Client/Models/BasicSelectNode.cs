using System;
using System.Collections.Generic;
using System.Text;
using QueryBuilder.Client.Models.Interfaces;
using System.Linq;
namespace QueryBuilder.Client.Models
{
    class BasicSelectNode:ISelectNode
    {
        public IEnumerable<string> SelectList { get; set; }
        public BasicSelectNode(IEnumerable<string> SelectList)
        {
            this.SelectList = SelectList;
        }
        public override string ToString()
        {
            return $"SELECT {SelectList.Aggregate((s1,s2)=>$"{s1},{s2}")}";
        }
    }
}
