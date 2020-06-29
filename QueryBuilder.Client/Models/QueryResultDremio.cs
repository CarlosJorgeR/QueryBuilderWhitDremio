using System;
using System.Collections.Generic;
using System.Text;
using QueryBuilder.DremioApi.Models;
using System.Linq;
using QueryBuilder.Client.Models.Interfaces;
namespace QueryBuilder.Client.Models
{
    public class QueryResultDremio : IQueryResult
    {
        public IEnumerable<IField> fields { get; set; }
        public IEnumerable<IRow> Rows { get; set; }
        public QueryResultDremio(DremioData dremioData)
        {
            fields = dremioData?.schema?.Select(s => {
                return new BasedFields
                {
                    name = s.name,
                    type = Enum.Parse<BasicTypes>(s.type.name)
                };
                })??(IEnumerable<IField>)new List<IField>();

            Rows = dremioData?.rows?.Select(
                   r => {
                       return new BasedRow
                       {
                           values = r.Values
                       };
                   }
                ) ?? (IEnumerable<IRow>)new List<IRow>(); ;
                  
        }
    }

}
