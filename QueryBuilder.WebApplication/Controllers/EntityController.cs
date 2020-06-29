using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QueryBuilder.Client.Services.Interfaces;
using QueryBuilder.WebApplication.Models.ViewModels;
using QueryBuilder.Client.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace QueryBuilder.WebApplication.Controllers
{
    [Authorize(Policy = "IsAuthenticate")]
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
            //var password= 
            var entitys = await client.GetEntitys();

            ViewBag.entitys = entitys;
            return View(new ViewBasedQuery {
                viewBasedQueryEntities =entitys.Select(e=>
                        new ViewBasedQueryEntity {
                            TableName =e.RealName,
                            Alias =e.Alias,
                            selected=new bool[e.atributes.Count],
                            fields=e.atributes.Select(a=>a.Name).ToList(),
                            viewPredicates=e.atributes.Select(a=>new ViewPredicate() { fieldName=a.Name, BasicType=a.Type}).ToList()
                            
                        }).ToList()
            });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult> Index( ViewBasedQuery viewBasedQuery)
        {
            var query = viewBasedQuery.GetBasedQueryEntities();
            var results= client.ExecuteQuery(query);
            var algo = results.ToList();
            return View("Result",algo);
        }
    }
}