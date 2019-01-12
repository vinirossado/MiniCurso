using Microsoft.EntityFrameworkCore;
using MyHome.Infra.Data.Base;
using MyHome.Infra.Data.Context;
using MyHome.Interfaces.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyHome.Infra.Data
{
    public class ClienteRepo : BaseRepo<Cliente>, IClienteRepo
    {
        private readonly DbContextOptions<DataContext> _options;
        public ClienteRepo(DbContextOptions<DataContext> options) : base(options)
        {
            _options = options;
        }

        public override IList<Cliente> List(long clienteAppId)
        {
            using (var context = new DataContext(_options))
            {
                return context.Clientes.Where(x => x.ClienteAppId == clienteAppId).OrderBy(x => x.Nome).ToList();
            }

        }

        public bool VerificarCPFExiste(long clienteAppId, long id, string cpf)
        {
            using (var context = new DataContext(_options))
            {
                return context.Clientes.FirstOrDefault(x => x.ClienteAppId == clienteAppId && x.Cpf == cpf && x.Id != id) != null;
            }
        }

        public Cliente FindByEmail(long clienteAppId, string email)
        {
            using (var context = new DataContext(_options))
            {
                return context.Clientes.FirstOrDefault(x => x.Email.Trim().ToLower() == email.Trim().ToLower());
            }
        }

        public bool VerificarEmailExiste(long clienteAppId, long id, string email)
        {
            using (var context = new DataContext(_options))
            {
                return context.Clientes.FirstOrDefault(x => x.ClienteAppId == clienteAppId && x.Email == email && x.Id != id) != null;
            }
        }
       
    }
}
