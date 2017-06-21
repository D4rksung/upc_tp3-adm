using System.Transactions;

namespace PetCenter.Referencias.Dominio.Administracion.Base
{
    internal static class TransactionHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static TransactionOptions OptionsDefaults()
        {
            //Creamos transacción para la operación en el contexto
            return new TransactionOptions
            {
                Timeout = TransactionManager.DefaultTimeout,
                IsolationLevel = IsolationLevel.ReadUncommitted
            };
        }
    }
}
