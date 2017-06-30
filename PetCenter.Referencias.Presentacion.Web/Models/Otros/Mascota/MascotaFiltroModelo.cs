using PetCenter.Referencias.Dominio.Administracion.DTOs.Maestros.Mascota;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetCenter.Referencias.Presentacion.Web.Models.Otros.Mascota
{
    public class MascotaFiltroModelo
    {
        #region PROPIEDADES

        public MascotaDto Mascota { get; set; }

        #endregion

        #region CONSTRUCTOR

        public MascotaFiltroModelo() { }

        public MascotaFiltroModelo(MascotaDto _Mascota)
        {
            Mascota = _Mascota;
        }

        #endregion
    }
}