﻿using System;
using System.Collections.Generic;
using System.Text;
using QueryBuilder.Client.Models.Interfaces;
using QueryBuilder.DremioApi.Models;
namespace QueryBuilder.Client.Models
{
    public class QueryStateDremio : IQueryState
    {
        public bool IsCorrect { get;}
        public static IQueryState Null=>new QueryStateDremio(jobState.FAILED);
        private jobState jobState { get; set; }
        public QueryStateDremio(jobState jobState)
        {
            this.jobState = jobState;
            if (jobState.COMPLETED == jobState)
                IsCorrect = true;
            else
                IsCorrect = false;
        }
    }
}
