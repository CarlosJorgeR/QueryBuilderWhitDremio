using System;
using System.Collections.Generic;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Json;
using QueryBuilder.DremioApi.Models;
using QueryBuilder.DremioApi.Models.Interfaces;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mime;
namespace QueryBuilder.DremioApi.Services
{

    
    public class DremioAPI

    {
        public string server { get; set; }
        public string token { get; set; }
        public DremioAPI(string server)
        {
            this.server = server;

        }
        public async Task<Login> login(string Name, string password)
        {
            var Data = $"{{\"userName\":\"{Name}\", \"password\":\"{password}\"}}";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"{server}/apiv2/login");
            request.Method = "POST";
            request.ContentType = "application/json";
            
            request.ContentLength = Data.Length; 
            using (Stream webstream = request.GetRequestStream())
            using (StreamWriter requestWriter = new StreamWriter(webstream, System.Text.Encoding.ASCII))
            {
                requestWriter.Write(Data);
            }
            try
            {
                WebResponse webResponse = request.GetResponse();
                
                using (Stream webstream = webResponse.GetResponseStream())
                {
                    var logToken = JsonConvert.DeserializeObject<Login>(
                        (new StreamReader(webstream)).ReadToEnd()
                    );
                    token = $"_dremio{logToken.token}";
                    return logToken;
                }

            }
            catch (Exception e)
            {
                Console.Out.WriteLine("-----------------------------");
                Console.Out.WriteLine(e.Message);
                return Login.Null;
            }
        }
        public StreamReader apiPost(string endPoint, string body)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"{server}/api/v3/{endPoint}");
            
            request.PreAuthenticate = true;
            request.Method = "POST";
            request.ContentType = "application/json";
            var byteArray = System.Text.Encoding.UTF8.GetBytes(body);
            request.ContentLength = byteArray.Length;
            request.Headers["Authorization"]=token;
            using (Stream webstream = request.GetRequestStream())
            {
                webstream.Write(byteArray,0,byteArray.Length);
            }
            try
            {
                var webResponse = (HttpWebResponse)request.GetResponse();
                var charset = webResponse.CharacterSet;
                if (string.IsNullOrEmpty(charset))
                {
                    charset = "windows-1252";
                }
                var encoding = System.Text.Encoding.GetEncoding(charset);
                return new StreamReader( webResponse.GetResponseStream(),encoding);
               
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("-----------------------------");
                Console.Out.WriteLine(e.Message);
                return StreamReader.Null ;
            }
        }
        public Stream apiGet(string endPoint)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"{server}/api/v3/{endPoint}");
            request.PreAuthenticate = true;
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Headers["Authorization"] = token;
            request.Accept = "application/json";
            try
            {
                WebResponse webResponse = request.GetResponse();
                return webResponse.GetResponseStream();

            }
            catch (Exception e)
            {
                Console.Out.WriteLine("-----------------------------");
                Console.Out.WriteLine(e.Message);
                return Stream.Null;
            }
        }
        public DremioData SqlQuery(string query)
        {
            if (string.IsNullOrEmpty(query))
                return DremioData.NULL;
            var idStream =apiPost("sql", $"{{\"sql\":\"{query}\"}}");
            if (!idStream.Equals(StreamReader.Null))
            {
                var tokenid= JsonConvert.DeserializeObject<TokenId>(idStream.ReadToEnd());
                //var tokenidSer = new DataContractJsonSerializer(typeof(TokenId));
                //var tokenid = (TokenId)tokenidSer.ReadObject(idStream.);
                JobState state;
                //Esperamos que dremio nos mande una respuesta  de la consulta
                do
                {
                    var jobstateStream = apiGet($"job/{tokenid.id}");
                    var jobstateStreamReader = new StreamReader(jobstateStream);
                    state = JsonConvert.DeserializeObject<JobState>(jobstateStreamReader.ReadToEnd());
                    if (state.jobState=="FAILED")
                        return DremioData.NULL;
                } while (state.jobState!= "COMPLETED");
                var resultStream = apiGet($"job/{tokenid.id}/results");
                var streamReader = new StreamReader(resultStream);
                return JsonConvert.DeserializeObject<DremioData>(streamReader.ReadToEnd());
            }
            return DremioData.NULL;
        }
        public IEnumerable<ISource> GetCatalog()
        {
            var idStream = apiGet("catalog");
            var streamReader = new StreamReader(idStream);
            var str = JsonConvert.DeserializeObject<Dremio_Catalog>(streamReader.ReadToEnd());
            return str.GetSources();
        }
        public IEnumerable<ISource> GetCatalogByPath(string path)
        {
            //@CarlosJ
            var idStream = apiGet($"catalog/by-path/{path}");
            var streamReader = new StreamReader(idStream);
            var str = JsonConvert.DeserializeObject<Dremio_Sources>(streamReader.ReadToEnd());
            foreach (var child in str.children)
            {
                var result=new Source(child.path);
                try
                {
                    idStream = apiGet($"catalog/by-path/{result.url}");
                    streamReader = new StreamReader(idStream);
                    var metada = JsonConvert.DeserializeObject<Dremio_Dataset>(streamReader.ReadToEnd());
                    result = metada.GetTable();
                }
                catch (Exception){
                }
                yield return result;

            }
            
        }
      
    }
}
