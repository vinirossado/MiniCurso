using MyHome.App.Interface;
using MyHome.Dtos;
using MyHome.Interfaces.Domain;
using MyHome.Interfaces.Services;
using OnAuth2;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHome.App
{
    public class LoginApp : ILoginApp
    {
        private readonly ILoginService _service;
        public LoginApp(ILoginService service)
        {
            _service = service;
        }

        public void AlterarSenha(long clienteAppId, string role, ChangePassword changePassword) => _service.AlterarSenha(clienteAppId, role, changePassword);

        public IUsuario GenerateResetCode(long clienteAppId, string role, string login)
        {
            return _service.GenerateResetCode(clienteAppId, role, login);
        }

        public IUsuario Login(long clienteAppId, string role, DefaultLogin login) => _service.Login(clienteAppId, role, login);

        public IUsuario LoginSocial(long clienteAppId, string role, SocialLogin login) => _service.LoginSocial(clienteAppId, role, login);

        public void ResetPassword(long clienteAppId, string role, ResetarSenhaDto reset)
        {
            _service.ResetPassword(clienteAppId, role, reset);
        }
    }
}
