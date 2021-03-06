﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QueryBuilder.Client.Models.Interfaces;
using QueryBuilder.Client.Services.Interfaces;
namespace QueryBuilder.WebApplication.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueryController : ControllerBase
    {
        public IClient client { get; set; }
        public QueryController(IClient client)
        {
            this.client = client;
        }
        [HttpGet("{query}")]
        public IQuery Get(string query)
        {
            return client.ExecuteQuery(query);
        }
        [HttpDelete("{vds}")]
        public IQueryState Delete(string vds)
        {
            return client.DropVDS(vds);
        }

        //[HttpGet]
        //public List<Client.Models.Entity> GetAlgo()
        //{
        //    return client.Entities;
        //}
    }
}