using PetCenter.Referencias.Dominio.Administracion.DTOs.Registros.Referencia;

namespace PetCenter.Referencias.Presentacion.Web.Models.Registros.ContraReferencia
{
    public class ContraReferenciaFiltroModelo
    {
        #region PROPIEDADES

        public ReferenciaDto Referencia { get; set; }

        #endregion

        #region CONSTRUCTOR

        public ContraReferenciaFiltroModelo() { }

        public ContraReferenciaFiltroModelo(ReferenciaDto _referencia)
        {
            Referencia = _referencia;
        }

        #endregion
    }
}