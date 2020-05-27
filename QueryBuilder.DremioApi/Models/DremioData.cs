using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Collections;


namespace QueryBuilder.DremioApi.Models
{
    public class DremioData
    {

        public List<Column> schema { get; set; }
        public List<Dictionary<string, object>> rows { get; set; }

        public static DremioData NULL => new DremioData();
        
    }
    public class Column
    {
        public string name { get; set; }
        public Type type { get; set; }

    }
    public class Type
    {
        public string name { get; set; }
    }
    //[DataContract]
    //public class row
    //{
    //    public Dictionary<string, string> value { get; set; }
    //}
}
