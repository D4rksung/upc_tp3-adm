using System;
using System.Collections.Generic;
using System.Linq;

namespace PetCenter.Referencias.Dominio.Logica.Base
{
    public abstract class EntidadBase
    {
        /// <summary>
        /// NombreEntidad
        /// </summary>
        public abstract string NombreEntidad { get; }

        /// <summary>
        /// IdAccion
        /// </summary>
        public string IdAccionEntidad { get; set; }

        /// <summary>
        /// Llave
        /// </summary>
        public string LlaveEntidad { get; set; }

        /// <summary>
        /// IdLog
        /// </summary>
        public string IdLog { get; set; }

        /// <summary>
        /// SetAuditoria
        /// </summary>
        /// <param name="log">log</param>
        /// <param name="propiedadModificada">propiedadModificada</param>
        /// <param name="valorOriginal">valorOriginal</param>
        /// <param name="valorActual">valorActual</param>
        //public void SetAuditoria(ref AuditoriaLog log, string propiedadModificada, object valorOriginal, object valorActual)
        //{
        //    string valorOriginalString = (valorOriginal == null) ? "NULL" : valorOriginal.ToString();
        //    string valorActualString = (valorActual == null) ? "NULL" : valorActual.ToString();
        //    valorOriginalString = string.IsNullOrEmpty(valorOriginalString) ? "NULL" : valorOriginalString;
        //    valorActualString = string.IsNullOrEmpty(valorActualString) ? "NULL" : valorActualString;

        //    //Si auditoria es NULL se crea e inserta el primer detalle
        //    if (log == null)
        //    {
        //        log = new AuditoriaLog
        //              {
        //                  NombreEntidad = NombreEntidad,
        //                  IdAccion = IdAccionEntidad,
        //                  Llave = LlaveEntidad,
        //                  IdLog =  Guid.NewGuid().ToString(),
        //                  Detalles = new List<AuditoriaLogDetalle>
        //                    {
        //                        new AuditoriaLogDetalle(propiedadModificada, valorOriginalString, valorActualString)
        //                    }
        //              };
        //        IdLog = log.IdLog;
        //    }
        //    else
        //    {
        //        //Buscamos en la lisa si la propiedad ya se modifico
        //        AuditoriaLogDetalle auditoriaDetalle = log.Detalles.FirstOrDefault(d => d.Propiedad == propiedadModificada);

        //        //Si la propiedad no existe se inserta el detalle
        //        if (auditoriaDetalle == null)
        //            log.Detalles.Add(new AuditoriaLogDetalle(propiedadModificada, valorOriginalString, valorActualString));
        //        else
        //        {
        //            //Si el nuevo valor es igual al valor original se elimina el detalle, caso contrario se actualiza el valor actual.
        //            if (auditoriaDetalle.ValorOriginal == valorActualString)
        //                log.Detalles.Remove(auditoriaDetalle);
        //            else
        //                auditoriaDetalle.ValorActual = valorActualString;
        //        }
        //    }
        //}
    }

}