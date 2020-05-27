using System.Collections.Generic;
using System.Linq;
using QueryBuilder.Client.Models.Interfaces;
namespace QueryBuilder.Client.Models
{
    class BasicOrderByNode: IOrderByNode
    {
        public IEnumerable<string> OrderByList { get; set; }
        public BasicOrderByNode(IEnumerable<string> OrderByList)
        {
            this.OrderByList = OrderByList;
        }
        public override string ToString()
        {
            return $"ORDER BY {OrderByList.Aggregate((s1, s2) => $"{s1},{s2}")}";
        }
    }
}
