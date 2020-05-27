using System;
using System.Collections.Generic;
using System.Text;
using QueryBuilder.Client.Models.Interfaces;

namespace QueryBuilder.Client.Models
{
    class BasicTableNode: ITableNode
    {
        public string NameTable;
        public BasicTableNode(string nameTable)
        {
            NameTable = nameTable;
        }
        public override string ToString()
        {
            return NameTable;
        }
    }
}
