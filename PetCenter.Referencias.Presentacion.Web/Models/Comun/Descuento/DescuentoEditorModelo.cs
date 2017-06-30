using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.ConvenioDescuento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetCenter.Referencias.Presentacion.Web.Models.Comun.Descuento
{
    public class DescuentoEditorModelo
    {
        #region PROPIEDADES
        public ConvenioDescuentoDto ConvenioDescuento { get; set; }


        #endregion

        #region CONSTRUCTOR
        public DescuentoEditorModelo()
        {
            ConvenioDescuento = new ConvenioDescuentoDto();
        }
        #endregion
    }
}