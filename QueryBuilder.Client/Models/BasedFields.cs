using System;
using System.Collections.Generic;
using System.Text;
using QueryBuilder.Client.Models.Interfaces;
namespace QueryBuilder.Client.Models
{
    public class BasedFields : IField
    {
        public string name { get; set; }
        public BasicTypes type { get; set; }
    }
}
