using PetCenter.Referencias.Presentacion.Web.Models.Comun;

namespace PetCenter.Referencias.Presentacion.Web.Models.Registros.Liquidacion
{
    public class LiquidacionPaginadoModelo : MensajeModelo
    {
        #region PROPIEDADES

        public LiquidacionFiltroModelo Filtro { get; set; }

        public LiquidacionGridModelo Grid { get; set; }

        #endregion

        #region CONSTRUCTOR

        public LiquidacionPaginadoModelo()
        {
            Filtro = new LiquidacionFiltroModelo();
        }

        #endregion
    }
}