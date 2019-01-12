using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MyHome.Infra.Security
{
    public class SecurityKeyBuilder
    {
        public static SymmetricSecurityKey Build(string secret) => new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));
    }
}
