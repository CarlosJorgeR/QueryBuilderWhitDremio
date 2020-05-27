using System;
using System.Collections.Generic;
using System.Text;

namespace QueryBuilder.Client.Models.Interfaces
{
    public interface ILogin
    {
        string userName { get; set; }
        string firstName { get; set; }
        string lastName { get; set; }
        string email { get; set; }

        bool IsNull();
    }
}
