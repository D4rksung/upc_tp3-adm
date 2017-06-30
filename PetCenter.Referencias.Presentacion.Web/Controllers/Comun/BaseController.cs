
using PetCenter.Referencias.Dominio.Servicio;
using PetCenter.Referencias.Presentacion.Web.Helpers.Mvc;
using PetCenter.Referencias.Presentacion.Web.Resources.Enumeraciones;
using System.IO;
using System.Web;
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

        #region ARCHIVO

        /// <summary>
        /// Carga en memoria el archivo.
        /// </summary>
        /// <param name="excelStream">Stream del Archivo Excel</param>
        [HttpPost]
        public void CargaTemporalArchivo(HttpPostedFileBase fileStream, string suf = "")
        {
            TempData["fileStream" + suf] = fileStream;
        }

        /// <summary>
        /// Carga en memoria el archivo.
        /// </summary>
        /// <param name="excelStream">Stream del Archivo Excel</param>
        [HttpPost]
        public void CargaTemporalArchivoEspecial(string suf = "")
        {
            var fileStream = HttpContext.Request.Files.Get(0);
            TempData["fileStream" + suf] = fileStream;
        }

        /// <summary>
        /// Carga en memoria el archivo.
        /// </summary>
        /// <param name="excelStream">Stream del Archivo Excel</param>
        [HttpPost]
        [NoAntiForgeryCheckAttribute]
        public void LimpiarTemporalArchivo(string suf = "")
        {
            TempData["fileStream" + suf] = null;
        }

        #endregion

        #region DESCARGA

        /// <summary>
        /// Archivo
        /// </summary>
        /// <param name="idArchivo">idArchivo</param>
        /// <returns>Archivo</returns>
        [HttpGet]
        public ActionResult VerCargaTemporal(string suf = "")
        {
            var fileStream = TempData["fileStream" + suf] as HttpPostedFileBase;
            if (fileStream != null)
            {
                var clonFile = new MemoryStream();
                fileStream.InputStream.CopyTo(clonFile);
                fileStream.InputStream.Position = 0;
                TempData["fileStream" + suf] = fileStream;
                return this.File(clonFile.ToArray(), fileStream.ContentType, fileStream.FileName);
            }

            return Json(MensajeMvc.MensajeJson(TipoNotificacionEnum.Satisfactorio, "No existe archivo"));
        }

        #endregion
    }
}