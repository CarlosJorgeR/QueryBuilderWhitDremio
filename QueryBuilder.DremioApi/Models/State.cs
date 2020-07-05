using System;
using System.Collections.Generic;
using System.Text;

namespace QueryBuilder.DremioApi.Models
{
    public enum jobState { FAILED, COMPLETED }
    public class State
    {
        public string state{get; set;}
    }
}
