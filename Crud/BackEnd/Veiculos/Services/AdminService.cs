using MyHome.Interfaces.Repos;
using MyHome.Interfaces.Services;
using MyHome.Services.Base;
using OnAuth2;
using OnAuth2.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHome.Services
{
    public class AdminService : BaseService<Admin>, IAdminService
    {
        private readonly IAdminRepo _repo;
        private readonly IConfiguration _configuration;
        public AdminService(IAdminRepo repo, IConfiguration configuration) : base(repo)
        {
            _configuration = configuration;
            _repo = repo;
        }

        public long Save(long clienteAppId, Admin admin, bool alterandoSenha = false)
        {
            try
            {
                if (admin.Id > 0 && !alterandoSenha)
                {
                    var adminBd = Find(clienteAppId, admin.Id);
                    admin.Senha = adminBd.Senha;
                }
                else
                    admin.Senha = Crypt.Encrypt(_configuration, admin.Senha);

                admin.Imagem = UploadService.UploadImage(admin.Nome, admin.Imagem);

                return base.Save(clienteAppId, admin);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Admin FindByEmail(long clienteAppId, string email) => _repo.FindByEmail(clienteAppId, email);
    }
}
