using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using QueryBuilder.DremioApi.Models;
using QueryBuilder.Client.Models.Interfaces;
using QueryBuilder.Client.Models;
namespace QueryBuilder.Client.Services.Interfaces
{
    public interface IClient
    {
        bool IsAutenticate { get;}
        Task<ILogin> GetLogin(string userName, string password);
        void Logout();
        Task<List<Entity>> GetEntitys();
        Task<List<Entity>> GetApp();
        IEnumerable<IQueryResult> ExecuteQuery(List<BasedQueryEntity> basedQueryEntities);
    }
}
