using System;
using System.Collections.Generic;
using System.Text;
using QueryBuilder.Client.Models;
using QueryBuilder.Client.Models.Interfaces;
using System.Linq;
namespace QueryBuilder.Client.Services
{
    public class QueryBuilder
    {
        public List<BasedQueryEntity> queryBuilder { get; set; }
        public BasedQueryEntity basedQueryEntity { get; set; }


        public QueryBuilder(List<BasedQueryEntity> queryBuilder)
        {
            this.queryBuilder = queryBuilder;

        }
        public List<IConsultNode> GetconsultNodes(List<BasedQueryEntity> querys)
        {
            return (from q in querys select GetConsult(q)).ToList();
        }

        public IConsultNode GetConsult(BasedQueryEntity basedQueryEntity)
        {
            this.basedQueryEntity = basedQueryEntity;
            var selectPart = GetselectPart(basedQueryEntity.Outputs);
            var fromPart = GetFromPart();
            var wherePart = GetWherePart(basedQueryEntity.predicates);
            return new BasicConsultNode(selectPart, fromPart, wherePart, null);
        }
        public ISelectNode GetselectPart(List<string> selectFields)
        {
            return new BasicSelectNode(
                   (from f in selectFields select $"{basedQueryEntity.Alias}.{f}").ToList()
                );
        }
        public IFromNode GetFromPart()
        {
            return new BasicFromNode(
                 new BasicTableNode($"{basedQueryEntity.TableName} as {basedQueryEntity.Alias}")
                );
        }
        public IWhereNode GetWherePart(List<AbstractPredicate> predicates)
        {
            if (predicates == null)
                return null;
            return new BasicWhereNode(
                    predicates.Select(p=>p.GetExpression()).ToList()
                    ,
                    "And"
                );
        }

    }
}
