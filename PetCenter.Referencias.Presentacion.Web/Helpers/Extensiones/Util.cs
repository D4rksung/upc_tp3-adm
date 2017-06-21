using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Web.Mvc;
using PetCenter.Referencias.Presentacion.Web.Resources;
using iTextSharp.text;
using PetCenter.Referencias.Presentacion.Web.Models.Comun;
using System.Web;
using System.Configuration;
using PetCenter.Referencias.Dominio.Administracion.DTOs.General;

namespace PetCenter.Referencias.Presentacion.Web.Helpers.Extensiones
{
    /// <summary>
    /// Metodos de extension que facilitan algunas tareas
    /// </summary>
    public static class Util
    {
        #region LISTAS TT

        /// <summary>
        /// Convierte un lista de elementos en un lista seleccionable para la pagina
        /// </summary>
        /// <param name="origenTT"></param>
        /// <returns></returns>
        public static BindingList<SelectListItem> LlenarTT(this IEnumerable<ElementoDto> origenTT)
        {
            if (origenTT == null) return null;
            var destinyTT = new BindingList<SelectListItem>();

            foreach (ElementoDto it in origenTT)
            {
                destinyTT.Add(new SelectListItem
                {
                    Value = it.Valor,
                    Text = it.Texto
                });
            }
            return destinyTT;
        }

        #endregion

        #region Files

        /// <summary>
        /// NombreArchivoSinExtension
        /// </summary>
        /// <param name="nombre">nombre</param>
        /// <returns>Nombre sin extension</returns>
        public static string NombreArchivoSinExtension(this string nombre)
        {
            var lastBackslash = nombre.LastIndexOf(@"\");
            var lastPoint = nombre.LastIndexOf(".");
            if (lastBackslash == -1)
                return lastPoint == -1 ? nombre : nombre.Substring(0, lastPoint);
            else
                return lastPoint == -1 ? nombre.Substring(lastBackslash + 1) : nombre.Substring(lastBackslash + 1, lastPoint - lastBackslash - 1);
        }

        /// <summary>
        /// ExtensionArchivo
        /// </summary>
        /// <param name="nombre">Nombre</param>
        /// <returns>Extension del archivo</returns>
        public static string ExtensionArchivo(this string nombre)
        {
            var lastPoint = nombre.LastIndexOf(".");
            return lastPoint == -1 ? "" : nombre.Substring(lastPoint + 1, nombre.Length - lastPoint - 1);
        }

        #endregion

        #region ARCHIVO

        /// <summary>
        /// SizeToKMB
        /// </summary>
        /// <param name="tamanio">tamanio</param>
        /// <returns>Número de bytes</returns>
        public static string SizeToKMB(int tamanio)
        {
            if (tamanio < 1024)
                return tamanio + " B";
            else if (tamanio < 1024 * 1024)
                return (tamanio / 1024) + " KB";
            else if (tamanio < 1024 * 1024 * 1024)
                return (tamanio / (1024 * 1024)) + " MB";

            return "0 B";
        }

        /// <summary>
        /// Devuelve numero de Kb
        /// </summary>
        /// <param name="tamanio">int</param>
        /// <returns>string</returns>
        public static decimal SizeToKb(int tamanio)
        {
            return System.Math.Round(((decimal)tamanio / 1024), 2);
        }

        /// <summary>
        /// IconExtension
        /// </summary>
        /// <param name="ext">ext</param>
        /// <returns>Clase del icono a mostrar</returns>
        public static string IconExtension(string ext)
        {
            var icon = string.Empty;
            ext = ext.ToLower();

            switch (ext)
            {
                case "xls":
                case "xlsx":
                case "csv":
                    icon = Iconos.Icon16_Doc_Excel;
                    break;
                case "doc":
                case "docx":
                    icon = Iconos.Icon16_Doc_Word;
                    break;
                case "pdf":
                    icon = Iconos.Icon16_Doc_Pdf;
                    break;
                case "rar":
                case "zip":
                    icon = Iconos.Icon16_Doc_Zip;
                    break;
                case "jpg":
                case "gif":
                case "png":
                case "tif":
                case "jpeg":
                case "bmp":
                case "jpe":
                case "ico":
                    icon = Iconos.Icon16_Doc_Imgs;
                    break;
                default:
                    icon = Iconos.Icon16_Doc_Desconocido;
                    break;
            }

            return icon;
        }

        /// <summary>
        /// ContentType
        /// </summary>
        /// <param name="ext">extensión de archivo</param>
        /// <returns>content type</returns>
        public static string ContentTypeExtension(this string ext)
        {
            var contenttype = string.Empty;
            ext = ext.ToLower();

            switch (ext)
            {
                case "xls":
                    contenttype = ContentType.CT_Excel; break;
                case "xlsx":
                    contenttype = ContentType.CT_ExcelX; break;
                case "csv":
                    contenttype = ContentType.CT_Csv; break;
                case "doc":
                    contenttype = ContentType.CT_Word; break;
                case "docx":
                    contenttype = ContentType.CT_WordX; break;
                case "pdf":
                    contenttype = ContentType.CT_Pdf; break;
                case "rar":
                    contenttype = ContentType.CT_Rar; break;
                case "zip":
                    contenttype = ContentType.CT_Zip; break;
                case "jpg":
                case "jpe":
                case "jpeg":
                    contenttype = ContentType.CT_Jpg; break;
                case "gif":
                    contenttype = ContentType.CT_Gif; break;
                case "png":
                    contenttype = ContentType.CT_Png; break;
                case "tif":
                case "tifd":
                    contenttype = ContentType.CT_Tif; break;
                case "bmp":
                    contenttype = ContentType.CT_Bmp; break;
                case "ico":
                    contenttype = ContentType.CT_Icon; break;
                case "txt":
                    contenttype = ContentType.CT_Text; break;
                default:
                    contenttype = ContentType.CT_Desconocido; break;
            }

            return contenttype;
        }

        #endregion

        #region IMAGEN

        /// <summary>
        /// ConvertirImagenToByte
        /// </summary>
        /// <param name="rutaImagen"></param>
        /// <returns></returns>
        public static byte[] ConvertirImagenToArrayByte(string rutaImagen)
        {
            using (var fs = new FileStream(System.Web.HttpContext.Current.Server.MapPath(rutaImagen), FileMode.Open, FileAccess.Read))
            {
                var buffer = new byte[fs.Length];
                fs.Read(buffer, 0, (int)fs.Length);
                return buffer;
            }
        }

        /// <summary>
        /// GenerarImagen
        /// </summary>
        /// <param name="img">Array de bytes</param>
        /// <param name="align">ALIGN_BASELINE = 7, ALIGN_BOTTOM = 6, ALIGN_CENTER = 1, ALIGN_JUSTIFIED = 3, ALIGN_JUSTIFIED_ALL = 8, ALIGN_LEFT = 0, ALIGN_MIDDLE = 5, ALIGN_RIGHT = 2, ALIGN_TOP = 4</param>
        /// <returns></returns>
        public static Image GenerarImagen(byte[] img, int align)
        {
            Image imagen = Image.GetInstance(img);
            imagen.Alignment = align;
            return imagen;
        }

        #endregion

        #region FECHAS

        public static string ObtenerNombreMes(int mes)
        {
            string nombreMes = "";
            if (mes == 1) nombreMes = "enero";
            if (mes == 2) nombreMes = "febrero";
            if (mes == 3) nombreMes = "marzo";
            if (mes == 4) nombreMes = "abril";
            if (mes == 5) nombreMes = "mayo";
            if (mes == 6) nombreMes = "junio";
            if (mes == 7) nombreMes = "julio";
            if (mes == 8) nombreMes = "agosto";
            if (mes == 9) nombreMes = "septiembre";
            if (mes == 10) nombreMes = "octubre";
            if (mes == 11) nombreMes = "noviembre";
            if (mes == 12) nombreMes = "diciembre";
            return nombreMes;
        }

        #endregion

        #region CONTROLLER ACTION NAME

        /// <summary>
        /// ObtenerController
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static string ObtenerControllerName(HttpRequestBase request)
        {
            var nombreController = "";
            if (ConfigurationManager.AppSettings["desarrollo"] == null)
            {
                nombreController = request.FilePath.Split('/')[2].ToString();
            }
            else
            {
                nombreController = request.FilePath.Split('/')[1].ToString();
            }

            return nombreController;
        }

        /// <summary>
        /// ObtenerAction
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static string ObtenerActionName(HttpRequestBase request)
        {
            // 
            var nombreActionName = "";
            if (ConfigurationManager.AppSettings["desarrollo"] == null)
            {
                return request.FilePath.Split('/')[3].ToString();
            }
            else
            {
                return request.FilePath.Split('/')[2].ToString();
            }
            return nombreActionName;
        }

        #endregion
    }
}