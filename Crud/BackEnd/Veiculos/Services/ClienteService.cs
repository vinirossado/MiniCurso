using MyHome.Interfaces.Repos;
using MyHome.Interfaces.Services;
using MyHome.Security;
using MyHome.Services.Base;
using OnAuth2;
using OnAuth2.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHome.Services
{
    public class ClienteService : BaseService<Cliente>, IClienteService
    {
        private readonly IClienteRepo _repo;
        private readonly IConfiguration _configuration;
        public ClienteService(IClienteRepo repo, IConfiguration configuration) : base(repo)
        {
            _configuration = configuration;
            _repo = repo;
        }

        public override IList<Cliente> List(long clienteAppId)
        {
            return _repo.List(clienteAppId);
        }

        public long Save(long clienteAppId, Cliente cliente, bool alterandoSenha = false)
        {
            try
            {
                if (cliente.FacebookId != null && cliente.GoogleId != null)
                {
                    if (_repo.VerificarCPFExiste(clienteAppId, cliente.Id, cliente.Cpf))
                        throw new ArgumentException("CPF já Cadastrado");
                }

                if (_repo.VerificarEmailExiste(clienteAppId, cliente.Id, cliente.Email))
                    throw new ArgumentException("Email já Cadastrado");

                if (cliente.Id > 0 && !alterandoSenha)
                {
                    var clienteBd = Find(clienteAppId, cliente.Id);
                    cliente.Senha = clienteBd.Senha;
                }
                else
                    cliente.Senha = Crypt.Encrypt(_configuration, cliente.Senha);

                cliente.Imagem = UploadService.UploadImage(cliente.Nome, cliente.Imagem);

                return base.Save(clienteAppId, cliente);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Cliente FindByEmail(long clienteAppId, string email) => _repo.FindByEmail(clienteAppId, email);
     
    }
}
