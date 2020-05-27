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
        Task<ILogin> GetLogin(string userName, string password);
        Task<List<Entity>> GetEntitys();
        void ExecuteQuery(List<BasedQueryEntity> basedQueryEntities);
    }
}
