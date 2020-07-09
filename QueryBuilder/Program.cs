using System;
using QueryBuilder;
using System.IO;
using QueryBuilder.DremioApi.Services;
using QueryBuilder.OdbcConnection.Services;
using System.Linq;
namespace QueryBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new DremioAPI("http://localhost:9047");
            client.login("CarlosJ", "CCr.5180").Wait();
            var result=client.SqlQuery("select * from Dev.Application.Empresa_Compra");
            Console.WriteLine(result);
            var results3 = client.GetCatalogByPath("Dev/Business").ToList();
            //client.CreateVDS("Dev.Business.Algo", "SELECT compras.fecha,compras.cliente FROM Dev.Business.compras as compras ");
            //client.DropVDS("Dev.Business.Algo");
            new DremioOdbcConnection("CarlosJ", "CCr.5180");
            //Console.WriteLine(result2);
            //client.GetLogin("CarlosJ", "CCr.5180");
            //client.GetEntitys();
            //var dremioApi = new DremioAPI("http://localhost:9047");
            //var a=dremioApi.login("CarlosJ", "CCr.5180");
            //while (!a.IsCompleted)
            //{

            //}
            //var result=new StreamReader(dremioApi.apiGet("user")).ReadToEnd();
            ////var dejavel = dremioApi.GetCatalogByPath("MysqlSource");
            ////var dejavel = dremioApi.GetCatalogByPath("MysqlSource/compra");
            //var dejavel = dremioApi.GetCatalog();
            //foreach (var item in dejavel)
            //{
            //    Console.WriteLine(item.url);
            //}
            //Console.WriteLine("------------Finish!--------------");
            //var odbc = new DremioOdbcConnection();
            //odbc.odbcConnection(uid: "CarlosJ",pwd: "CCr.5180");
        }
        
    }
}
