using MyHome.Enums;
using MyHome.Interfaces.Repos;
using MyHome.Interfaces.Repos.Base;
using MyHome.Interfaces.Services;
using MyHome.Services.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace MyHome.Services
{
    public class EmpreendimentoService : BaseService<Empreendimento>, IEmpreendimentoService
    {
        private readonly IGaleriaService galeriaService;
        private readonly IPlantaService plantaService;
        private readonly IEmpreendimentoRepo empreendimentoRepo;
        public EmpreendimentoService(IEmpreendimentoRepo repo, IGaleriaService _galeriaService, IPlantaService _plantaService, IEmpreendimentoRepo _empreendimentoRepo) : base(repo)
        {

            galeriaService = _galeriaService;
            plantaService = _plantaService;
        }

        public override Empreendimento Find(long clienteAppId, long id)
        {
            var empreendimento = base.Find(clienteAppId, id);


            empreendimento.Lazeres = JsonConvert.DeserializeObject<string[]>(empreendimento.LazerJson);

            return empreendimento;

        }

        public override IList<Empreendimento> List(long clienteAppId)
        {
            var empreendimentos = base.List(clienteAppId);

            foreach (var empreendimento in empreendimentos)
            {
                empreendimento.Lazeres = JsonConvert.DeserializeObject<string[]>(empreendimento.LazerJson);
            }

            return empreendimentos;
        }

        protected override void Add(long clienteAppId, Empreendimento empreendimento)
        {
            var plantas = empreendimento.Plantas;
            var galerias = empreendimento.Galerias;

            empreendimento.LazerJson = JsonConvert.SerializeObject(empreendimento.Lazeres);

            using (var scope = new TransactionScope())
            {
                empreendimento.Background = UploadService.UploadImage(empreendimento.Nome, empreendimento.Background);

                foreach (var planta in empreendimento.Plantas)
                {
                    var index = empreendimento.Plantas.IndexOf(planta);
                    planta.Recurso = UploadService.UploadImage($"{empreendimento.Nome}_Plantas_{index}", planta.Recurso);
                    planta.ClienteAppId = clienteAppId;
                }

                foreach (var galeria in empreendimento.Galerias)
                {
                    var index = empreendimento.Galerias.IndexOf(galeria);
                    galeria.Recurso = UploadService.UploadImage($"{empreendimento.Nome}_Galerias_{index}", galeria.Recurso);
                    galeria.ClienteAppId = clienteAppId;
                }

                scope.Complete();
            }
            base.Add(clienteAppId, empreendimento);
        }


        protected override void Update(long clienteAppId, Empreendimento empreendimento)
        {
            //Serialize LazerJson
            empreendimento.LazerJson = JsonConvert.SerializeObject(empreendimento.Lazeres);
            
            // Remover plantas e galerias vazias
            empreendimento.Plantas = empreendimento.Plantas.Where(x => !string.IsNullOrEmpty(x.Recurso)).ToList();
            empreendimento.Galerias = empreendimento.Galerias.Where(x => !string.IsNullOrEmpty(x.Recurso)).ToList();

            // Recuperar informações do banco de dados
            var empreendimentoBd = Find(clienteAppId, empreendimento.Id);
            var galeriasBd = empreendimentoBd.Galerias;
            var plantasBd = empreendimentoBd.Plantas;

            // Separar as plantas adicionadas, removidas e mantidas
            var plantasAdd = empreendimento.Plantas.Where(x => x.Id == 0);
            var plantasMantidas = empreendimento.Plantas.Where(x => x.Id != 0);
            var plantasRemovidas = plantasBd.Where(x => !empreendimento.Plantas.Select(y => y.Id).Contains(x.Id)).ToList();

            // Separar as galerias adicionadas, removidas e mantidas
            var galeriasAdd = empreendimento.Galerias.Where(x => x.Id == 0);
            var galeriasMantidas = empreendimento.Galerias.Where(x => x.Id != 0);
            var galeriasRemovidas = galeriasBd.Where(x => !empreendimento.Galerias.Select(y => y.Id).Contains(x.Id)).ToList();

            using (var scope = new TransactionScope())
            {
                foreach (var galeria in galeriasRemovidas)
                {
                    galeriaService.Remove(clienteAppId, galeria.Id);
                    UploadService.DeleteImage(galeria.Recurso);
                }

                foreach (var galeria in galeriasAdd)
                {
                    var index = empreendimento.Galerias.IndexOf(galeria);
                    galeria.Recurso = UploadService.UploadImage($"{empreendimento.Nome}_Galerias_{index}", galeria.Recurso);
                    galeria.ClienteAppId = clienteAppId;
                }

                foreach (var galeria in galeriasMantidas)
                {
                    var index = empreendimento.Galerias.IndexOf(galeria);
                    galeria.Recurso = UploadService.UploadImage($"{empreendimento.Nome}_Galerias_{index}", galeria.Recurso);
                    galeria.ClienteAppId = clienteAppId;
                }

                foreach (var planta in plantasRemovidas)
                {
                    plantaService.Remove(clienteAppId, planta.Id);
                    UploadService.DeleteImage(planta.Recurso);
                }

                foreach (var planta in plantasAdd)
                {
                    var index = empreendimento.Plantas.IndexOf(planta);
                    planta.Recurso = UploadService.UploadImage($"{empreendimento.Nome}_Plantas_{index}", planta.Recurso);
                    planta.ClienteAppId = clienteAppId;
                }

                foreach (var planta in plantasMantidas)
                {
                    var index = empreendimento.Plantas.IndexOf(planta);
                    planta.Recurso = UploadService.UploadImage($"{empreendimento.Nome}_Plantas_{index}", planta.Recurso);
                    planta.ClienteAppId = clienteAppId;
                }

                scope.Complete();
            }

            base.Update(clienteAppId, empreendimento);
        }
    }
}
