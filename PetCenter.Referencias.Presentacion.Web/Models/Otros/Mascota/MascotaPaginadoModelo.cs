using PetCenter.Referencias.Dominio.Administracion.DTOs.Maestros.Mascota;
using PetCenter.Referencias.Presentacion.Web.Models.Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetCenter.Referencias.Presentacion.Web.Models.Otros.Mascota
{
    public class MascotaPaginadoModelo : MensajeModelo
    {
        #region PROPIEDADES

        public MascotaFiltroModelo Filtro { get; set; }

        public MascotaGridModelo Grid { get; set; }

      

        #endregion

        #region CONSTRUCTOR

        public MascotaPaginadoModelo()
        {
            Filtro = new MascotaFiltroModelo();
        }

        #endregion
    }
}