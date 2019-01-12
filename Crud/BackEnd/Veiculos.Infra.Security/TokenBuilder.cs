using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
namespace MyHome.Infra.Security
{
    public class TokenBuilder
    {
        public SecurityKey SecurityKey { get; set; }
        public string Subject { get; set; }
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public List<KeyValuePair<string, string>> Claims { get; set; }
        public int Minutes { get; set; }

        public TokenBuilder()
        {
            Claims = new List<KeyValuePair<string, string>>();
        }

        public Token Build()
        {
            Validate();

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, Subject),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            }
            .Union(Claims.Select(item => new Claim(item.Key, item.Value)));

            var token = new JwtSecurityToken(
                issuer: Issuer,
                audience: Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(Minutes),
                signingCredentials: new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256)
                );

            return new Token(token);
        }

        private void Validate()
        {
            var exceptions = new List<Exception>();

            if (SecurityKey == null)
                exceptions.Add(new ArgumentNullException("Security Key"));

            if (string.IsNullOrEmpty(Subject))
                exceptions.Add(new ArgumentNullException("Subject"));

            if (string.IsNullOrEmpty(Audience))
                exceptions.Add(new ArgumentNullException("Audience"));

            if (string.IsNullOrEmpty(Issuer))
                exceptions.Add(new ArgumentNullException("Issuer"));

            if (exceptions.Count > 0)
                throw new AggregateException(exceptions);
        }
    }
}
