using System;
using System.Collections.Generic;
using System.Text;
using QueryBuilder.Client.Models.Interfaces;

namespace QueryBuilder.Client.Models
{
    class BasicConsultNode:IConsultNode
    {

        public ISelectNode SelectNode { get; set; }
        public IFromNode FromNode { get; set; }
        public IWhereNode WhereNode { get; set; }

        public IOrderByNode OrderByNode { get; set; }


        public BasicConsultNode(ISelectNode selectNode, IFromNode fromNode, IWhereNode whereNode, IOrderByNode orderByNode)
        {
            SelectNode = selectNode;
            FromNode = fromNode;
            WhereNode = whereNode;
            OrderByNode = orderByNode;

        }
        public override string ToString()
        {
            return $"{SelectNode} {FromNode} {WhereNode} {OrderByNode}";
        }


    }
}
