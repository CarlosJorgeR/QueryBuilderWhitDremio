using System;
using System.Collections.Generic;
using System.Text;
using QueryBuilder.DremioApi.Models.Interfaces;
using System.Linq;
namespace QueryBuilder.DremioApi.Models
{
    public class Dremio_Catalog
    {
        public List<Dremio_Source> data { get; set; }
        public IEnumerable<ISource> GetSources()
        {
            return from d in data
                   select new Source(d.path);
        }
    }
    public class Dremio_Source
    {
        public List<string> path { get; set; }
    }
}
