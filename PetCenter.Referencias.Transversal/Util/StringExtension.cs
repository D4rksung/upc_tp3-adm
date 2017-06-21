using System;
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
    }
}
