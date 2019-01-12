using Microsoft.EntityFrameworkCore;
using MyHome.Infra.Data.Base;
using MyHome.Infra.Data.Context;
using MyHome.Interfaces.Repos;
using System.Linq;

namespace MyHome.Infra.Data
{
    public class EmpreendimentoRepo : BaseRepo<Empreendimento>, IEmpreendimentoRepo
    {
        private readonly DbContextOptions<DataContext> _options;
        public EmpreendimentoRepo(DbContextOptions<DataContext> options) : base(options)
        {
            _options = options;
        }

        public override Empreendimento Find(long clienteAppId, long id)
        {
            using (var context = new DataContext(_options))
            {
                return context.Empreendimentos
                              .Include(x => x.Plantas)
                              .Include(x => x.Galerias)
                              .FirstOrDefault(x => x.ClienteAppId == clienteAppId && x.Id == id);
            }
        }


    }
}
