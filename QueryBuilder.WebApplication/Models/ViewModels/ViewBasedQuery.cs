using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QueryBuilder.Client.Models;
namespace QueryBuilder.WebApplication.Models.ViewModels
{
   
    public class ViewBasedQuery
    {
        public List<ViewBasedQueryEntity> viewBasedQueryEntities { get; set; }
        public List<BasedQueryEntity> GetBasedQueryEntities()
        {
            return (from q in viewBasedQueryEntities
                    select q.GetBasedQueryEntity()).
                    ToList();
        }
    }
    public class ViewBasedQueryEntity
    {
        public bool[] selected { get; set; }
        public string TableName { get; set; }
        public string Alias { get; set; }
        public List<string> fields { get; set; }
        public BasedQueryEntity GetBasedQueryEntity()
        {
            return new BasedQueryEntity() {
                TableName =TableName,
                Alias =Alias,
                Outputs =fields.Zip(selected, (f, b) => b ? f : null).
                Where(f => f != null).ToList()
        };
        }
    }


}
