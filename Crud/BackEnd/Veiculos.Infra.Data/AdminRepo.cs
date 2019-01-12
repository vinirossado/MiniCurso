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
    public class AdminRepo : BaseRepo<Admin>, IAdminRepo
    {
        private DbContextOptions<DataContext> _options;
        public AdminRepo(DbContextOptions<DataContext> options) : base(options) => _options = options;


        public Admin FindByEmail(long clienteAppId, string email)
        {
            using (var context = new DataContext(_options))
            {
                return context.Admins.FirstOrDefault(x => x.Email.Trim().ToLower() == email.Trim().ToLower());
            }
        }

        public Admin FindBySocialLogin(long clienteAppId, string loginSocialId)
        {
            using (var context = new DataContext(_options))
            {
                return context.Admins.FirstOrDefault(x => x.FacebookId == loginSocialId || x.GoogleId == loginSocialId);
            }
        }
    }
}
