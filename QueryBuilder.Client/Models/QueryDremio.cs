using System;
using System.Collections.Generic;
using System.Text;
using QueryBuilder.Client.Models.Interfaces;

namespace QueryBuilder.Client.Models
{
    public class BaseQuery : IQuery
    {

        public IQueryResult queryResult { get; }

        public IQueryState queryState { get; }
        public BaseQuery(IQueryResult queryResult, IQueryState queryState)
        {
            this.queryResult = queryResult;
            this.queryState = queryState;
        }
        
    }
}
