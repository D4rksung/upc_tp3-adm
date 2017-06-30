using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Referencia;
using PetCenter.Referencias.Presentacion.Web.Models.Comun;
using System.Collections.Generic;

namespace PetCenter.Referencias.Presentacion.Web.Models.Registros.ContraReferencia
{
    public class ContraReferenciaGridModelo : GridModelo<ReferenciaDto>
    {
        #region CONSTRUCTOR

        public ContraReferenciaGridModelo() :base (new List<ReferenciaDto>()){ }

        public ContraReferenciaGridModelo(IEnumerable<ReferenciaDto> lista, int tamanioPagina, int totalPagina): base(lista,tamanioPagina,totalPagina) { }

        #endregion
    }
}