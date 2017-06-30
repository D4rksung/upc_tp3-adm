using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Solicitud;
using PetCenter.Referencias.Presentacion.Web.Models.Comun;
using System.Collections.Generic;

namespace PetCenter.Referencias.Presentacion.Web.Models.Registros.Evaluacion
{
    public class EvaluacionGridModelo : GridModelo<SolicitudDto>
    {
        #region CONSTRUCTOR

        public EvaluacionGridModelo() :base (new List<SolicitudDto>()){ }

        public EvaluacionGridModelo(IEnumerable<SolicitudDto> lista, int tamanioPagina, int totalPagina): base(lista,tamanioPagina,totalPagina) { }

        #endregion
    }
}