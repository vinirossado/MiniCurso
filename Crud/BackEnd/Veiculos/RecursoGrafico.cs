using MyHome.Enums;

namespace MyHome
{
    public abstract class RecursoGrafico : BaseDomain
    {
        #region Properties
        public TipoRecursoGrafico Tipo { get; set; }
        public virtual Empreendimento Empreendimento { get; set; }
        public long EmpreendimentoId { get; set; }
        public string Recurso { get; set; }
        #endregion
    }
}
