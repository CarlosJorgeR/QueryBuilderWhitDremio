using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace QueryBuilder.DremioApi.Models
{
    public class Login
    {
        public string token { get; set; }
        public string userName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public decimal expires { get; set; }
        public string email { get; set; }

        public static Login Null => new Login() { };

        public bool IsNull() => Equals(Null);
    }

    
}
