using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.Referencias.Transversal.Encriptacion
{
    /// <summary>
    /// Algoritmo de encriptación asimentrica, para generar la llave pública
    /// </summary>
    public static class HashCustom
    {
        /// <summary>
        /// HashSeguro
        /// </summary>
        /// <param name="strText">strText</param>
        /// <returns>Hash seguro</returns>
        public static string HashSeguro(this string strText)
        {
            var salt = Convert.ToBase64String((new DESCryptoServiceProvider()).Key);
            var ite = new Random().Next(1, 10);
            strText = Convert.ToBase64String(EncriptarHash(strText, salt, ite));
            PasswordDeriveBytes objPdb = new PasswordDeriveBytes(strText, Encoding.UTF8.GetBytes(salt), "SHA256", ite);

            return Convert.ToBase64String(objPdb.GetBytes(32));
        }

        /// <summary>
        /// EncriptarHash
        /// </summary>
        /// <param name="strPassword">strPassword</param>
        /// <param name="strSalt">strSalt</param>
        /// <param name="intIteraciones">intIteraciones</param>
        /// <returns>Bytes encriptados</returns>
        private static byte[] EncriptarHash(string strPassword, string strSalt, int intIteraciones)
        {
            string strPasswordSalt = strPassword + strSalt;
            SHA256Managed objSha256 = new SHA256Managed();
            byte[] objTemporal = null;


            try
            {
                objTemporal = System.Text.Encoding.UTF8.GetBytes(strPasswordSalt);
                for (int i = 0; i <= intIteraciones - 1; i++)
                    objTemporal = objSha256.ComputeHash(objTemporal);
            }
            finally { objSha256.Clear(); }

            return objTemporal;
        }

    }
}
