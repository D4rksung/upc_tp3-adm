
using PetCenter.Referencias.Dominio.Servicio;
using System.Web.Mvc;

namespace PetCenter.Referencias.Presentacion.Web.Controllers.Comun
{
    public class BaseController : Controller
    {
        #region PROPIEDADES

        public readonly MaestrosServicio _maestrosServicio;
        public readonly RegistrosServicio _registrosServicio;

        #endregion

        #region CONSTRUCTOR

        public BaseController()
        {
            _maestrosServicio = MaestrosServicio.ObtenerServicio();
            _registrosServicio = RegistrosServicio.ObtenerServicio();
        }
        #endregion 


        #region CACHE

        /// <summary>
        /// Guardar en caché el objeto con el nombre del tipo al que pertece.
        /// </summary>
        /// <typeparam name="T">Tipo de objeto</typeparam>
        /// <param name="objeto">Objeto para guardar en caché</param>
        public void SetCache<T>(T objeto) where T : class
        {
            TempData[typeof(T).Name] = objeto;
        }

        /// <summary>
        /// Obtiene el objeto de caché, si no exíste devuelve el pasado por parámetro
        /// </summary>
        /// <typeparam name="T">Tipo de objeto</typeparam>
        /// <param name="objeto">Objeto en caso no haya caché</param>
        /// <returns>Objeto de la caché</returns>
        public T GetCache<T>(T objeto) where T : class
        {
            var name = typeof(T).Name;
            var obj = TempData[name];
            if (obj == null) return objeto;
            TempData.Keep(name);
            return obj as T;
        }

        #endregion
    }
}