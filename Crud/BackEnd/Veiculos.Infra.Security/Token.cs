using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace MyHome.Infra.Security
{
    public class Token
    {
        public DateTime ValidTo { get; set; }
        public string Value { get; set; }

        public Token(JwtSecurityToken token)
        {
            ValidTo = token.ValidTo;
            Value = new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
