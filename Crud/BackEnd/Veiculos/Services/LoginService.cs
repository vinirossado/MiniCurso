using MyHome.Dtos;
using MyHome.Interfaces.Domain;
using MyHome.Interfaces.Services;
using MyHome.Security;
using OnAuth2;
using OnAuth2.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace MyHome.Services
{
    public class LoginService : ILoginService
    {
        private readonly IAdminService _adminService;
        private readonly IClienteService _clienteService;
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;
        public LoginService(IAdminService adminService, IClienteService clienteService, IConfiguration configuration , IEmailService emailService)
        {
            _configuration = configuration;
            _adminService = adminService;
            _clienteService = clienteService;
            _emailService = emailService;
        }

        public void AlterarSenha(long clienteAppId, string role, ChangePassword changePassword)
        {
            try
            {
                var usuario = FindByEmail(clienteAppId, role, changePassword.Login);

                if (string.IsNullOrEmpty(changePassword.NovaSenha))
                    throw new Exception("Você deve informar uma nova senha.");

                if (usuario == null)
                    throw new Exception("Este usuário não existe.");


                if (usuario.Senha != Crypt.Encrypt(_configuration, changePassword.SenhaAtual))
                    throw new Exception("A senha atual está incorreta.");

                usuario.Senha = changePassword.NovaSenha;

                Save(clienteAppId, role, usuario);
            }
            catch (Exception)
            {
                throw new Exception("Erro ao alterar a senha.");
            }
        }

        public IUsuario Login(long clienteAppId, string role, DefaultLogin login)
        {
            var usuario = FindByEmail(clienteAppId, role, login.Email);
            login.Senha = Crypt.Encrypt(_configuration, login.Senha);
            if (usuario?.Senha == login.Senha)
            {
                usuario.Token = GetToken(usuario);
                return usuario;
            }

            throw new Exception("Login ou senha inválidos.");
        }

        public IUsuario LoginSocial(long clienteAppId, string role, SocialLogin login)
        {
            try
            {
                var usuario = FindByEmail(clienteAppId, role, login.Email);

                if (usuario == null)
                {
                    switch (role)
                    {

                        case Permissoes.Admin:
                            usuario = Activator.CreateInstance<Admin>();
                            break;
                      
                        case Permissoes.User:
                            usuario = Activator.CreateInstance<Cliente>();
                            break;
                    }

                    usuario.ClienteAppId = clienteAppId;
                    usuario.Email = login.Email;
                    usuario.Imagem = login.Imagem;
                    usuario.Nome = login.Nome;
                    usuario.Perfil = login.Perfil;
                }

                if (login.Provider == SocialProvider.Facebook)
                    usuario.FacebookId = login.Id;
                else
                    usuario.GoogleId = login.Id;

                var usuarioId = Save(clienteAppId, role, usuario);

                usuario.Token = GetToken(usuario);
                usuario.Senha = null;

                return usuario;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IUsuario GenerateResetCode(long clienteAppId, string role, string email)
        {
            try
            {
                var usuario = FindByEmail(clienteAppId, role, email);

                if (usuario == null)
                    throw new Exception("Nenhum usuário encontrado com o email informado");

                using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
                {
                    Random rnd = new Random();
                    var RandonCode = rnd.Next(100000, 999999);


                    usuario.CodigoAlteracaoSenha = RandonCode;
                    usuario.ValidadeCodigo = DateTime.Now.AddDays(1);

                    switch (role)
                    {
                        case Permissoes.Admin:
                            _adminService.Save(clienteAppId, usuario as Admin);
                            break;
                      
                        case Permissoes.User:
                            _clienteService.Save(clienteAppId, usuario as Cliente);
                            break;
                    }

                }

                var message = "<link href='http://fonts.googleapis.com/css?family=Roboto' rel='stylesheet' type='text/css'>" +
                              "<body style='background-color:#333333; text-align:center;font-family:Roboto; '>" +
                                  "<img src = 'https://onsoft.eti.br/wp-content/uploads/on-dark.png' style ='margin-top: 1.5rem !important'/>" +
                                  "<br/>" +
                                  "<br/>" +
                                  "<div style='margin-left: auto; margin-bottom: 3rem !important; margin-top: 3rem !important;'>" +
                                      "<span style = 'color:whitesmoke;'>Código Para redefinição da senha:</span>" +
                                      $"<h1 style = 'margin-top: 3rem !important; color: whitesmoke;'> { usuario.CodigoAlteracaoSenha } </h1>" +
                                  "</div >" +
                                  "<br/>" +
                                  "<footer style='margin-bottom: 3rem !important';>" +
                                      "<span style='color:white;'> Email gerado automaticamente por favor não responda.</span>" +
                                      "<br/>" +
                                      "<span style='color:whitesmoke; margin-top: 3rem !important;'> Equipe de Suporte Onsoft.</span>" +
                                  "</footer>" +
                                  "<br/>" +
                              "</body>";

                _emailService.Enviar(usuario.Email, "Redefinição de Senha", message);

                return usuario;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ResetPassword(long clienteAppId, string role, ResetarSenhaDto reset)
        {
            try
            {
                var usuario = FindByEmail(clienteAppId, role, reset.Email);

                if (usuario == null)
                    throw new Exception("Email Inválido.");
                else if (usuario.CodigoAlteracaoSenha == null)
                    throw new Exception("Nenhum código de alteração de senha foi encontrado.");
                else if (DateTime.Now > usuario.ValidadeCodigo)
                    throw new Exception("Este código não é mais válido.");
                else if (usuario.CodigoAlteracaoSenha != reset.CodigoAlteracao)
                    throw new Exception("O código está incorreto.");

                usuario.Senha = Crypt.Encrypt(_configuration, reset.NovaSenha);
                usuario.CodigoAlteracaoSenha = null;
                usuario.ValidadeCodigo = null;

                switch (role)
                {
                    case Permissoes.Admin:
                        _adminService.Save(clienteAppId, usuario as Admin);
                        break;
                   
                    case Permissoes.User:
                        _clienteService.Save(clienteAppId, usuario as Cliente);
                        break;
                }
            }
            catch (Exception ex) { throw; }
        }

        public string GetToken(IUsuario usuario)
        {
            var claims = new List<KeyValuePair<string, string>>();

            if (!string.IsNullOrEmpty(usuario.Perfil))
            {
                var rolesArray = usuario.Perfil.Trim().ToLower().Replace(" ", "").Split(',');
                foreach (var role in rolesArray)
                    claims.Add(new KeyValuePair<string, string>("roles", role));
            }

            var tokenBuilder = new TokenBuilder
            {
                SecurityKey = SecurityKeyBuilder.Build("$tud10@My4pp5!2018"),
                Subject = usuario.Id.ToString(),
                Issuer = "studio.myapp.myhome",
                Audience = "studio.myapp.myhome",
                Claims = claims,
                Minutes = 60 * 8,
            };

            return tokenBuilder.Build().Value;
        }


        private IUsuario FindByEmail(long clienteAppId, string role, string email)
        {
            switch (role)
            {
                case Permissoes.Admin:
                    return _adminService.FindByEmail(clienteAppId, email);
             
                case Permissoes.User:
                    return _clienteService.FindByEmail(clienteAppId, email);
            }

            return null;
        }

        private long Save(long clienteAppId, string role, IUsuario usuario)
        {
            switch (role)
            {
                case Permissoes.Admin:
                    return _adminService.Save(clienteAppId, usuario as Admin, true);
                
                case Permissoes.User:
                    return _clienteService.Save(clienteAppId, usuario as Cliente, true);
            }

            return 0;
        }

        public Planta Find(long clienteAppId, long id)
        {
            throw new NotImplementedException();
        }

        public IList<Planta> List(long clienteAppId)
        {
            throw new NotImplementedException();
        }

        public long Save(long clienteAppId, Planta obj)
        {
            throw new NotImplementedException();
        }

        public void Remove(long clienteAppId, long id)
        {
            throw new NotImplementedException();
        }
    }
}
