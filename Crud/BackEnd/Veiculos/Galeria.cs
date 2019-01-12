using MyHome.Enums;

namespace MyHome
{
    public class Galeria : RecursoGrafico
    {
        public string RecursoFull { get; set; }

        #region Constructors
        public Galeria() { }

        public Galeria(TipoRecursoGrafico tipo, string recurso)
        {
            Tipo = tipo;
            Recurso = recurso;
        }

        public Galeria(TipoRecursoGrafico tipo, string recurso, string recursoFull) : this(tipo, recurso)
        {
            RecursoFull = recursoFull;
        }
        #endregion
    }
}
