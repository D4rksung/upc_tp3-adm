using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Solicitud;
using PetCenter.Referencias.Presentacion.Web.Models.Comun;
using System.Collections.Generic;

namespace PetCenter.Referencias.Presentacion.Web.Models.Registros.Solicitud
{
    public class SolicitudGridModelo : GridModelo<SolicitudDto>
    {
        #region CONSTRUCTOR

        public SolicitudGridModelo() :base (new List<SolicitudDto>()){ }

        public SolicitudGridModelo(IEnumerable<SolicitudDto> lista, int tamanioPagina, int totalPagina): base(lista,tamanioPagina,totalPagina) { }

        #endregion
    }
}