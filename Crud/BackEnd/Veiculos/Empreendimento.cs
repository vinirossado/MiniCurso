using Newtonsoft.Json;
using System.Collections.Generic;

namespace MyHome
{
    public class Empreendimento : BaseDomain
    {
        #region Properties
        public string Nome { get; set; }
        public string Cidade { get; set; }
        public string Background { get; set; }
        public string Descricao { get; set; }
        public string NumeroQuartos { get; set; }
        public string AreaPrivativa { get; set; }
        public string NumeroTorres { get; set; }
        public string NumeroAndares { get; set; }
        public string NumeroUnidades { get; set; }
        public string UnidadesPorAndar { get; set; }
        public string NumeroElevadores { get; set; }
        public string NumeroVagas { get; set; }
        public IList<string> Lazeres { get; set; }
        [JsonIgnore]
        public string LazerJson { get; internal set; }
        public virtual IList<Galeria> Galerias { get; set; }
        public virtual IList<Planta> Plantas { get; set; }
        #endregion

        #region Constructors

        public Empreendimento()
        {
            Lazeres = new List<string>();
            Galerias = new List<Galeria>();
            Plantas = new List<Planta>();
        }

        
        #endregion
    }
}
