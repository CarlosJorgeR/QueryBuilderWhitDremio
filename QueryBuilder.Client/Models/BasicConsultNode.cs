using System;
using System.Collections.Generic;
using System.Text;
using QueryBuilder.Client.Models.Interfaces;
using System.Linq;
namespace QueryBuilder.Client.Models
{
    class BasicConsultNode:IConsultNode
    {

        public ISelectNode SelectNode { get; set; }
        public IFromNode FromNode { get; set; }
        public IWhereNode WhereNode { get; set; }

        public IOrderByNode OrderByNode { get; set; }

        public bool IsNull => ((SelectNode?.SelectList?.Count())??0)==0;

        public BasicConsultNode(ISelectNode selectNode, IFromNode fromNode, IWhereNode whereNode, IOrderByNode orderByNode)
        {
            
            SelectNode = selectNode;
            FromNode = fromNode;
            WhereNode = whereNode;
            OrderByNode = orderByNode;

        }
        public BasicConsultNode()
        { }
        public override string ToString()
        {
            return IsNull? string.Empty: $"{SelectNode} {FromNode} {WhereNode} {OrderByNode}";
        }


    }
}
