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
using QueryBuilder.Client.Models.Interfaces;
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
            var entitys = client.Entities;
            //entitys.AddRange(client.Apps);

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
        public async Task<IActionResult> Apps()
        {
            var apps = client.Apps;
            ViewBag.apps = apps;
            return View();

        }

        public async Task<IActionResult> Query()
        {
            return View(new ViewQuery {action=ActionQuery.Create });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Query(ViewQuery viewQuery)
        {
            if (!ModelState.IsValid)
                return View(viewQuery);
            IQueryState state;
            if (viewQuery.action.Value==ActionQuery.Edit)
            {
                state=client.ReplaceVDS(viewQuery.path, viewQuery.query);
                if (!state.IsCorrect)
                    ModelState.AddModelError(nameof(viewQuery.query), "La consulta no es valida para modificar la Tabla virtual");
            }
            else
            {
                state=client.CreateVDS(viewQuery.path, viewQuery.query);
                if (client.Apps.Any(a=>a.Alias== viewQuery.path))
                    ModelState.AddModelError(nameof(viewQuery.path), "Ya existe esta tabla virtual");
                if (!state.IsCorrect)
                    ModelState.AddModelError(nameof(viewQuery.query), "La consulta no es valida para crear la Tabla virtual");
            }
            if (!ModelState.IsValid)
                return View(viewQuery);
            return Redirect("Apps");
        }
        public async Task<IActionResult> Edit(string id)
        {
            var app = client.Apps.Single(a => a.RealName == id) as VirtualEntity;
            return View("Query",
                        new ViewQuery {query=app.sql, path=app.Alias, action = ActionQuery.Edit });
        }
    }
}