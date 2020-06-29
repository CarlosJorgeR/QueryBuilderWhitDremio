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
        public List<ViewPredicate> viewPredicates { get; set; }
        public BasedQueryEntity GetBasedQueryEntity()
        {
            return new BasedQueryEntity() {
                TableName =TableName,
                Alias =Alias,
                Outputs =fields.Zip(selected, (f, b) => b ? f : null).
                Where(f => f != null).ToList(),
                predicates=viewPredicates.Select(p=>p.GetPredicate()).Where(p => p != null).ToList()
        };
        }
    }
    public class ViewPredicate
    {
        public string fieldName { get; set; }
        public BasicTypes BasicType { get; set; }
        public OperatorType? Operator { get; set; }
        public string expression1 { get; set; }
        public string expression2 { get; set; }
        public AbstractPredicate GetPredicate()
        {
            if (!Operator.HasValue)
            {
                return null;
            }
            else if (Operator.Value == OperatorType.Between)
            {
                return new BetweenPredicate(fieldName, expression2, expression1, BasicType);
            }
            else
            {
                return new BasicPredicate(fieldName,(OperatorTypeBin)Operator.Value, BasicType, expression1);
            }
        }
    }


}
