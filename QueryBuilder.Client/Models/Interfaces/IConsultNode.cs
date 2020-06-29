using System;
using System.Collections.Generic;
using System.Text;

namespace QueryBuilder.Client.Models.Interfaces
{
    public interface IConsultNode
    {
        ISelectNode SelectNode { get;}
        IFromNode FromNode { get; }
        IWhereNode WhereNode { get; }
        IOrderByNode OrderByNode { get;  }

    }
}
