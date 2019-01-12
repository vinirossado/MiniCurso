using MyHome;
using MyHome.app.Base;
using MyHome.app.Interface;
using MyHome.Interfaces.Services;

namespace MyHome.Interface
{
    public class EmpreendimentoApp : BaseApp<Empreendimento>, IEmpreendimentoApp
    {
        private readonly IEmpreendimentoService _empreendimentoService;
        public EmpreendimentoApp(IEmpreendimentoService empreendimentoService) : base(empreendimentoService)
        {
            _empreendimentoService = empreendimentoService;
        }
    }
}
