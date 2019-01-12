using MyHome.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHome
{
    public class Planta : RecursoGrafico
    {
        #region Constructors
        public Planta() { }

        public Planta(TipoRecursoGrafico tipo)
        {
            Tipo = tipo;
        }

        public Planta(TipoRecursoGrafico tipo, string recurso) : this(tipo)
        {
            Recurso = recurso;
        }
        #endregion
    }
}
