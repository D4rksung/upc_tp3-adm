using PetCenter.Referencias.Dominio.Administracion.DTOs.Maestros.Mascota;
using PetCenter.Referencias.Presentacion.Web.Models.Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetCenter.Referencias.Presentacion.Web.Models.Otros.Mascota
{
    public class MascotaGridModelo : GridModelo<MascotaDto>
    {
        #region CONSTRUCTOR

        public MascotaGridModelo() :base (new List<MascotaDto>()){ }

        public MascotaGridModelo(IEnumerable<MascotaDto> lista, int tamanioPagina, int totalPagina): base(lista,tamanioPagina,totalPagina) { }

        #endregion
    }
}