using System;
using System.Collections.Generic;
using System.Text;

namespace QueryBuilder.Client.Models.Interfaces
{
    public interface IQuery
    {
        IQueryResult queryResult { get; }
        IQueryState queryState { get; }
    }
}
