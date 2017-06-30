using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Atencion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetCenter.Referencias.Presentacion.Web.Models.Registros.Liquidacion
{
    public class LiquidacionFiltroModelo
    {
        #region PROPIEDADES

        public AtencionDto Atencion { get; set; }        

        #endregion

        #region CONSTRUCTOR

        public LiquidacionFiltroModelo() { }

        public LiquidacionFiltroModelo(AtencionDto _atencion)
        {
            Atencion = _atencion;
        }

        #endregion
    }
}