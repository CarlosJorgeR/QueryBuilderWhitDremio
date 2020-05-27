using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QueryBuilder.Client.Services.Interfaces;
using QueryBuilder.WebApplication.Models.ViewModels;
using QueryBuilder.Client.Models;
namespace QueryBuilder.WebApplication.Controllers
{
    public class EntityController : Controller
    {
        public IClient client { get; set; }
        public EntityController(IClient client)
        {
            this.client = client;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var entitys = await client.GetEntitys();
            ViewBag.entitys = entitys;
            return View(new ViewBasedQuery {
                viewBasedQueryEntities =entitys.Select(e=>
                        new ViewBasedQueryEntity {
                            TableName =e.RealName,
                            Alias =e.Alias,
                            selected=new bool[e.atributes.Count],
                            fields=e.atributes.Select(a=>a.Name).ToList()
                            
                        }).ToList()
            });
        }
        [HttpPost]
        public async Task<IActionResult> Index( ViewBasedQuery viewBasedQuery)
        {
            client.ExecuteQuery(viewBasedQuery.GetBasedQueryEntities());
            return View();
        }
    }
}