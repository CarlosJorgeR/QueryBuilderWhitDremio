using System.Collections.Generic;
using System.Linq;
using QueryBuilder.DremioApi.Models.Interfaces;
namespace QueryBuilder.DremioApi.Models
{
    //Este representa una ubicación dentro la capa semántica de dremio
    public class Source:ISource
    {
        public IEnumerable<string> path { get; set; }

        public string url =>path.Aggregate((s1, s2) => $"{s1}/{s2}");
        public string url2 => path.Aggregate((s1, s2) => $"{s1}.{s2}");

        public Source(IEnumerable<string> path)
        {
            this.path = path;
        }
    }
    //Este representa una tabla que puede ser física o virtual
    public class Dataset:Source
    {

        public List<(string, string)> fields { get; set; }
        public string TableName { get; set; }
        public Dataset(IEnumerable<(string, string)> fields, IEnumerable<string> path) :base(path)
        {
            this.TableName = path.Last();
            this.fields = fields.ToList();
        }
    }
   
}
