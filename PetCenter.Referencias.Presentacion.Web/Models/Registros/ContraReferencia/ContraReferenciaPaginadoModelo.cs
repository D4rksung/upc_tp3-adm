using PetCenter.Referencias.Presentacion.Web.Models.Comun;

namespace PetCenter.Referencias.Presentacion.Web.Models.Registros.ContraReferencia
{
    public class ContraReferenciaPaginadoModelo : MensajeModelo
    {
        #region PROPIEDADES

        public ContraReferenciaFiltroModelo Filtro { get; set; }

        public ContraReferenciaGridModelo Grid { get; set; }

        #endregion

        #region CONSTRUCTOR

        public ContraReferenciaPaginadoModelo()
        {
            Filtro = new ContraReferenciaFiltroModelo();
        }

        #endregion
    }
}