using PetCenter.Referencias.Presentacion.Web.Models.Comun;

namespace PetCenter.Referencias.Presentacion.Web.Models.Registros.Evaluacion
{
    public class EvaluacionPaginadoModelo : MensajeModelo
    {
        #region PROPIEDADES

        public EvaluacionFiltroModelo Filtro { get; set; }

        public EvaluacionGridModelo Grid { get; set; }

        #endregion

        #region CONSTRUCTOR

        public EvaluacionPaginadoModelo()
        {
            Filtro = new EvaluacionFiltroModelo();
        }

        #endregion
    }
}