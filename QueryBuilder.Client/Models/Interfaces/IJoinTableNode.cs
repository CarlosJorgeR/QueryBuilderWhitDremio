using System;
using System.Collections.Generic;
using System.Text;

namespace QueryBuilder.Client.Models.Interfaces
{
    interface IJoinTableNode:ITableNode
    {
        ITableNode TableNode1 { get; set; }
        ITableNode TableNode2 { get; set; }
    }
}
