using System;
using System.Collections.Generic;
using System.Text;
using QueryBuilder.Client.Models.Interfaces;

namespace QueryBuilder.Client.Models
{
    class BasicJoinTableNode : IJoinTableNode
    {

        public ITableNode TableNode1 { get; set; }
        public ITableNode TableNode2 { get; set; }
        public JoinType JoinType { get; set; }
        public IOnNode OnNode { get; set; }
        public BasicJoinTableNode(ITableNode tableNode1, ITableNode tableNode2, JoinType joinType, IOnNode onNode)
        {
            TableNode1 = tableNode1;
            TableNode2 = tableNode2;
            JoinType = joinType;
            OnNode = onNode;
        }

        public override string ToString()
        {
            return $"{TableNode1} {JoinType} JOIN {TableNode2} {OnNode}";
        }

    }
}
