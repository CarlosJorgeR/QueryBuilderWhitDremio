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
        
        public QueryBuilder(List<BasedQueryEntity> queryBuilder)
        {
            this.queryBuilder = queryBuilder;

        }
        public List<IConsultNode> GetconsultNodes(List<BasedQueryEntity> basedQueryEntities)
        {
            return (from q in basedQueryEntities select GetConsult(q)).ToList();
        }

        public IConsultNode GetConsult(BasedQueryEntity basedQueryEntity)
        {
            var selectPart = GetselectPart(basedQueryEntity.Outputs, basedQueryEntity);
            var fromPart = GetFromPart(basedQueryEntity);
            return new BasicConsultNode(selectPart, fromPart, null, null);
        }
        public ISelectNode GetselectPart(List<string> selectFields, BasedQueryEntity basedQueryEntity)
        {
            return new BasicSelectNode(
                   from f in selectFields select $"{basedQueryEntity.Alias}.{f}"
                );
        }
        public IFromNode GetFromPart(BasedQueryEntity basedQueryEntity)
        {
            return new BasicFromNode(
                 new BasicTableNode($"{basedQueryEntity.TableName} as {basedQueryEntity.Alias}")
                );
        }

    }
}
