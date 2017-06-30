using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Referencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetCenter.Referencias.Presentacion.Web.Models.Registros.Atencion
{
    public class AtencionFiltroModelo
    {
        #region PROPIEDADES

        public ReferenciaDto Referencia { get; set; }

        #endregion

        #region CONSTRUCTOR

        public AtencionFiltroModelo() { }

        public AtencionFiltroModelo(ReferenciaDto _referencia)
        {
            Referencia = _referencia;
        }

        #endregion
    }
}