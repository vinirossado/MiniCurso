using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHome.Infra.Security
{
    public static class Crypt
    {
        public static string Encrypt(string value)
        {
            if (!string.IsNullOrEmpty(value))
                return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password: value,
                    salt: Encoding.ASCII.GetBytes("DcMyT1m&"), // Tem que ser 8 caracteres
                    prf: KeyDerivationPrf.HMACSHA1,
                    iterationCount: 10000,
                    numBytesRequested: 2561 / 8));

            return null;
        }
    }
}
