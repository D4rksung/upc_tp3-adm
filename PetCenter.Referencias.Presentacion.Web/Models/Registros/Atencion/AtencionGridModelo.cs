using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Referencia;
using PetCenter.Referencias.Presentacion.Web.Models.Comun;
using System.Collections.Generic;

namespace PetCenter.Referencias.Presentacion.Web.Models.Registros.Atencion
{
    public class AtencionGridModelo : GridModelo<ReferenciaDto>
    {
        #region CONSTRUCTOR

        public AtencionGridModelo() :base (new List<ReferenciaDto>()){ }

        public AtencionGridModelo(IEnumerable<ReferenciaDto> lista, int tamanioPagina, int totalPagina): base(lista,tamanioPagina,totalPagina) { }

        #endregion
    }
}