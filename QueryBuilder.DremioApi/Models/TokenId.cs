using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
namespace QueryBuilder.DremioApi.Models
{
  
    [DataContract]
    public class TokenId
    {
        [DataMember]
        public string id { get; set; }
    }
}
