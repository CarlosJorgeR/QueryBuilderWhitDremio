using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using QueryBuilder.Client.Models;
using QueryBuilder.Client.Models.Interfaces;
using QueryBuilder.Client.Services.Interfaces;
using QueryBuilder.DremioApi.Services;
using System.Linq;
using QueryBuilder.DremioApi.Models;
namespace QueryBuilder.Client.Services
{
    
    public class DremioClient : IClient
    {
        private DremioAPI dremioAPI { get; set; }
        public string userName { get; set; }
        public bool IsAutenticate { get; private set; }

        public DremioClient(string host)
        {
            dremioAPI = new DremioAPI(host);
        }
        public async Task<ILogin> GetLogin(string userName, string password)
        {
            IsAutenticate = true;
            this.userName = userName;
            return new LoginDremio(await dremioAPI.login(userName, password));
        }
        public void Logout()
        {
            IsAutenticate = false;
        }
        public async Task<List<Entity>> GetEntitys()
        {
            return dremioAPI.GetCatalogByPath("Dev/Business")
                            .Where(ds => ds is Dataset)
                            .Cast<Dataset>()
                            .Select(
                                ds => new Entity()
                                {
                                    RealName = ds.url2,
                                    Alias = ds.TableName,
                                    atributes = ds.fields.Select(f=>new Entity_Attribute(f.Item1,f.Item2) ).ToList()
                                }
                            ).ToList();
        }
        public async Task<List<Entity>> GetApp()
        {
            return dremioAPI.GetCatalogByPath("Dev/Application")
                            .Where(ds => ds is Dataset)
                            .Cast<Dataset>()
                            .Select(
                                ds => new Entity()
                                {
                                    RealName = ds.url2,
                                    Alias = ds.TableName,
                                    atributes = ds.fields.Select(f => new Entity_Attribute(f.Item1, f.Item2)).ToList()
                                }
                            ).ToList();
        }
        public IEnumerable<IQueryResult> ExecuteQuery(List<BasedQueryEntity> basedQueryEntities)
        {
            var queryBuilder = new QueryBuilder(basedQueryEntities);
            var results=queryBuilder.GetconsultNodes(basedQueryEntities);
            return results.Select(q=> {
                var result = dremioAPI.SqlQuery(q.ToString());
                return new QueryResultDremio(result);
            }).ToList();
            
        }

    }
}
