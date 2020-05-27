using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace QueryBuilder.DremioApi.Models
{
    public class Dremio_Dataset:Dremio_Source
    {
        public List<Field> fields { get; set; }
        public Dataset GetTable() => new Dataset(fields.Select(a => (a.name, a.type.name)),
                                                    path);
    }
    public class Field
    {
        public string name { get; set; }
        public Type type { get; set; }
    }
 
}
