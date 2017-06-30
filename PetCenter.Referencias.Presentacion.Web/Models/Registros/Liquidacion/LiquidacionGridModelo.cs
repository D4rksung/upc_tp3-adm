using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Atencion;
using PetCenter.Referencias.Presentacion.Web.Models.Comun;
using System.Collections.Generic;

namespace PetCenter.Referencias.Presentacion.Web.Models.Registros.Liquidacion
{
    public class LiquidacionGridModelo : GridModelo<AtencionDto>
    {
        #region CONSTRUCTOR

        public LiquidacionGridModelo() :base (new List<AtencionDto>()){ }

        public LiquidacionGridModelo(IEnumerable<AtencionDto> lista, int tamanioPagina, int totalPagina): base(lista,tamanioPagina,totalPagina) { }

        #endregion
    }
}