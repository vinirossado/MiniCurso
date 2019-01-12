using MyHome.Dtos;
using MyHome.Interfaces.Domain;
using OnAuth2;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHome.App.Interface
{
    public interface ILoginApp
    {
        IUsuario Login(long clienteAppId, string role, DefaultLogin login);
        void AlterarSenha(long clienteAppId, string role, ChangePassword changePassword);
        IUsuario LoginSocial(long clienteAppId, string role, SocialLogin login);
        IUsuario GenerateResetCode(long clienteAppId, string role, string email);
        void ResetPassword(long clienteAppId, string role, ResetarSenhaDto reset);
    }
}
