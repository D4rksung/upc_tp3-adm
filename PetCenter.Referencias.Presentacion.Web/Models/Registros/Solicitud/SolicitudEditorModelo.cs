using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Solicitud;
using PetCenter.Referencias.Presentacion.Web.Models.Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetCenter.Referencias.Presentacion.Web.Models.Registros.Solicitud
{
    public class SolicitudEditorModelo : MensajeModelo
    {
        #region PROPIEDADES
        public SolicitudDto Solicitud { get; set; }
       
        #endregion

        #region CONSTRUCTOR
        public SolicitudEditorModelo()
        {
            Solicitud = new SolicitudDto();
        }
        #endregion
    }
}