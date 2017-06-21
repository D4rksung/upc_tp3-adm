using System;
using System.Security.Cryptography;

namespace PetCenter.Referencias.Transversal.Encriptacion
{
    /// <summary>
    /// AESCustom
    /// </summary>
    public static class AESCustom
    {
        /// <summary>
        /// Encripta texto
        /// </summary>
        /// <param name="strEncriptar">Texto a encriptar</param>
        /// <param name="bytPK">Bytes de llave de encriptación</param>
        /// <returns>bytes encriptado</returns>
        private static byte[] EncriptarAES(string strEncriptar, byte[] bytPK)
        {
            Rijndael miRijndael = Rijndael.Create();
            byte[] encrypted = null;
            byte[] returnValue = null;

            try
            {
                miRijndael.Key = bytPK;
                miRijndael.GenerateIV();

                byte[] toEncrypt = System.Text.Encoding.UTF8.GetBytes(strEncriptar);
                encrypted = (miRijndael.CreateEncryptor()).TransformFinalBlock(toEncrypt, 0, toEncrypt.Length);

                returnValue = new byte[miRijndael.IV.Length + encrypted.Length];
                miRijndael.IV.CopyTo(returnValue, 0);
                encrypted.CopyTo(returnValue, miRijndael.IV.Length);

            }
            catch { }
            finally { miRijndael.Clear(); }

            return returnValue;
        }

        /// <summary>
        /// Desencripta el texto
        /// </summary>
        /// <param name="bytDesEncriptar">Bytes de texto encriptado</param>
        /// <param name="bytPK">Bytes de llave de encriptación</param>
        /// <returns>Cadena desencriptada</returns>
        private static string DesencriptarAES(byte[] bytDesEncriptar, byte[] bytPK)
        {
            Rijndael miRijndael = Rijndael.Create();
            byte[] tempArray = new byte[miRijndael.IV.Length];
            byte[] encrypted = new byte[bytDesEncriptar.Length - miRijndael.IV.Length];
            string returnValue = string.Empty;

            try
            {
                miRijndael.Key = bytPK;

                Array.Copy(bytDesEncriptar, tempArray, tempArray.Length);
                Array.Copy(bytDesEncriptar, tempArray.Length, encrypted, 0, encrypted.Length);
                miRijndael.IV = tempArray;

                returnValue = System.Text.Encoding.UTF8.GetString((miRijndael.CreateDecryptor()).TransformFinalBlock(encrypted, 0, encrypted.Length));

            }
            catch { }
            finally { miRijndael.Clear(); }

            return returnValue;
        }

        /// <summary>
        /// Encriptar texto
        /// </summary>
        /// <param name="strEncriptar">Cadena a encriptar</param>
        /// <param name="strPK">Llave de encriptación</param>
        /// <returns>Cadena Encriptada</returns>
        public static string EncriptarAES(this string strEncriptar, string strPK)
        {
            return Convert.ToBase64String(EncriptarAES(strEncriptar, (new PasswordDeriveBytes(strPK, null)).GetBytes(32)));
        }

        /// <summary>
        /// Descriptar cadena
        /// </summary>
        /// <param name="strEncriptar">Cadena encriptada</param>
        /// <param name="strPK">Llave de encriptación</param>
        /// <returns></returns>
        public static string DesencriptarAES(this string strEncriptar, string strPK)
        {
            return DesencriptarAES(Convert.FromBase64String(strEncriptar), (new PasswordDeriveBytes(strPK, null)).GetBytes(32));
        }
    }
}
