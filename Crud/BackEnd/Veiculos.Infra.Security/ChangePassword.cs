using System;
using System.Collections.Generic;
using System.Text;

namespace MyHome.Infra.Security
{
    public class ChangePassword
    {
        public string Login { get; set; }

        private string _senhaAtual;
        public string SenhaAtual { get => _senhaAtual; set => _senhaAtual = value; }

        private string _novaSenha;
        public string NovaSenha { get => _novaSenha; set => _novaSenha = value; }
    }
}
