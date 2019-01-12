using System;
using System.Collections.Generic;
using System.Text;

namespace MyHome.Infra.Security
{
    public class DefaultLogin
    {
        public string Email { get; set; }

        private string _senha;
        public string Senha { get => _senha; set => _senha = Crypt.Encrypt(value); }
    }
}
