using System;
using System.Collections.Generic;
using System.Text;

namespace QueryBuilder.Client.Models.Interfaces
{
    public interface IQueryState
    {
        bool IsCorrect { get; }
    }
}
