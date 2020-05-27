using System;
using System.Collections.Generic;
using System.Text;
using QueryBuilder.Client.Models.Interfaces;
using QueryBuilder.DremioApi.Models;
namespace QueryBuilder.Client.Models
{
    public class LoginDremio : ILogin
    {
        public string userName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public static LoginDremio Null => new LoginDremio(Login.Null) { };

        public bool IsNull() => Equals(Null);
        public LoginDremio(Login login)
        {
            userName = login.userName;
            firstName = login.firstName;
            lastName = login.lastName;
            email = login.email;
        }
        public override bool Equals(object obj)
        {
            if (obj is LoginDremio login)
            {
                return userName == login.userName &&
                        firstName == login.firstName &&
                        lastName == login.lastName &&
                        email == login.email;
            }
            return base.Equals(obj);
        }
    }
}
