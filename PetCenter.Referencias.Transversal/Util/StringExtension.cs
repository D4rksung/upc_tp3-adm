using System;
using System.Linq;

namespace PetCenter.Referencias.Transversal.Util
{
    /// <summary>
    /// Contiene metodos nuevos para la clase Strings
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Formatea una cadena
        /// </summary>
        /// <param name="str">Cadena actual</param>
        /// <param name="param">Parametros</param>
        /// <returns>String con formato</returns>
        public static string FormatParams(this string str, params object[] param)
        {
            return string.Format(str, param);
        }

        /// <summary>
        /// Formatea una cadena
        /// </summary>
        /// <param name="str">Cadena actual</param>
        /// <param name="type">Tipo</param>
        /// <returns>String con formato</returns>
        public static string FormatParams(this string str, Type type)
        {
            return string.Format(str, type.Name);
        }

        public static string GenerarCodigo(int codigo)
        {
            var codigoGenerado = string.Empty;
            var longitud = codigo.ToString().Length;
            var ceros = string.Join("", Enumerable.Repeat('0', 5 - longitud));
            codigoGenerado = ceros + codigo.ToString();
            return codigoGenerado;
        }

        public static string RepiteCero(int veces)
        {
            //var codigoGenerado = string.Empty;
            //var longitud = codigo.ToString().Length;
            var ceros = string.Join("", Enumerable.Repeat('0', veces));
            //codigoGenerado = ceros + codigo.ToString();
            return ceros;
        }

        public static string ObtenerNombreMes(int nroMes)
        {
            var nombreMes = "";
            switch (nroMes)
            {
                case 1:
                    nombreMes = "Enero";
                    break;
                case 2:
                    nombreMes = "Febrero";
                    break;
                case 3:
                    nombreMes = "Marzo";
                    break;
                case 4:
                    nombreMes = "Abril";
                    break;
                case 5:
                    nombreMes = "Mayo";
                    break;
                case 6:
                    nombreMes = "Junio";
                    break;
                case 7:
                    nombreMes = "Julio";
                    break;
                case 8:
                    nombreMes = "Agosto";
                    break;
                case 9:
                    nombreMes = "Setiembre";
                    break;
                case 10:
                    nombreMes = "Octubre";
                    break;
                case 11:
                    nombreMes = "Noviembre";
                    break;
                case 12:
                    nombreMes = "Diciembre";
                    break;
                default:
                    break;
            }
            return nombreMes;
        }
    }
}
