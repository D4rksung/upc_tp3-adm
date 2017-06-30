using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Solicitud;
using PetCenter.Referencias.Presentacion.Web.Models.Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetCenter.Referencias.Presentacion.Web.Models.Registros.Evaluacion
{
    public class EvaluacionEditorModelo : MensajeModelo
    {
        #region PROPIEDADES
        public SolicitudDto Solicitud { get; set; }
       
        #endregion

        #region CONSTRUCTOR
        public EvaluacionEditorModelo()
        {
            Solicitud = new SolicitudDto();
        }
        #endregion
    }
}